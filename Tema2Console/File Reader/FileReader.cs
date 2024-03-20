namespace Tema2Console
{
    public class FileReader : IFileReader
    {
        public string GetOrderSource(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
