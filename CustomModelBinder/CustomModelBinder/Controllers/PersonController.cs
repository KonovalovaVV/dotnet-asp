using Microsoft.AspNetCore.Mvc;
using CustomModelBinder.Models;

namespace CustomModelBinder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController: ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Get(PersonViewModel person)
        {
            return new JsonResult(person);
        }
    }
}
