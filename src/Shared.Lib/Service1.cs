using System.Threading.Tasks;

namespace Shared.Lib
{
    public class Service1 : IService1
    {
        private readonly SharedConfig _config;

        public Service1(SharedConfig config)
        {
            _config = config;
        }

        public async Task<string> Service1MethodAsync()
        {
            return await Task.FromResult("This is service1");
        }

        public async Task<SharedConfig> Service1ConfigAsync()
        {
            return await Task.FromResult(_config);
        }
    }
}