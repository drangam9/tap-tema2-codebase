using Tema2Console.Models;

namespace Tema2Console
{
    public interface IOrderDeserializer
    {
        Order Deserialize(string orderSource);
    }
}
