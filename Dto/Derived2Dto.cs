using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace fluentvalidation_inheritance.Dto
{
    public sealed class Derived2Dto : BaseDto
    {
        public float Temperature { get; set; }

        public string KnxAddress { get; set; }

        public string KnxAddress2 { get; set; }
    }

    // public class Derived2DtoValidator : BaseDtoAbstractValidator<Derived2Dto>
    // {
    //     public Derived2DtoValidator(KnxAddressValidator<Derived2Dto> knxAddressValidator)
    //     {
    //         RuleFor(_ => _.Temperature)
    //             .ExclusiveBetween(10F, 30F)
    //             ;

    //         RuleFor(_ => _.KnxAddress)
    //             .SetValidator(knxAddressValidator)
    //             ;
    //     }
    // }

    public class Derived2DtoValidator : AbstractValidator<Derived2Dto>
    {
        public Derived2DtoValidator(BaseDtoValidator baseValidator, KnxAddressValidator<Derived2Dto> knxAddressValidator)
        {
            RuleFor(o => o)
                .SetValidator(baseValidator)
                ;

            RuleFor(_ => _.Temperature)
                .ExclusiveBetween(10F, 30F)
                ;

            RuleFor(_ => _.KnxAddress)
                .SetValidator(knxAddressValidator)
                ;

             RuleFor(_ => _.KnxAddress2)
                .SetValidator(knxAddressValidator)
                ;
        }
    }
}
