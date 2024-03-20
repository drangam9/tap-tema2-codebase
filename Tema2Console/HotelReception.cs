using Tema2Console.Factory;

namespace Tema2Console
{
    public class HotelReception
    {
        private ILogger _logger;
        private IFileReader _fileReader;
        private IProcessorFactory _factory;
        private IOrderDeserializer _orderDeserializer;
        public HotelReception(ILogger logger, IFileReader fileReader, IProcessorFactory processorFactory, IOrderDeserializer orderDeserializer)
        {
            _logger = logger;
            _fileReader = fileReader;
            _factory = processorFactory;
            _orderDeserializer = orderDeserializer;
        }
        public decimal FinalPrice { get; set; }

        public void ProcessOrder()
        {
            _logger.Log("Start processing...");

            _logger.Log("Loading order from file...");
            var dataJson = _fileReader.GetOrderSource("./orders.json");

            _logger.Log("Deserializing Order object from json data...");
            var order = _orderDeserializer.Deserialize(dataJson);

            if (order == null)
            {
                _logger.Log("Order type not parsed successfully.");
                return;
            }

            var processor = _factory.Create(order);
            FinalPrice = processor.Process(order);

            _logger.Log("Rating completed.");
        }
    }
}
