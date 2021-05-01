using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace fluentvalidation_inheritance.Dto
{
    public sealed class Derived1Dto : BaseDto
    {
        public bool IsNegative { get; set; }

        public string KnxAddress { get; set; }
    }

    // public class Derived1DtoValidator : AbstractValidator<Derived1Dto>
    public class Derived1DtoValidator : BaseDtoAbstractValidator<Derived1Dto>
    {
        public Derived1DtoValidator(KnxAddressValidator<Derived1Dto> knxAddressValidator)
        {
            RuleFor(_ => _.Number)
                .LessThan(0)
                .When(_ => _.IsNegative)
                ;

            RuleFor(_ => _.KnxAddress)
                .SetValidator(knxAddressValidator)
                ;
        }
    }
}
