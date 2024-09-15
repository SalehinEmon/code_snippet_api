namespace CodeSnippetWeApi.Models
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; }
        public dynamic RequestedBody { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
    }
}
