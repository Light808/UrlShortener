using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Models
{
    public class ShortenRequest
    {
        public string OriginalUrl { get; set; } = string.Empty;
    }
}
