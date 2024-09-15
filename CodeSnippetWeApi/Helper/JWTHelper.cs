using CodeSnippetWeApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CodeSnippetWeApi.Helper
{
    public class JWTHelper
    {
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _jwtSettings;

        public JWTHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _jwtSettings = _configuration.GetSection("JwtSettings");
        }


        public SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("securityKey").Value);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public List<Claim> GetClaims(AppUserModel user)
        {
            var claims = new List<Claim>
        {
            //new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email)

        };

            return claims;
        }

        public JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtSettings["validIssuer"],
                audience: _jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                //expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings["expiryInMinutes"])),
                signingCredentials: signingCredentials); ;

            return tokenOptions;
        }


        public string GenerateTokenStirng(AppUserModel userToLogIn)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = GetClaims(userToLogIn);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return token;
        }


        public ResponseModel ValidateToken(string token)
        {
            ResponseModel responseModel = new ResponseModel()
            {
                IsSuccess = false,
                Code = 400,
                Message = "Validation Failed."
            };

            if (token == null)
                return responseModel;

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("securityKey").Value);


            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero

                }, out SecurityToken validatedToken);

                // Corrected access to the validatedToken
                var jwtToken = (JwtSecurityToken)validatedToken;
                //var jku = jwtToken.Claims.First(claim => claim.Type == "kid").Value;
                //var userName = jwtToken.Claims.First(claim => claim.Type == "jku").Value;
                responseModel.IsSuccess = true;
                responseModel.Code = 200;
                responseModel.Message = "Validated";

                return responseModel;
            }
            catch
            {
                return responseModel;
            }
        }
    }
}
