using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace AuthServer.Services
{
    public class TokenGenerator : ITokenGenerator
    {
        public string GetJWTToken(string userId)
        {
            //setting the claims for the user credential name
            var claims = new[]
           {
                new Claim(JwtRegisteredClaimNames.UniqueName, userId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            //Defining security key and encoding the claim 
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secret_mongoapi_jwt"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //defining the JWT token essential information and setting its expiration time
            var token = new JwtSecurityToken(
                issuer: "AuthServer",
                audience: "customerapi",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(20),
                signingCredentials: creds
            );
            //defing the response of the token 
            var response = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            };
            //convert into the json by serialing the response object
            return JsonConvert.SerializeObject(response);
        }
    }
}
