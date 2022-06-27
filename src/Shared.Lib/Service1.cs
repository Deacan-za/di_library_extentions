namespace Shared.Lib
{
  public class Service1 : IService1
  {
    private readonly SharedConfig _config;

    public Service1(SharedConfig config)
    {
      _config = config;
    }

    public string Service1Method()
    {
      return "This is service1";
    }

    public SharedConfig Service1Config()
    {
      return _config;
    }
  }
}