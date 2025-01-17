using System.Text.Json;
using System.Text;

namespace Services;

public class AIService
{
    private const string API_KEY_PATH = "../Services/AISettings/aisettings.json";
    private const string SYSTEM_CONTENT_PATH = "../Services/AISettings/systemContent.json";
    private string LoadSystemContent(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"Die Datei {filePath} wurde nicht gefunden.");

        string jsonContent = File.ReadAllText(filePath);
        var jsonObject = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonContent);
        return jsonObject?["SystemRoleContent"] ?? throw new Exception("SystemRoleContent nicht in der JSON-Datei gefunden.");
    }

    private string LoadApiKey(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"Die Datei {filePath} wurde nicht gefunden.");

        string jsonContent = File.ReadAllText(filePath);
        var jsonObject = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(jsonContent);
        return jsonObject?["OpenAI"]?["ApiKey"] ?? throw new Exception("API-Key nicht in der JSON-Datei gefunden.");
    }

    public async Task<string?> CallOpenAIAsync(string prompt)
    {
        string apiKey = LoadApiKey(API_KEY_PATH);
        string systemContent = LoadSystemContent(SYSTEM_CONTENT_PATH);

        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
        var requestBody = new
        {
            model = "gpt-3.5-turbo",
            messages = new[]
            {
                new { role = "system", content = systemContent },
                new { role = "user", content = prompt }
            },
            max_tokens = 250,
            temperature = 0.7
        };

        string jsonBody = JsonSerializer.Serialize(requestBody);

        var requestContent = new StringContent(jsonBody, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/chat/completions", requestContent);

        if (!response.IsSuccessStatusCode)
        {
            string errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"Fehler bei der API-Anfrage: {response.StatusCode} - {errorContent}");
        }

        string responseContent = await response.Content.ReadAsStringAsync();
        using var jsonDoc = JsonDocument.Parse(responseContent);
        var aiResponse = jsonDoc.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString();

        if (aiResponse != null)
        {
            return aiResponse.Trim();
        }
        return null;
    }
}
