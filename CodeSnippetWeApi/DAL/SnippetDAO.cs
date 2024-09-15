using CodeSnippetWeApi.Models;
using CodeSnippetWeApi.Models.EntityModel;
using Microsoft.EntityFrameworkCore;

namespace CodeSnippetWeApi.DAL
{
    public class SnippetDAO
    {
        SnippetDbContext _snippetDbContext;
        public SnippetDAO(SnippetDbContext snippetDbContext)
        {
            _snippetDbContext = snippetDbContext;
        }

        public async Task<ResponseModel> Add(SnippetModel snippet)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                int rowEffected = 0;
                await _snippetDbContext.Snippet.AddAsync(snippet);
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

        public async Task<ResponseModel> Delete(int snippetId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                SnippetModel? snippet = await _GetSnippetById(snippetId);
                int rowEffected = 0;
                if (snippet != null)
                {
                    _snippetDbContext.Snippet.Remove(snippet);
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

        public async Task<ResponseModel> Update(SnippetModel snippet)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                int rowEffected = 0;
                _snippetDbContext.Snippet.Update(snippet);
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

        public async Task<ResponseModel> GetById(int snippetId)
        {
            ResponseModel response = new ResponseModel();
            SnippetModel? snippet;
            try
            {
                snippet = await _GetSnippetById(snippetId);
                if (snippet != null)
                {
                    response.RequestedBody = snippet;
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
            List<SnippetModel> allSnippet = new List<SnippetModel>();
            try
            {
                allSnippet = await _snippetDbContext.Snippet.ToListAsync();
                response.RequestedBody = allSnippet;

                response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.InnerException.Message;
            }
            return response;

        }



        public async Task<ResponseModel> Search(int? languageId,
            int topicId, int frameworkId, string title)
        {
            ResponseModel response = new ResponseModel();
            List<SnippetModel> allSnippet = new List<SnippetModel>();
            try
            {
                languageId = languageId == 0 ? null : languageId;


                //allSnippet = await _snippetDbContext.Snippet.Where(snippet =>
                //snippet.LanguageId == languageId 
                //|| snippet.TopicId == topicId
                //|| snippet.FramewrokId == frameworkId
                //|| snippet.SnippetTitle.Contains(title)).ToListAsync();

                allSnippet = await _snippetDbContext.Snippet.Where(snippet =>
                (languageId == 0 || snippet.LanguageId == languageId) &&
                (topicId == 0 || snippet.TopicId == topicId) &&
                (frameworkId == 0 || snippet.FramewrokId == frameworkId) &&

                snippet.SnippetTitle.Contains(title)

                ).ToListAsync();





                response.RequestedBody = allSnippet;

                response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.InnerException.Message;
            }
            return response;

        }




        private async Task<SnippetModel?> _GetSnippetById(int snippetId)
        {
            SnippetModel? snippet = null;

            try
            {
                snippet = await _snippetDbContext.Snippet
                    .Where(s => s.SnippetId == snippetId)
                    .FirstOrDefaultAsync();


            }
            catch (Exception ex)
            {

            }

            return snippet;
        }

    }
}
