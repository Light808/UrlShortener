using FluentValidation;
using UrlShortener.Models;

namespace UrlShortener.Validators
{
    public class ShortenRequestValidator : AbstractValidator<ShortenRequest>
    {
        public ShortenRequestValidator()
        {
            RuleFor(x => x.OriginalUrl)
                .NotEmpty().WithMessage("URL cannot be empty.")
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
                    .WithMessage("Invalid URL.")
                .Must(url => !(url?.Contains("localhost") ?? false))
                    .WithMessage("Do not shorten URL localhost.")
                .Must(url => !(url?.Contains("127.0.0.1") ?? false))
                    .WithMessage("Do not shorten URL localhost (127.0.0.1).");
        }
    }
}
