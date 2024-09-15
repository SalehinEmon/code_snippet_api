using CodeSnippetWeApi.BLL;
using CodeSnippetWeApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeSnippetWeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        TopicBLL _topicBLL;

        public TopicController(TopicBLL topicBLL)
        {
            _topicBLL = topicBLL;
        }

        [HttpPost("add")]
        [Authorize]
        public async Task<ActionResult<ResponseModel>> AddTopic(TopicModel topic)
        {
            ResponseModel response = await _topicBLL.Add(topic);

            return Ok(response);
        }
        [HttpPost("delete")]
        [Authorize]
        public async Task<ActionResult<ResponseModel>> DeleteTopic([FromForm] int topicId)
        {
            ResponseModel response = await _topicBLL.Delete(topicId);

            return Ok(response);
        }
        [HttpPost("update")]
        [Authorize]
        public async Task<ActionResult<ResponseModel>> UdpateTopic(TopicModel topic)
        {
            ResponseModel response = await _topicBLL.Update(topic);

            return Ok(response);
        }
        [HttpPost("get")]
        [Authorize]
        public async Task<ActionResult<ResponseModel>> GetTopic()
        {
            ResponseModel response = await _topicBLL.Get();

            return Ok(response);

        }
        [HttpPost("getbyid")]
        [Authorize]
        public async Task<ActionResult<ResponseModel>> GetTopicById([FromForm] int topicId)
        {
            ResponseModel response = await _topicBLL.GetById(topicId);

            return Ok(response);

        }
    }
}
