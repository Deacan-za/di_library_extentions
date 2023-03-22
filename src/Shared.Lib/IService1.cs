using System.Threading.Tasks;

namespace Shared.Lib
{
    public interface IService1
    {
        Task<string> Service1MethodAsync();

        Task<SharedConfig> Service1ConfigAsync();
    }
}