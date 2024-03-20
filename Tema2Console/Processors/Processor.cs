using Tema2Console.Models;

namespace Tema2Console.Processors
{
    public abstract class Processor
    {
        protected ILogger logger;
        public Processor(ILogger logger)
        {
            this.logger = logger;
        }
        public abstract decimal Process(Order order);
    }
}
