using System.Text.Json;

namespace lab1;

public class JsonDataProvider : IDataProvider
{
    public List<Product> LoadFromFile(string path)
    {
        if (File.Exists(path))
        {
            var result = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(path));
            return result!;
        }
        return new  List<Product>();
    }

    public void LoadToFile(string path, List<Product> products)
    {
        var options = new JsonSerializerOptions() { WriteIndented = true };
        using (var fileStream = File.Create(path))
        {
            JsonSerializer.Serialize(fileStream, products, options);
        }
    }
}