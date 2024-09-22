using Microsoft.AspNetCore.Mvc;
using WebToDoListKlassMatt.Shared.Abstractions;

namespace WebToDoListKlassMatt.Shared.OutPutPort
{
    public class Outputport : ControllerBase, IOutputPort
    {
        public IActionResult InvalidRequest(string message)
        {
            return BadRequest(message);
        }

        public IActionResult InvalidRequest()
        {
            return BadRequest();
        }

        public IActionResult NotFound(string message)
        {
            return base.NotFound(message);
        }

        public IActionResult Success(object obj)
        {
            return Ok(obj);
        }

        public IActionResult Ok()
        {
            return Ok();
        }
    }
}
