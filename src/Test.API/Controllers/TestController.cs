using System.Threading.Tasks;
using System.Web.Http;
using Shared.Lib;

namespace Test.API.Controllers
{

    [RoutePrefix("test")]
    public class TestController : ApiController
    {
        private readonly IService1 _service1;

        public TestController(IService1 service1)
        {
            _service1 = service1;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetService1()
        {
            var response = await _service1.Service1MethodAsync();
            return Ok(response);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetConfig()
        {
            var config = await _service1.Service1ConfigAsync();

            return Ok(config);
        }
    }
}
