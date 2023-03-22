using Microsoft.AspNetCore.Mvc;
using Shared.Lib;

namespace Test.ServiceCollection.Api.Controllers;

[Route("test")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly IService1 _service1;

    public TestController(IService1 service1)
    {
        _service1 = service1;
    }

    [HttpGet]
    [Route("getservice1")]
    public async Task<IActionResult> GetService1()
    {
        var response = await _service1.Service1MethodAsync();
        return Ok(response);
    }

    [HttpGet]
    [Route("getconfig")]
    public async Task<IActionResult> GetConfig()
    {
        var config = await _service1.Service1ConfigAsync();

        return Ok(config);
    }
}
