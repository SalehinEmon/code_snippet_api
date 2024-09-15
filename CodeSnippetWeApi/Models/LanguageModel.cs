using System.ComponentModel.DataAnnotations;

namespace CodeSnippetWeApi.Models
{
    public class LanguageModel
    {
        [Key]
        public long LanguageId { get; set; }
        public string LanguageName { get; set; }
   
    }
}
