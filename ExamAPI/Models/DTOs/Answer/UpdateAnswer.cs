namespace ExamAPI.Models.DTOs.Answer;

public class UpdateAnswer
{
    public string Text { get; set; } = null!;
    public bool IsCorrect { get; set; }
}
