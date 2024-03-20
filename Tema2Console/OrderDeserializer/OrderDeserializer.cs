using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Tema2Console.Models;

namespace Tema2Console
{
    public class OrderDeserializer : IOrderDeserializer
    {
        public Order Deserialize(string orderSource)
        {
            return JsonConvert.DeserializeObject<Order>(orderSource, new StringEnumConverter());
        }

    }
}
