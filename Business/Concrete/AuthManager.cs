﻿using AutoMapper;
using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation.AuthValidators;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete.Entities;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security;
using Core.Utilities.Security.Abstract;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete.Dtos.AuthDtos.AccessTokenDtoS;
using Entities.Concrete.Dtos.AuthDtos.GetByUserNameDto;
using Entities.Concrete.Dtos.AuthDtos.LoginDtos;
using Entities.Concrete.Dtos.AuthDtos.RegisterDtos;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserDal _userDal;
        private ITokenHelper _tokenHelper;
        private IMapper _mapper;

        public AuthManager(IUserDal userDal, ITokenHelper tokenHelper, IMapper mapper)
        {
            _userDal = userDal;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(RegisterRequestDtoValidator), Priority = 2)]
        public async Task<IDataResult<AccessToken>> Register(RegisterRequestDto registerRequestDto)
        {
            var userExistsResult = await UserExists(registerRequestDto.UserName);
            if (userExistsResult.Success)
            {
                
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(registerRequestDto.Password, out passwordHash, out passwordSalt);

                var user = _mapper.Map<User>(registerRequestDto);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.IsActive = true;

                await _userDal.Add(user);

                var accessTokenAddRequestDto = _mapper.Map<AccessTokenAddRequestDto>(user);

                var accessTokenResult = await CreateAccessToken(accessTokenAddRequestDto);
                return accessTokenResult;
             
            }

            return new ErrorDataResult<AccessToken>(null, UserMessages.UserAlreadyExists);
        }

        [ValidationAspect(typeof(LoginRequestDtoValidator), Priority = 2)]
        public async Task<IDataResult<AccessToken>> Login(LoginRequestDto loginRequestDto)
        {
            var user = await _userDal.Get(x => x.UserName == loginRequestDto.UserName && x.IsActive == true);

            if (user != null)
            {
                var veryfyPasswordHash = HashingHelper.VeryfyPasswordHash(loginRequestDto.Password, user.PasswordHash, user.PasswordSalt);
                if (veryfyPasswordHash)
                {
                    var accessTokenAddRequestDto = _mapper.Map<AccessTokenAddRequestDto>(user);
                    var accessTokenResult = await CreateAccessToken(accessTokenAddRequestDto);
                    return accessTokenResult;
                }
            }
            return new ErrorDataResult<AccessToken>(null, UserMessages.UserNotFound);
        }
        public async Task<IResult> UserExists(string userName)
        {
            var user = await _userDal.Get(x => x.UserName == userName && x.IsActive == true);

            if (user != null)
            {
                return new ErrorResult(UserMessages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        [ValidationAspect(typeof(AccessTokenAddRequestDtoValidator), Priority = 2)]
        public async Task<IDataResult<AccessToken>> CreateAccessToken(AccessTokenAddRequestDto accessTokenAddRequestDto)
        {
            var accessToken = new AccessToken();
            var userId = accessTokenAddRequestDto.Id;
            var user=await _userDal.Get(x=>x.Id == userId);
            var claims = await _userDal.GetClaims(user);
            if (claims != null)
            {
                accessToken = _tokenHelper.CreateToken(user, claims);
                return new SuccessDataResult<AccessToken>(accessToken, AuthMessages.AccessTokenCreated);
            }

            return new ErrorDataResult<AccessToken>(null, AuthMessages.AccessTokenNotCreated);
        }

        public async Task<IDataResult<GetByUserNameResponseDto>> GetByUserName(string userName)
        {
            var user = await _userDal.Get(x => x.UserName == userName && x.IsActive == true);
            var getByUserNameResponseDto = _mapper.Map<GetByUserNameResponseDto>(user);
            return new SuccessDataResult<GetByUserNameResponseDto>(getByUserNameResponseDto);
        }
    }
}
