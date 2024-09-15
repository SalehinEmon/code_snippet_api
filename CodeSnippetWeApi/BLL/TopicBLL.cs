using CodeSnippetWeApi.DAL;
using CodeSnippetWeApi.Models;

namespace CodeSnippetWeApi.BLL
{
    public class TopicBLL
    {
        TopicDAO _topicDAO;
        public TopicBLL(TopicDAO topicDAO)
        {
            _topicDAO = topicDAO;
        }

        public async Task<ResponseModel> Add(TopicModel topic)
        {
            return await _topicDAO.Add(topic);
        }
        public async Task<ResponseModel> Delete(int topicId)
        {
            return await _topicDAO.Delete(topicId);
        }

        public async Task<ResponseModel> Update(TopicModel topic)
        {
            return await _topicDAO.Update(topic);

        }
        public async Task<ResponseModel> GetById(int topicId)
        {
            return await _topicDAO.GetById(topicId);

        }
        public async Task<ResponseModel> Get()
        {
            return await _topicDAO.Get();

        }

    }
}
