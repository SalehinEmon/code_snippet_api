using CodeSnippetWeApi.BLL;
using CodeSnippetWeApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeSnippetWeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnippetController : ControllerBase
    {
        SnippetBLL _snippetBLL;
        public SnippetController(SnippetBLL snippetBLL)
        {
            _snippetBLL = snippetBLL;
        }
        [HttpPost("add")]
        [Authorize]
        public async Task<ActionResult<ResponseModel>> AddSnippet(SnippetModel snippet)
        {
            ResponseModel response = await _snippetBLL.Add(snippet);

            return Ok(response);
        }
        [HttpPost("delete")]
        [Authorize]
        public async Task<ActionResult<ResponseModel>> DeleteSnippet([FromForm] int snippetId)
        {
            ResponseModel response = await _snippetBLL.Delete(snippetId);

            return Ok(response);
        }
        [HttpPost("update")]
        [Authorize]
        public async Task<ActionResult<ResponseModel>> UdpateSnippet(SnippetModel snippet)
        {
            ResponseModel response = await _snippetBLL.Update(snippet);

            return Ok(response);
        }
        [HttpPost("get")]
        [Authorize]
        public async Task<ActionResult<ResponseModel>> GetSnippet()
        {
            ResponseModel response = await _snippetBLL.Get();

            return Ok(response);

        }
        [HttpPost("getbyid")]
        [Authorize]
        public async Task<ActionResult<ResponseModel>> GetSnippetById([FromForm] int snippetId)
        {
            ResponseModel response = await _snippetBLL.GetById(snippetId);

            return Ok(response);

        }

        [HttpPost("search")]
        [Authorize]
        public async Task<ActionResult<ResponseModel>> Search([FromForm] int languageId,
            [FromForm] int topicId, [FromForm] int frameworkId, [FromForm] string? title)
        {
            ResponseModel response = await _snippetBLL.
                Search(languageId, topicId, frameworkId, title ?? "");

            return Ok(response);

        }
    }
}
