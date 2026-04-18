using System.Net.Http.Json;
using System.Text.Json;
using MauiApp1.Model;

namespace MauiApp1.Services;

public class MonkeyService
{
    HttpClient httpClient;
    public MonkeyService()
    {
        this.httpClient = new HttpClient();
    }

    List<Monkey> monkeyList;
    public async Task<List<Monkey>> GetMonkeys()
    {
        if (monkeyList?.Count > 0)
            return monkeyList;

        var response = await httpClient.GetAsync("https://montemagno.com/monkeys.json");
        if (response.IsSuccessStatusCode)
        {
            // MonkeyContext.Default.ListMonkey
            monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();
        }

        // Offline
        // using var stream = await FileSystem.OpenAppPackageFileAsync("monkeydata.json");
        // using var reader = new StreamReader(stream);
        // var contents = await reader.ReadToEndAsync();
        // monkeyList = JsonSerializer.Deserialize(contents, MonkeyContext.Default.ListMonkey);
        
        return monkeyList;
    }
}