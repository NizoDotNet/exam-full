namespace ExamAPI.Models.DTOs.Answer;

public class AddAnswer
{
    public string Text { get; set; } = null!;
    public bool IsCorrect { get; set; } = false;
    public Guid QuastionId { get; set; }

}
