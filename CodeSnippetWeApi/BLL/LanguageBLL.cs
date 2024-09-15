using CodeSnippetWeApi.DAL;
using CodeSnippetWeApi.Models;

namespace CodeSnippetWeApi.BLL
{
    public class LanguageBLL
    {
        LanguageDAO _languageDAO;
        public LanguageBLL(LanguageDAO languageDAO)
        {
            _languageDAO = languageDAO;
        }

        public async Task<ResponseModel> Add(LanguageModel language)
        {
            return await _languageDAO.Add(language);
        }
        public async Task<ResponseModel> Delete(int languageId)
        {
            return await _languageDAO.Delete(languageId);
        }
        public async Task<ResponseModel> Update(LanguageModel language)
        {
            return await _languageDAO.Update(language);

        }

        public async Task<ResponseModel> GetLanguageById(int languageId)
        {
            return await _languageDAO.GetLanguageById(languageId);

        }
        public async Task<ResponseModel> GetAllLanguage()
        {
            return await _languageDAO.GetAllLanguage();

        }
    }
}
