namespace Sklad.Components.Models;

public class OpenAiService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    
    public OpenAiService(HttpClient httpClient, string apiKey)
    {
        _httpClient = httpClient;
        _apiKey = apiKey;

        if (!_httpClient.DefaultRequestHeaders.Contains("Authorization"))
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
        }
    }


    public async Task<string> GetAnswerAsync(string userPrompt)
    {
        try
        {
            
            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "system", content = "Du bist sehr gut" },
                    new { role = "user", content = userPrompt },
                },
                max_tokens = 100,
                temperature = 0.7
            };

            var response = await _httpClient.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", requestBody);
            Console.WriteLine($"HTTP Status Code: {response.StatusCode}");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error Content: {errorContent}");
                return "Es hat nicht geklappt, Antwort von OpenAI zu bekommen";
            }


            var jsonResponse = await response.Content.ReadFromJsonAsync<ChatCompletionResponse>();
            var answer = jsonResponse?.Choices.FirstOrDefault()?.Message.Content.Trim();

            return string.IsNullOrWhiteSpace(answer) ? "keine Antwort" : answer;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unhandled exception in GetAnswerAsync: {ex.Message}");
            return "Fehler beim Abrufen der Antwort";
        }
    }

}