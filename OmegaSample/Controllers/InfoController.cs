using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OmegaSample.Infrastructure;
using OmegaSample.Models;

namespace OmegaSample.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class InfoController : ControllerBase
    {
        private readonly OfficeInfo _officeInfo;

        public InfoController(IOptions<OfficeInfo> officeInfoAccessor)
        {
            _officeInfo = officeInfoAccessor.Value;
        }

        [HttpGet(Name = nameof(GetInfo))]
        [ResponseCache(CacheProfileName = "Static")]
        [Etag]
        public IActionResult GetInfo()
        {
            _officeInfo.Href = Url.Link(nameof(GetInfo), null);

            if (!Request.GetEtagHandler().NoneMatch(_officeInfo))
            {
                return StatusCode(304, _officeInfo);
            }

            return Ok(_officeInfo);
        }
    }
}
