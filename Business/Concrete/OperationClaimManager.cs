using AutoMapper;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation.OperationClaimValidators;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete.Entities;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Dtos.OperationClaimDtos.OperationClaimAddDtos;
using Entities.Concrete.Dtos.OperationClaimDtos.OperationClaimGetByIdDtos;
using Entities.Concrete.Dtos.OperationClaimDtos.OperationClaimGetListDtos;
using Entities.Concrete.Dtos.OperationClaimDtos.OperationClaimSearch;
using Entities.Concrete.Dtos.OperationClaimDtos.OperationClaimUpdateDtos;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        private IOperationClaimDal _operationClaimDal;
        private IMapper _mapper;
        public OperationClaimManager(IOperationClaimDal operationClaimDal, IMapper mapper)
        {
            _operationClaimDal = operationClaimDal;
            _mapper = mapper;
        }

        [SecurityAspect("OperationClaim.Add", Priority = 2)]
        [ValidationAspect(typeof(OperationClaimAddRequestDtoValidator), Priority = 3)]
        [CacheRemoveAspect("IOperationClaimService.Get", Priority = 4)]
        public async Task<IResult> Add(OperationClaimAddRequestDto operationClaimAddRequestDto)
        {
            var operationClaim = _mapper.Map<OperationClaim>(operationClaimAddRequestDto);
            await _operationClaimDal.Add(operationClaim);
            return new SuccessResult(OperationClaimMessages.Added);
        }

        [SecurityAspect("OperationClaim.Delete", Priority = 2)]
        [CacheRemoveAspect("IOperationClaimService.Get", Priority = 3)]
        public async Task<IResult> Delete(int id)
        {
            var operationClaim = await _operationClaimDal.Get(x => x.Id == id && x.IsActive == true);
            if (operationClaim != null)
            {
                operationClaim.IsActive = false;
                await _operationClaimDal.Update(operationClaim);
                return new SuccessResult(OperationClaimMessages.Deleted);

            }

            return new ErrorResult(OperationClaimMessages.OperationFailed);
        }

        [SecurityAspect("OperationClaim.GetById", Priority = 2)]
        public async Task<IDataResult<OperationClaimGetByIdResponseDto>> GetById(int id)
        {
            var operationClaim = await _operationClaimDal.Get(x => x.Id == id && x.IsActive == true);
            var operationClaimGetByIdResponseDto = _mapper.Map<OperationClaimGetByIdResponseDto>(operationClaim);
            return new SuccessDataResult<OperationClaimGetByIdResponseDto>(operationClaimGetByIdResponseDto);
        }

        [SecurityAspect("OperationClaim.GetList", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<OperationClaimGetListResponseDto>>> GetList()
        {
            var operationClaims = await _operationClaimDal.GetList(x => x.IsActive == true);
            var OperationClaimGetListResponseDtos = _mapper.Map<List<OperationClaimGetListResponseDto>>(operationClaims);
            OperationClaimGetListResponseDtos = OperationClaimGetListResponseDtos.OrderBy(x => x.Name).ToList();
            return new SuccessDataResult<List<OperationClaimGetListResponseDto>>(OperationClaimGetListResponseDtos);
        }

        [SecurityAspect("OperationClaim.Update", Priority = 2)]
        [ValidationAspect(typeof(OperationClaimUpdateRequestDtoValidator), Priority = 3)]
        [CacheRemoveAspect("IOperationClaimService.Get", Priority = 4)]
        public async Task<IResult> Update(OperationClaimUpdateRequestDto operationClaimUpdateRequestDto)
        {
            var operationClaim = _mapper.Map<OperationClaim>(operationClaimUpdateRequestDto);
            if (operationClaim != null)
            {
                await _operationClaimDal.Update(operationClaim);
                return new SuccessResult(OperationClaimMessages.Updated);
            }

            return new ErrorResult(OperationClaimMessages.OperationFailed);
        }

        [SecurityAspect("OperationClaim.Search", Priority = 2)]
        [ValidationAspect(typeof(OperationClaimSearchRequestDtoValidator), Priority = 3)]
        public async Task<IDataResult<List<OperationClaimSearchResponseDto>>> Search(OperationClaimSearchRequestDto operationClaimSearchRequestDto)
       {
            var operationClaim = await _operationClaimDal.GetList(x => (x.IsActive == true) &&
            (x.Name.Contains(operationClaimSearchRequestDto.Name) || operationClaimSearchRequestDto.Name == string.Empty));

            var operationClaimSearchResponseDtos = _mapper.Map<List<OperationClaimSearchResponseDto>>(operationClaim);
            operationClaimSearchResponseDtos = operationClaimSearchResponseDtos.OrderBy(x => x.Name).ToList();

            return new SuccessDataResult<List<OperationClaimSearchResponseDto>>(operationClaimSearchResponseDtos);
        }

















    }
}
