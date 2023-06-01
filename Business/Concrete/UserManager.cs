using AutoMapper;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation.UserValidators;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete.Entities;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete.Dtos.UserDtos.UserAddDtos;
using Entities.Concrete.Dtos.UserDtos.UserGetByIdDtos;
using Entities.Concrete.Dtos.UserDtos.UserGetByUserNameDtos;
using Entities.Concrete.Dtos.UserDtos.UserGetClaimsDtos;
using Entities.Concrete.Dtos.UserDtos.UserSearch;
using Entities.Concrete.Dtos.UserDtos.UserUpdateDtos;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private IMapper _mapper;
        public UserManager(IUserDal userDal, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
        }

        [SecurityAspect("User.GetClaims", Priority = 2)]
        [ValidationAspect(typeof(UserGetClaimsRequestDtoValidator), Priority = 3)]
        public async Task<IDataResult<List<UserGetClaimsResponseDto>>> GetClaims(UserGetClaimsRequestDto userGetClaimsRequestDto)
        {
            var user = _mapper.Map<User>(userGetClaimsRequestDto);
            var operationCliams = await _userDal.GetClaims(user);
            var userGetClaimsResponseDto = _mapper.Map<List<UserGetClaimsResponseDto>>(operationCliams);
            return new SuccessDataResult<List<UserGetClaimsResponseDto>>(userGetClaimsResponseDto);
        }

        [SecurityAspect("User.Add", Priority = 2)]
        [ValidationAspect(typeof(UserAddRequestDtoValidator), Priority = 3)]
        [CacheRemoveAspect("IUserService.Get", Priority = 4)]
        public async Task<IResult> Add(UserAddRequestDto userAddRequestDto)
        {
            var user = await _userDal.Get(x => x.UserName == userAddRequestDto.UserName && x.IsActive == true);

            if (user == null)
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(userAddRequestDto.Password, out passwordHash, out passwordSalt);

                user = _mapper.Map<User>(userAddRequestDto);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.IsActive = true;

                await _userDal.Add(user);

                return new SuccessResult(UserMessages.Added);
            }

            return new ErrorResult(UserMessages.UserAlreadyExists);
        }

        [SecurityAspect("User.GetByUserName", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<UserGetByUserNameResponseDto>> GetByUserName(string userName)
        {
            var user = await _userDal.Get(x => x.UserName == userName && x.IsActive == true);
            var userGetByUserNameResponseDto = _mapper.Map<UserGetByUserNameResponseDto>(user);
            return new SuccessDataResult<UserGetByUserNameResponseDto>(userGetByUserNameResponseDto);
        }

        [SecurityAspect("User.Update", Priority = 2)]
        [ValidationAspect(typeof(UserUpdateRequestDtoValidator), Priority = 3)]
        [CacheRemoveAspect("IUserService.Get", Priority = 4)]
        public async Task<IResult> Update(UserUpdateRequestDto userUpdateRequestDto)
        {
            var user = _mapper.Map<User>(userUpdateRequestDto);
            if (user != null)
            {
                if (string.IsNullOrEmpty(userUpdateRequestDto.Password))
                {
                    user = _mapper.Map<User>(userUpdateRequestDto);
                    user.PasswordHash = user.PasswordHash;
                    user.PasswordSalt = user.PasswordSalt;
                    user.IsActive = true;
                }
                else
                {
                    byte[] passwordHash, passwordSalt;
                    HashingHelper.CreatePasswordHash(userUpdateRequestDto.Password, out passwordHash, out passwordSalt);

                    user = _mapper.Map<User>(userUpdateRequestDto);
                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                    user.IsActive = true;
                }
                await _userDal.Update(user);

                return new SuccessResult(UserMessages.Updated);
            }
            return new ErrorResult(UserMessages.OperationFailed);
        }

        [SecurityAspect("User.Delete", Priority = 2)]
        [CacheRemoveAspect("IUserService.Get", Priority = 3)]
        public async Task<IResult> Delete(int id)
        {
            var user = await _userDal.Get(x => x.Id == id && x.IsActive == true);
            if (user != null)
            {
                user.IsActive = false;
                await _userDal.Update(user);
                return new SuccessResult(UserMessages.Deleted);

            }
            return new ErrorResult(UserMessages.OperationFailed);

        }

        [SecurityAspect("User.Search", Priority = 2)]
        [ValidationAspect(typeof(UserSearchRequestDtoValidator), Priority = 3)]
        public async Task<IDataResult<List<UserSearchResponseDto>>> Search(UserSearchRequestDto userSearchRequestDto)
        {
            var users = await _userDal.GetList(x => (x.IsActive == true) &&
            (x.UserName.Contains(userSearchRequestDto.UserName) || userSearchRequestDto.UserName == string.Empty) &&
            (x.FirstName.Contains(userSearchRequestDto.FirstName) || userSearchRequestDto.FirstName == string.Empty) &&
            (x.LastName.Contains(userSearchRequestDto.LastName) || userSearchRequestDto.LastName == string.Empty));

            var userSearchResponseDtos = _mapper.Map<List<UserSearchResponseDto>>(users);

            return new SuccessDataResult<List<UserSearchResponseDto>>(userSearchResponseDtos);
        }

        [SecurityAspect("User.GetById", Priority = 2)]
        public async Task<IDataResult<UserGetByIdResponseDto>> GetById(int id)
        {
            var user = await _userDal.Get(x => x.Id == id && x.IsActive == true);
            var userGetByIdResponseDto = _mapper.Map<UserGetByIdResponseDto>(user);
            return new SuccessDataResult<UserGetByIdResponseDto>(userGetByIdResponseDto);
        }
    }
}
