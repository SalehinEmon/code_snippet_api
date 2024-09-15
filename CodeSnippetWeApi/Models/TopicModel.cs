using System.ComponentModel.DataAnnotations;

namespace CodeSnippetWeApi.Models
{
    public class TopicModel
    {
        [Key]
        public long TopicId { get; set; }
        public string TopicName { get; set; }
    }
}
