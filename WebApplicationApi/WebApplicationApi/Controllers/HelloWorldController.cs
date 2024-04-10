using Microsoft.AspNetCore.Mvc;

namespace WebApplicationApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        IHelloWorldService helloWorldService;

        public HelloWorldController(IHelloWorldService helloWorldService) 
        {
            this.helloWorldService = helloWorldService;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            return Ok(helloWorldService.HelloWorld());
        }
    }
}
