using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Web.Controllers
{
    [Route("/healthz")]
    public class HealthZController : TnfController
    {
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Get()
        {           
            return CreateResponseOnGet("ok");
        }       
    }
}
