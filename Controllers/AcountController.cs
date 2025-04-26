using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace jwt_TokenDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcountController : ControllerBase
    {

        [HttpPost("Register")]
        public IActionResult Login(string username, string Pass)
        {

            if (string.IsNullOrEmpty(Pass) || string.IsNullOrEmpty(username))
            {
                return Unauthorized();
            }

            var key = "ntjdfhsquWHUQWEHRAUUGSHDRUTHuifjIGRJQ4J6IWRSJZIwsDFw";

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, "User"),
                new Claim(ClaimTypes.Role, "Admin")


            };
            var tokenData = new JwtSecurityToken(
            issuer: "http://localhost:44300",
            audience: "http://localhost:44300",
            claims: claims,
            expires: DateTime.Now.AddMinutes(30), // Set expiration time (optional)
            signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenData);

            return Ok(token);
        }
    }
}
