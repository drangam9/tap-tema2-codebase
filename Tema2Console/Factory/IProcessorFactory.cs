using Tema2Console.Models;
using Tema2Console.Processors;

namespace Tema2Console.Factory
{
    public interface IProcessorFactory
    {
        Processor Create(Order order);
    }
}
