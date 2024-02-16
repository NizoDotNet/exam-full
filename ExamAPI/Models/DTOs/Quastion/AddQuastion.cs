namespace ExamAPI.Models.DTOs.Quastion;

public class AddQuastion
{
    public string Text { get; set; } = null!;

    public Guid SubjectId { get; set; }
}
