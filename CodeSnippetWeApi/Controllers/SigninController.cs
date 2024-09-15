using CodeSnippetWeApi.BLL;
using CodeSnippetWeApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeSnippetWeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SigninController : ControllerBase
    {
        UserBll _userBll;
        public SigninController(UserBll userBll)
        {
            _userBll = userBll;
        }
        [HttpPost]
        //[Authorize]

        public async Task<ActionResult<ResponseModel>> SignIn([FromForm] string fullName,
            [FromForm] string userNameEmail, [FromForm] string userPassword)
        {
            AppUserModel user = new AppUserModel
            {
                FullName = fullName,
                UserName = userNameEmail,
                Email = userNameEmail,
            };

            ResponseModel response = await _userBll.AddUser(user, userPassword);

            if (response.IsSuccess)
            {
                return Ok(response);

            }


            return BadRequest(response);


        }


    }
}
