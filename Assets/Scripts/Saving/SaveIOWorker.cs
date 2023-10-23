using System.IO;

public interface IIOWorker
{
    public void Write(string text, string fileName);
    public string Read(string fileName);
}

public class LocalIOWorker : IIOWorker
{
    public void Write(string text, string fileName)
    {
        File.WriteAllText(fileName, text); 
    }

    public string Read(string fileName)
    {
        return File.ReadAllText(fileName);
    }
}
