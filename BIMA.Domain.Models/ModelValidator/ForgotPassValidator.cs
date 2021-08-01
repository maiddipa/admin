using BIMA.Domain.Models.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BIMA.Domain.Models.ModelValidator
{
    public class ForgotPassValidator : AbstractValidator<ForgotPasswordModel>
    {
        public ForgotPassValidator()
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty().WithMessage("Please insert a valid email address.").MaximumLength(35).WithMessage("Max input lenght is 35").Custom((e, context) => { if (e.Contains("<") || e.Contains(">") || e.Contains("'") || e.Contains("=")) { context.AddFailure("Invalid input, should not contain <, >, ', ="); } });
        }
    }

}
