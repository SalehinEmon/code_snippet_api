using CodeSnippetWeApi.BLL;
using CodeSnippetWeApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeSnippetWeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrameworkController : ControllerBase
    {
        FramewrokBLL _framewrokBLL;
        public FrameworkController(FramewrokBLL framewrokBLL)
        {
            _framewrokBLL = framewrokBLL;
        }

        [HttpPost("add")]
        [Authorize]

        public async Task<ActionResult<ResponseModel>> AddFramework(FrameworkModel framework)
        {
            ResponseModel response = await _framewrokBLL.Add(framework);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPost("get")]
        [Authorize]
        public async Task<ActionResult<ResponseModel>> Get([FromForm] int frameworkId)
        {
            ResponseModel response = await _framewrokBLL.GetFrameworkById(frameworkId);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPost("getall")]
        [Authorize]

        public async Task<ActionResult<ResponseModel>> GetAll()
        {
            ResponseModel response = await _framewrokBLL.GetAllFramework();

            return Ok(response);
        }

        [HttpPost("update")]
        [Authorize]
        public async Task<ActionResult<ResponseModel>> Update(FrameworkModel framework)

        {
            ResponseModel response = await _framewrokBLL.Update(framework);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPost("delete")]
        [Authorize]
        public async Task<ActionResult<ResponseModel>> DeleteLanguage([FromForm] int frameworkId)
        {
            ResponseModel response = await _framewrokBLL.Delete(frameworkId);

            return Ok(response);
        }

    }
}
