using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using movieSearch.Model.dto;
using movieSerach.iservice;

namespace movieSearch.api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowMyOrigin")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IUserService userService;

        public IConfiguration _config = null;

        public LoginController(IConfiguration config, IUserService userService)
        {
            _config = config;
            this.userService = userService;
        }
        public ActionResult Post(LoginRequest loginRequest)
        {
            //here user can be authenticated
            try
            {
                var userDto = this.userService.GetUser(loginRequest);
                if (userDto != null)
                {
                    string token = GenerateJSONWebToken(userDto);
                    LoginDto tokenDto = new LoginDto { token= token };
                    return Ok(tokenDto);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
       
            private string GenerateJSONWebToken(UserDto userDto)
            {
                // when he is validated AD

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub,Convert.ToString(userDto?.Id)),
                new Claim(JwtRegisteredClaimNames.Email, ""),
                new Claim("Roles", userDto.Role),
                new Claim("UserId",Convert.ToString(userDto?.Id)),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                  _config["Jwt:Issuer"],
                  claims,
                  expires: DateTime.Now.AddMinutes(120),
                  signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }
    }


