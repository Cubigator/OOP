namespace lab1;

public interface IDataProvider
{
    List<Product> LoadFromFile(string path);
    void LoadToFile(string path, List<Product> products);
}