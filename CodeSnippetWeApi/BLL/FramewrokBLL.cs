using CodeSnippetWeApi.DAL;
using CodeSnippetWeApi.Models;
using CodeSnippetWeApi.Models.EntityModel;

namespace CodeSnippetWeApi.BLL
{
    public class FramewrokBLL
    {
        private readonly FrameworkDAO _frameworkDAO;
        public FramewrokBLL(FrameworkDAO frameworkDAO)
        {
            _frameworkDAO = frameworkDAO;
        }

        public async Task<ResponseModel> Add(FrameworkModel framework)
        {
            return await _frameworkDAO.Add(framework);
        }

        public async Task<ResponseModel> Update(FrameworkModel framework)
        {
            return await _frameworkDAO.Update(framework);
        }



        public async Task<ResponseModel> Delete(int frameworkId)
        {
            return await _frameworkDAO.Delete(frameworkId);
        }
        public async Task<ResponseModel> GetFrameworkById(int frameworkId)
        {
            return await _frameworkDAO.GetFrameworkById(frameworkId);

        }

        public async Task<ResponseModel> GetAllFramework()
        {
            return await _frameworkDAO.GetAllFramework();

        }
    }
}
