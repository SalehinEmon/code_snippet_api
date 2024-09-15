using System.ComponentModel.DataAnnotations;

namespace CodeSnippetWeApi.Models
{
    public class SnippetModel
    {
        [Key]
        public long SnippetId { get; set; }
        public string SnippetTitle { get; set; }
        public string SnippetBody { get; set; }
        public string SnippetSubject { get; set; }
        public long LanguageId { get; set; }
        public long FramewrokId { get; set; }
        public long TopicId { get; set; }


    }
}
