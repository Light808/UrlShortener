using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Models
{
    public class ShortenRequest
    {   
        [Required]
        [Url]
        public string OriginalUrl { get; set; } = string.Empty;
    }
}
