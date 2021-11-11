using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Web.Controllers
{
    [Route("/statusz")]
    public class StatusZController : TnfController
    {
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Get()
        {           
            return CreateResponseOnGet("ok");
        }       
    }
}
