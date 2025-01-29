namespace Sklad.Components.Models;

public class ChatCompletionChoice
{
    public int Index { get; set; }
    public ChatCompletionMessage Message { get; set; }
    public string FinishREason { get; set; }
}