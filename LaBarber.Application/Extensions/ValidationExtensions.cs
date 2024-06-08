using FluentValidation;
using System.Text.RegularExpressions;

namespace LaBarber.Application.Extensions
{
    public static class ValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> ZipCode<T>(this IRuleBuilder<T, string> ruleBuilder, bool formatted)
        {
            var regex = formatted
                        ? new Regex(@"\A\d{5}-\d{3}$")
                        : new Regex(@"\A\d{8}$");

            return ruleBuilder
                .NotNull()
                .Must((value) => regex.IsMatch(value?.ToString() ?? ""))
                .WithMessage("CEP inválido.");
        }

        public static IRuleBuilderOptions<T, string> StateAcronym<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var regex = new Regex(@"\A([A-Z]{2}|([a-z]{2}))$");
            return ruleBuilder
                .NotNull()
                .Must((value) => regex.IsMatch(value?.ToString() ?? ""))
                .WithMessage("Estado no formato inválido.");
        }
    }
}
