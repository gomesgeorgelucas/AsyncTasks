Console.WriteLine("Fetching data: ");

var task1 = Task.Run(WeatherService.GetWeatherAsync);
var task2 = Task.Run(CityListReader.ReadCityListAsync);

await Task.WhenAll(task1, task2);

Console.WriteLine($"Tempo: {task1.Result}");
Console.WriteLine("Cidades:");
task2.Result.ForEach(x => Console.WriteLine(x));

class WeatherController
{
    public static string FetchWeatherData()
    {
        var weatherData =  "Nublado, 32, 45%"; ;
        Thread.Sleep(2000);
        return weatherData;
    }
}

class CityListReaderController
{
    public static List<string> FetchCityList()
    {
        Thread.Sleep(7000);
        return new List<string>() { "Manaus", "Boa Vista", "Parintins", "Maceió" };
    }
}

class WeatherService
{
    public static async Task<string> GetWeatherAsync()
    {
        return await Task.Run(WeatherController.FetchWeatherData);
    }
}

class CityListReader
{
    public static async Task<List<string>> ReadCityListAsync()
    {
        return await Task.Run(CityListReaderController.FetchCityList);
    }
}
