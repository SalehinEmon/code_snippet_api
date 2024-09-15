using System.ComponentModel.DataAnnotations;

namespace CodeSnippetWeApi.Models
{
    public class FrameworkModel
    {
        [Key]
        public long FrameworkId { get; set; }
        public  string FrameworkName { get; set; }
        public long LanguageId { get; set; }

    }
}
