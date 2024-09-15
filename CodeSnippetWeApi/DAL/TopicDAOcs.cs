using CodeSnippetWeApi.Models;
using CodeSnippetWeApi.Models.EntityModel;
using Microsoft.EntityFrameworkCore;

namespace CodeSnippetWeApi.DAL
{
    public class TopicDAO
    {
        SnippetDbContext _snippetDbContext;
        public TopicDAO(SnippetDbContext snippetDbContext)
        {
            _snippetDbContext = snippetDbContext;
        }

        public async Task<ResponseModel> Add(TopicModel topic)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                int rowEffected = 0;
                await _snippetDbContext.Topic.AddAsync(topic);
                rowEffected = await _snippetDbContext.SaveChangesAsync();
                if (rowEffected > 0)
                {
                    response.IsSuccess = true;

                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.InnerException.Message;
            }


            return response;
        }



        public async Task<ResponseModel> Delete(int topicId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                TopicModel? topic = await _GetTopicById(topicId);
                int rowEffected = 0;
                if (topic != null)
                {
                    _snippetDbContext.Topic.Remove(topic);
                    rowEffected = await _snippetDbContext.SaveChangesAsync();
                }

                if (rowEffected > 0)
                {
                    response.IsSuccess = true;

                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.InnerException.Message;
            }


            return response;

        }


        private async Task<TopicModel?> _GetTopicById(int topicId)
        {
            TopicModel? topic = null;

            try
            {
                topic = await _snippetDbContext.Topic
                    .Where(s => s.TopicId == topicId)
                    .FirstOrDefaultAsync();


            }
            catch (Exception ex)
            {

            }

            return topic;
        }



        public async Task<ResponseModel> Update(TopicModel topic)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                int rowEffected = 0;
                _snippetDbContext.Topic.Update(topic);
                rowEffected = await _snippetDbContext.SaveChangesAsync();
                if (rowEffected > 0)
                {
                    response.IsSuccess = true;

                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.InnerException.Message;
            }


            return response;

        }




        public async Task<ResponseModel> GetById(int topicId)
        {
            ResponseModel response = new ResponseModel();
            TopicModel? topic;
            try
            {
                topic = await _GetTopicById(topicId);
                if (topic != null)
                {
                    response.RequestedBody = topic;
                    response.IsSuccess = true;

                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;

            }

            return response;
        }

        public async Task<ResponseModel> Get()
        {
            ResponseModel response = new ResponseModel();
            List<TopicModel> allTopic = new List<TopicModel>();
            try
            {
                allTopic = await _snippetDbContext.Topic.ToListAsync();
                response.RequestedBody = allTopic;

                response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.InnerException.Message;
            }
            return response;

        }



    }
}
