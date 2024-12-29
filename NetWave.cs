using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public static class NetWave
{
    private static readonly HttpClient _httpClient = new HttpClient();

    private static void Log(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}");
        Console.ResetColor();
    }

    public static async Task<T?> GetAsync<T>(string url) where T : class
    {
        Log($"GET Request to: {url}", ConsoleColor.Cyan);

        try
        {
            var response = await _httpClient.GetAsync(url);
            Log($"Response Status: {response.StatusCode}", ConsoleColor.Green);

            var content = await response.Content.ReadAsStringAsync();
            Log($"Response Content: {content}", ConsoleColor.Yellow);

            return JsonSerializer.Deserialize<T>(content);
        }
        catch (Exception ex)
        {
            Log($"GET Error: {ex.Message}", ConsoleColor.Red);
            return default;
        }
    }

    public static async Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest body)
        where TRequest : class
        where TResponse : class
    {
        Log($"POST Request to: {url}", ConsoleColor.Cyan);

        try
        {
            var json = JsonSerializer.Serialize(body);
            Log($"Request Body: {json}", ConsoleColor.Magenta);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);

            Log($"Response Status: {response.StatusCode}", ConsoleColor.Green);
            var responseContent = await response.Content.ReadAsStringAsync();
            Log($"Response Content: {responseContent}", ConsoleColor.Yellow);

            return JsonSerializer.Deserialize<TResponse>(responseContent);
        }
        catch (Exception ex)
        {
            Log($"POST Error: {ex.Message}", ConsoleColor.Red);
            return default;
        }
    }

    public static void AddDefaultHeader(string key, string value)
    {
        if (!_httpClient.DefaultRequestHeaders.Contains(key))
        {
            _httpClient.DefaultRequestHeaders.Add(key, value);
            Log($"Header Added: {key} = {value}", ConsoleColor.Blue);
        }
    }
}
