using CodeSnippetWeApi.DAL;
using CodeSnippetWeApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeSnippetWeApi.BLL
{
    public class SnippetBLL
    {
        SnippetDAO _snippetDAO;
        public SnippetBLL(SnippetDAO snippetDAO)
        {
            _snippetDAO = snippetDAO; ;
        }
        public async Task<ResponseModel> Add(SnippetModel snippet)
        {
            return await _snippetDAO.Add(snippet);

        }
        public async Task<ResponseModel> Delete(int snippetId)
        {
            return await _snippetDAO.Delete(snippetId);
        }
        public async Task<ResponseModel> Update(SnippetModel snippet)
        {
            return await _snippetDAO.Update(snippet);
        }
        public async Task<ResponseModel> GetById(int snippetId)
        {
            return await _snippetDAO.GetById(snippetId);
        }

        public async Task<ResponseModel> Search(int languageId,
            int topicId, int frameworkId, string title)
        {
            return await _snippetDAO.Search(languageId, topicId, 
                frameworkId, title);
        }


        public async Task<ResponseModel> Get()
        {
            return await _snippetDAO.Get();
        }
    }
}
