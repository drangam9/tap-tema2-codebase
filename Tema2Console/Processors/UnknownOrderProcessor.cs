using Tema2Console.Models;

namespace Tema2Console.Processors
{
    internal class UnknownOrderProcessor : Processor
    {
        public UnknownOrderProcessor(ILogger logger) : base(logger)
        {
        }

        public override decimal Process(Order order)
        {
            logger.Log("Unknown order type.");
            return 0;
        }
    }
}
