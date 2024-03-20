using Tema2Console.Models;
using Tema2Console.Processors;

namespace Tema2Console.Factory
{
    public class ProcessorFactory : IProcessorFactory
    {
        public ILogger _logger;
        public ProcessorFactory(ILogger logger)
        {
            _logger = logger;
        }
        public Processor Create(Order order)
        {
            switch (order.Type)
            {
                case OrderType.Room:
                    return new RoomOrderProcessor(_logger);


                case OrderType.Product:
                    return new ProductOrderProcessor(_logger);

                case OrderType.Breakfast:
                    return new BreakfastOrderProcessor(_logger);
                default:
                    return new UnknownOrderProcessor(_logger);
            }

        }
    }
}
