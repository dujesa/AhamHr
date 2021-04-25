using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AhamHr.Web.Controllers
{
    [Authorize]
    [Route("api/[Controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
    }
}
