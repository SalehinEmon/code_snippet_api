using CodeSnippetWeApi.Models;
using CodeSnippetWeApi.Models.EntityModel;
using Microsoft.EntityFrameworkCore;

namespace CodeSnippetWeApi.DAL
{
    public class FrameworkDAO
    {
        private readonly SnippetDbContext _snippetDbContext;
        public FrameworkDAO(SnippetDbContext snippetDbContext)
        {
            _snippetDbContext = snippetDbContext;
        }
        public async Task<ResponseModel> Add(FrameworkModel framework)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                int rowEffected = 0;
                await _snippetDbContext.Framework.AddAsync(framework);
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
                // string errorMessage = ex.Message;

            }


            return response;
        }

        public async Task<ResponseModel> Delete(int frameworkId)
        {
            ResponseModel response = new ResponseModel();
            FrameworkModel? framework = await _GetFrameworkById(frameworkId);

            try
            {
                int rowEffected = 0;
                if (framework != null)
                {
                    _snippetDbContext.Framework.Remove(framework);
                    rowEffected = await _snippetDbContext.SaveChangesAsync();
                }
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.InnerException.Message;
            }


            return response;
        }


        public async Task<ResponseModel> Update(FrameworkModel? framework)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                if (framework != null)
                {
                    int rowEffected = 0;
                    _snippetDbContext.Framework.Update(framework);
                    rowEffected = await _snippetDbContext.SaveChangesAsync();
                    if (rowEffected > 0)
                    {
                        response.IsSuccess = true;
                    }


                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.InnerException.Message;
            }


            return response;
        }

        public async Task<ResponseModel> GetAllFramework()
        {
            ResponseModel response = new();
            try
            {
                List<FrameworkModel> frameworks = await _snippetDbContext.Framework.ToListAsync();
                   
              
                    response.IsSuccess = true;
                    response.RequestedBody = frameworks;
                
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.InnerException.Message;

            }

            return response;

        }


        public async Task<ResponseModel> GetFrameworkById(int frameworkId)
        {
            ResponseModel response = new();
            try
            {
                FrameworkModel? framework = await _snippetDbContext.Framework
                    .Where(f => f.FrameworkId == frameworkId)
                    .FirstOrDefaultAsync();
                if (framework != null)
                {
                    response.IsSuccess = true;
                    response.RequestedBody = framework;
                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.InnerException.Message;

            }

            return response;

        }

        private async Task<FrameworkModel?> _GetFrameworkById(int frameworkId)
        {
            return await _snippetDbContext.Framework
                .Where(f => f.FrameworkId == frameworkId)
                .FirstOrDefaultAsync();
        }
    }
}
