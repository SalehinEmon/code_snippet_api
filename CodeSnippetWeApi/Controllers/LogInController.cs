using CodeSnippetWeApi.BLL;
using CodeSnippetWeApi.Helper;
using CodeSnippetWeApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace CodeSnippetWeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        JWTHelper _jWTHelper;
        UserBll _userBll;
        public LogInController(JWTHelper jWTHelper, UserBll userBll)
        {
            _jWTHelper = jWTHelper;
            _userBll = userBll;
        }

        [HttpPost("tokencheck")]

        public async Task<ActionResult<ResponseModel>> JwtValidate(
            [FromForm] string token)
        {
            ResponseModel loginResponse = _jWTHelper.ValidateToken(token);
            if (loginResponse == null || loginResponse.IsSuccess == false)
            {
                return BadRequest(loginResponse);
            }
            return Ok(loginResponse);
        }


        [HttpPost]

        public async Task<ActionResult<ResponseModel>> LogIn([FromForm] string userNameEmail,
            [FromForm] string userPassword)
        {
            ResponseModel loginResponse = await
                _userBll.PaswordLogin(userNameEmail, userPassword);

            if (loginResponse.IsSuccess)
            {
                loginResponse.RequestedBody.PasswordHash = "";
                loginResponse.RequestedBody.SecurityStamp = "";
                loginResponse.RequestedBody.ConcurrencyStamp = "";

                AppUserModel appUser = loginResponse.RequestedBody;

                string jwtToken = _jWTHelper.GenerateTokenStirng(appUser);
                loginResponse.IsSuccess = true;
                loginResponse.Token = jwtToken;
                return Ok(loginResponse);

            }

            return BadRequest(loginResponse);
        }



    }
}
