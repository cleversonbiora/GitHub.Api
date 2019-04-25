using FluentValidation;
using GitHub.Domain.Commands.Sample;
using GitHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHub.Service.Validators
{
    class InsertSampleValidator : AbstractValidator<InsertSampleCommand>
    {
        public InsertSampleValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Is necessary to inform the CPF.");
        }
    }
}
