using CodeSnippetWeApi.Models;
using CodeSnippetWeApi.Models.EntityModel;
using Microsoft.EntityFrameworkCore;


namespace CodeSnippetWeApi.DAL
{
    public class LanguageDAO
    {
        private readonly SnippetDbContext _snippetDbContext;
        public LanguageDAO(SnippetDbContext snippetDbContext)
        {
            _snippetDbContext = snippetDbContext;
        }

        public async Task<ResponseModel> Add(LanguageModel language)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                int rowEffected = 0;
                await _snippetDbContext.Language.AddAsync(language);
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


        public async Task<ResponseModel> Delete(int languageId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                LanguageModel? language = await _GetLanguageById(languageId);
                int rowEffected = 0;
                if (language != null)
                {
                    _snippetDbContext.Language.Remove(language);
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


        public async Task<ResponseModel> Update(LanguageModel language)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                int rowEffected = 0;

                _snippetDbContext.Language.Update(language);

                rowEffected = await _snippetDbContext.SaveChangesAsync();
                if (rowEffected > 0)
                {
                    response.IsSuccess = true;

                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }


            return response;

        }


        public async Task<ResponseModel> GetLanguageById(long languageId)
        {
            ResponseModel response = new ResponseModel();
            LanguageModel? language;
            try
            {
                language = await _GetLanguageById(languageId);
                response.RequestedBody = language;
                response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;

            }

            return response;
        }

        public async Task<ResponseModel> GetAllLanguage()
        {
            ResponseModel response = new ResponseModel();
            List<LanguageModel> allLanguages = new List<LanguageModel>();
            try
            {
                allLanguages = await _snippetDbContext.Language.ToListAsync();
                response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.InnerException.Message;
            }
            response.RequestedBody = allLanguages;
            return response;

        }


        private async Task<LanguageModel?> _GetLanguageById(long languageId)
        {
            LanguageModel? language = null;

            try
            {
                language = await _snippetDbContext.Language
                    .Where(l => l.LanguageId == languageId)
                    .FirstOrDefaultAsync();


            }
            catch (Exception ex)
            {

            }

            return language;
        }



    }
}
