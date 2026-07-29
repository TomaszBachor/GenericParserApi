using GenericParserApi.Models;
using System.ComponentModel.DataAnnotations;

namespace GenericParserApi.DTO
{
    public class ParseRequestDto
    {
        [Required]
        public ContentType Type { get; set; }
        [Required]
        public string Content { get; set; } = string.Empty;
    }
}
