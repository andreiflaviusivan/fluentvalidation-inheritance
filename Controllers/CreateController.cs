using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fluentvalidation_inheritance.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace fluentvalidation_inheritance.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateController : ControllerBase
    {
        public CreateController()
        {
        }

        [HttpPost("derived1")]
        public IActionResult CreateDerived1([FromBody] Derived1Dto derived1)
        {
            if (ModelState.IsValid)
            {
                derived1.Id = Guid.NewGuid();

                return Ok(derived1);
            }

            return BadRequest();
        }

        [HttpPost("derived2")]
        public IActionResult CreateDerived2([FromBody] Derived2Dto derived2)
        {
            if (ModelState.IsValid)
            {
                derived2.Id = Guid.NewGuid();

                return Ok(derived2);
            }

            return BadRequest();
        }
    }
}
