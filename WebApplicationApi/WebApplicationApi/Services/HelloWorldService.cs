namespace WebApplicationApi.Services
{
    public class HelloWorldService : IHelloWorldService
    {
        public string HelloWorld()
        {
            return "Hello, World!";
        }
    }
}

public interface IHelloWorldService
{
    string HelloWorld();
}