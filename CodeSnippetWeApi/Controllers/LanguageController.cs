using CodeSnippetWeApi.BLL;
using CodeSnippetWeApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeSnippetWeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        LanguageBLL _languageBLL;
        public LanguageController(LanguageBLL languageBLL)
        {
            _languageBLL = languageBLL;
        }

        [HttpPost("add")]
        [Authorize]
        public async Task<ActionResult<ResponseModel>> AddLanguage(LanguageModel language)
        {
            language.LanguageId = 0;
            ResponseModel response = await _languageBLL.Add(language);

            return Ok(response);
        }
        [HttpPost("delete")]
        [Authorize]
        public async Task<ActionResult<ResponseModel>> DeleteLanguage([FromForm] int languageId)
        {
            ResponseModel response = await _languageBLL.Delete(languageId);

            return Ok(response);
        }
        [HttpPost("update")]
        [Authorize]
        public async Task<ActionResult<ResponseModel>> UdpateLanguage(LanguageModel language)
        {
            ResponseModel response = await _languageBLL.Update(language);

            return Ok(response);
        }
        [HttpPost("get")]
        [Authorize]
        public async Task<ActionResult<ResponseModel>> GetLanguage()
        {
            ResponseModel response = await _languageBLL.GetAllLanguage();

            return Ok(response);

        }
        [HttpPost("getbyid")]
        [Authorize]
        public async Task<ActionResult<ResponseModel>> GetLanguageById([FromForm] int languageId)
        {
            ResponseModel response = await _languageBLL.GetLanguageById(languageId);

            return Ok(response);

        }
    }
}