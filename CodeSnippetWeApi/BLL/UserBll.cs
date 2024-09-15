using CodeSnippetWeApi.Models;
using Microsoft.AspNetCore.Identity;

namespace CodeSnippetWeApi.BLL
{
    public class UserBll
    {
        UserManager<AppUserModel> _userManager;
        SignInManager<AppUserModel> _signInManager;
        public UserBll(UserManager<AppUserModel> userManager,
            SignInManager<AppUserModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ResponseModel> AddUser(AppUserModel appUser, string password)
        {

            IdentityResult result = await _userManager.CreateAsync(appUser, password);
            ResponseModel response = new ResponseModel();
            if (result.Succeeded)
            {
                response.IsSuccess = true;
            }
            return response;
        }

        public async Task<ResponseModel> PaswordLogin(string email, string password)
        {
            bool result = false;
            AppUserModel? userToLogIn = await _userManager.FindByEmailAsync(email);
            ResponseModel response = new ResponseModel();

            if (userToLogIn != null)
            {
                result = await _userManager.CheckPasswordAsync(userToLogIn, password);

                if (result)
                {
                    response.RequestedBody = userToLogIn;
                    response.IsSuccess = true;
                }
                else
                {
                    response.Message = "Wrong passowrd or emial";

                }

            }
            else
            {
                response.Message = "Wrong passowrd or emial";
            }

            return response;
        }
    }
}


