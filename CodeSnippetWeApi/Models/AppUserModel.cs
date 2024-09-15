using Microsoft.AspNetCore.Identity;

namespace CodeSnippetWeApi.Models
{
    public class AppUserModel : IdentityUser<int>
    {
        public string FullName { get; set; }
    }
}
