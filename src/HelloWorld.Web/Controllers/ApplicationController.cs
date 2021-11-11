using Microsoft.AspNetCore.Mvc;
using Tnf.Runtime.Session;

namespace HelloWorld.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/application")]
    public class ApplicationController : TnfController
    {
        private readonly ITnfSession _tnfSession;

        public ApplicationController(ITnfSession tnfSession)
        {
            _tnfSession = tnfSession;
        }

        [HttpGet("name")]
        public IActionResult GetApplicationName()
        {
            return Ok("Hello World");
        }

        [HttpGet("userInfo")]
        public IActionResult SystemInfo()
        {
            return Ok(new
            {
                TOTVSTNFVersion = typeof(TnfController).Assembly.GetName().Version.ToString(),
                HelloWorldVersion = GetType().Assembly.GetName().Version.ToString()
        });
        }
    }
}
