using FluentValidation;
using UrlShortener.Models;

namespace UrlShortener.Validators
{
    public class ShortenRequestValidator : AbstractValidator<ShortenRequest>
    {
        public ShortenRequestValidator()
        {
            RuleFor(x => x.OriginalUrl)
            .NotEmpty().WithMessage("URL must not be empty.")
            .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
                .WithMessage("Invalid URL format.")
            .Must(url => !(url?.Contains("localhost") ?? false))
                .WithMessage("Shortening localhost URLs is not allowed.")
            .Must(url => !(url?.Contains("127.0.0.1") ?? false))
                .WithMessage("Shortening localhost URLs (127.0.0.1) is not allowed.");
        }
    }
}
