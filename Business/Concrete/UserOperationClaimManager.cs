using AutoMapper;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation.UserOperationClaimValidators;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete.Entities;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Dtos.UserOperationClaimDtos.UserOperationClaimAddDtos;
using Entities.Concrete.Dtos.UserOperationClaimDtos.UserOperationClaimGetByIdDtos;
using Entities.Concrete.Dtos.UserOperationClaimDtos.UserOperationClaimGetByUserIdDtos;
using Entities.Concrete.Dtos.UserOperationClaimDtos.UserOperationClaimGetListDtos;
using Entities.Concrete.Dtos.UserOperationClaimDtos.UserOperationClaimUpdateDtos;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private IUserOperationClaimDal _userOperationClaimDal;
        private IMapper _mapper;
        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal, IMapper mapper)
        {
            _userOperationClaimDal = userOperationClaimDal;
            _mapper = mapper;
        }

        [SecurityAspect("UserOperationClaim.Add", Priority = 2)]
        [ValidationAspect(typeof(UserOperationClaimAddRequestDtoValidator), Priority = 3)]
        [CacheRemoveAspect("IUserOperationClaimService.Get", Priority = 4)]
        public async Task<IResult> Add(UserOperationClaimAddRequestDto userOperationClaimAddRequestDto)
        {
            var userOperationClaim = _mapper.Map<UserOperationClaim>(userOperationClaimAddRequestDto);
            await _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult(UserOperationClaimMessages.Added);
        }

        [SecurityAspect("UserOperationClaim.Delete", Priority = 2)]
        [CacheRemoveAspect("IUserOperationClaimService.Get", Priority = 3)]
        public async Task<IResult> Delete(int id)
        {
            var userOperationClaim = await _userOperationClaimDal.Get(x => x.Id == id && x.IsActive == true);
            if(userOperationClaim != null)
            {   
                userOperationClaim.IsActive = false;    
                await _userOperationClaimDal.Update(userOperationClaim);
            }
            return new SuccessResult(UserOperationClaimMessages.Deleted);
        }

        [SecurityAspect("UserOperationClaim.GetById", Priority = 2)]
        public async Task<IDataResult<UserOperationClaimGetByIdResponseDto>> GetById(int id)
        {
            var userOperationClaim = await _userOperationClaimDal.Get(x => x.Id == id && x.IsActive == true );
            var userOperationClaimGetByIdResponseDto = _mapper.Map<UserOperationClaimGetByIdResponseDto>(userOperationClaim);
            return new SuccessDataResult<UserOperationClaimGetByIdResponseDto>(userOperationClaimGetByIdResponseDto);
        }

        [SecurityAspect("UserOperationClaim.GetByUserId", Priority = 2)]
        public async Task<IDataResult<List<UserOperationClaimGetByUserIdResponseDto>>> GetByUserId(int userId)
        {
            var userOperationClaims = await _userOperationClaimDal.GetList(x => x.UserId==userId && x.IsActive == true);
            var userOperationClaimGetByUserIdResponseDtos = _mapper.Map<List<UserOperationClaimGetByUserIdResponseDto>>(userOperationClaims);
            userOperationClaimGetByUserIdResponseDtos= userOperationClaimGetByUserIdResponseDtos.OrderBy(x=>x.UserId).OrderBy(x=>x.OperationClaimId).ToList();
            return new SuccessDataResult<List<UserOperationClaimGetByUserIdResponseDto>>(userOperationClaimGetByUserIdResponseDtos);
        }

        [SecurityAspect("UserOperationClaim.GetList", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<UserOperationClaimGetListResponseDto>>> GetList()
        {
            var userOperationClaims = await _userOperationClaimDal.GetList(x=>x.IsActive==true);
            var userOperationClaimGetListResponseDtos = _mapper.Map<List<UserOperationClaimGetListResponseDto>>(userOperationClaims);
            userOperationClaimGetListResponseDtos= userOperationClaimGetListResponseDtos.OrderBy(x=>x.UserId).OrderBy(x => x.OperationClaimId).ToList();
            return new SuccessDataResult<List<UserOperationClaimGetListResponseDto>>(userOperationClaimGetListResponseDtos);
        }

        [SecurityAspect("UserOperationClaim.Update", Priority = 2)]
        [ValidationAspect(typeof(UserOperationClaimUpdateRequestDtoValidator), Priority = 3)]
        [CacheRemoveAspect("IUserOperationClaimService.Get", Priority = 4)]
        public async Task<IResult> Update(UserOperationClaimUpdateRequestDto userOperationClaimUpdateRequestDto)
        {
            var userOperationClaim = _mapper.Map<UserOperationClaim>(userOperationClaimUpdateRequestDto);
            if(userOperationClaim != null)
            { 
                await _userOperationClaimDal.Update(userOperationClaim);
                return new SuccessResult(UserOperationClaimMessages.Updated);

            }
            return new ErrorResult(UserOperationClaimMessages.OperationFailed);

        }
















    }
}
