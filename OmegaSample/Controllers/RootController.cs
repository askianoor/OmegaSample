using Microsoft.AspNetCore.Mvc;
using OmegaSample.Models;

namespace OmegaSample.Controllers
{
    [Route("/")]
    [ApiController]
    [ApiVersion("1.0")]
    public class RootController : ControllerBase
    {
        // GET the link of all other APIs
        [HttpGet(Name = nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var response = new RootResponse {
                Self = Link.To(nameof(GetRoot)),
                Info = Link.To(nameof(InfoController.GetInfo)),
                Rooms = Link.To(nameof(RoomsController.GetRoomsAsync)),
            };

            return Ok(response);
        }
    }
}