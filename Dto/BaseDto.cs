using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace fluentvalidation_inheritance.Dto
{
    public class BaseDto
    {
        public int Number { get; set; }

        public Guid Id { get; set; }
    }

    public class BaseDtoValidator : AbstractValidator<BaseDto>
    {
        public BaseDtoValidator()
        {
            RuleFor(_ => _.Number)
                .GreaterThan(18)
                ;

            RuleFor(_ => _.Id)
                .Empty()
                ;
        }
    }

    public class BaseDtoAbstractValidator<TDto> : AbstractValidator<TDto>
        where TDto : BaseDto
    {
        public BaseDtoAbstractValidator()
        {
            RuleFor(_ => _.Number)
                .GreaterThan(18)
                ;

            RuleFor(_ => _.Id)
                .Empty()
                ;
        }
    }

    public class KnxAddressValidator<TDto> : PropertyValidator<TDto, string>
        where TDto : BaseDto
    {
        private static Regex _regex = new Regex(@"^\d+/\d+/\d+$");

        public override string Name => "KnxAddressValidator";

        public KnxAddressValidator()
        {
        }

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return "Supplied string is not a valid KNX group address eg. 1/1/0";
        }

        public override bool IsValid(ValidationContext<TDto> context, string value)
        {
            return _regex.IsMatch(value);
        }
    }
}
