using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Demo.Application.DTOs.Auth;
using Demo.Application.DTOs.User;
using Demo.Application.Interfaces;
using Demo.Application.Mapper.UserMapper;
using Demo.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Demo.Application.Services
{
    public class AuthService: ControllerBase, IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthService(IUserRepository userRepository, IAccountRepository accountRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ActionResult> LoginAsync(LoginRequest loginRequest)
        {
            try
            {
                var email = loginRequest.Email;
                var password = loginRequest.Password;
                var user = await _userRepository.GetUserByEmailAsync(email) ?? throw new Exception("Invalid email or password !");
                
                var accountId = user?.AccountId ?? throw new Exception("Invalid email or password !");
                var account = await _accountRepository.GetAccountByIdAsync(accountId);
                var accountPasswordHashed = account?.Password ?? throw new Exception("Invalid email or password !");

                bool verified = BCrypt.Net.BCrypt.Verify(password, accountPasswordHashed);
                if (!verified) throw new Exception("Invalid email or password !");

                // create jwt
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();

                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtKeySecret = configuration["JWT_KEY_SECRET"] ?? "123456";
                var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtKeySecret));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

                var claim = new ClaimsIdentity(new[]
                {
                    new Claim("Email", loginRequest?.Email),
                });

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]{ new Claim("id", loginRequest?.Email), new Claim(ClaimTypes.Role, account?.Role?.RoleName) }),
                    Expires = DateTime.UtcNow.AddHours(2),
                    SigningCredentials = credentials,
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var encryptorToken = tokenHandler.WriteToken(token);

                // store token to cookie
                var context = _httpContextAccessor.HttpContext;
                context?.Response.Cookies.Append("token", encryptorToken,
                    new CookieOptions
                    {
                        Expires = DateTime.Now.AddHours(1),
                        HttpOnly = true,
                        Secure = false,
                        IsEssential = true,
                        SameSite = SameSiteMode.Strict,
                    });

                var userMapperDTO = UserMapperResponse.GetUserMapEntityToDTO(user);
                //context?.Session.SetString("userData", JsonConvert.SerializeObject(userMapperDTO));

                return Ok(new
                {
                    status = 200,
                    data = userMapperDTO,
                    message = "Login Successfully !",
                });
            } catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message,
                });
            }
        }

        public async Task<ActionResult> LogoutAsync()
        {
            try
            {
                var context = _httpContextAccessor.HttpContext ?? throw new Exception("Http context is invalid !");

                context?.Response.Cookies.Delete("token");
                return Ok(new
                {
                    status = 200,
                    message = "Logout Successfully !"
                });
            } catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message,
                });
            }

        }
    }
}
