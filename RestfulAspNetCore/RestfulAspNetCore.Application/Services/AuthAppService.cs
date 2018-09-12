using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestfulAspNetCore.Application.Configuration.Token;
using RestfulAspNetCore.Application.Interfaces;
using RestfulAspNetCore.Application.Model;
using RestfulAspNetCore.Domain.Interfaces;
using RestfulAspNetCore.Domain.InterfacesRepo;
using RestfulAspNetCore.Helper;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RestfulAspNetCore.Application.Services
{
    public class AuthAppService : AppService, IAuthAppService
    {

        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private TokenConfiguration _tokenConfiguration;
        private SigningConfigurations _signingConfiguration;

        public AuthAppService(IMapper mapper, IUserService userService, TokenConfiguration tokenConfiguration, SigningConfigurations signingConfiguration, IUnitOfWork uow) : base(uow)
        {
            _tokenConfiguration = tokenConfiguration;
            _signingConfiguration = signingConfiguration;
            _userService = userService;
            _mapper = mapper;
        }

        public TokenResponseModel Auth(UserLoginModel userLoginModel)
        {
            if (userLoginModel.Grant_type == "password")
            {
                return VerifyPassword(userLoginModel);
            }
            else if (userLoginModel.Grant_type == "refresh_token")
            {
                return RefreshToken(userLoginModel);
            }

            return null;
        }

        private TokenResponseModel VerifyPassword(UserLoginModel loginModel)
        {
            // procura usuario
            var user = _userService.GetByEmail(loginModel.Email);
            if (user == null)
                return null;

            if (!user.IsActive)
                return null;

            //valida client secret
            if (loginModel.ClientSecret != user.ClientSecret)
                return null;

            // check if password is correct
            if (!PasswordHelper.VerifyPasswordHash(loginModel.Password, user.PasswordHash, user.PasswordSalt))
                return null;

            var refresh_token = Guid.NewGuid().ToString().Replace("-", "");

            //store the refresh_token   
            user.RefreshToken = refresh_token;
            var userUpdate = _userService.Update(user);

            Commit();

            return GetJwt(user.Email, "", refresh_token);
        }

        private TokenResponseModel RefreshToken(UserLoginModel loginModel)
        {
            var user = _userService.GetByEmailAndRefreshToken(loginModel.Email, loginModel.Refresh_token);
            if (user == null)
                return null;

            if (!user.IsActive)
                return null;

            var refresh_token = Guid.NewGuid().ToString().Replace("-", "");

            //atualizar novo token
            // poderia gravar o historico de tokens
            user.RefreshToken = refresh_token;
            var userUpdate = _userService.Update(user);

            Commit();

            return GetJwt(user.Email, "", refresh_token);
        }

        private TokenResponseModel GetJwt(string email, string permission, string refresh_token)
        {
            var now = DateTime.UtcNow;
            var expiresDate = now.AddSeconds(_tokenConfiguration.Seconds);

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, email),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString(), ClaimValueTypes.Integer64),
                new Claim("admin", "true")
            };

            var jwt = new JwtSecurityToken(
                issuer: _tokenConfiguration.Issuer,
                audience: _tokenConfiguration.Audience,
                claims: claims,
                notBefore: now,
                expires: expiresDate,
                signingCredentials: _signingConfiguration.SigningCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new TokenResponseModel
            {
                access_token = encodedJwt,
                expires_in = expiresDate.ToString("yyyy-MM-dd HH-mm-ss"),
                refresh_token = refresh_token,
            };

            return response;
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
