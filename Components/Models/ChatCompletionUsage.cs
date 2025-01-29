namespace Sklad.Components.Models;

public class ChatCompletionUsage
{
    public int PromtTokens { get; set; }
    public int CompletionTokens { get; set; }
    public int TotalTokens { get; set; }
}