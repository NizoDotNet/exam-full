using System.ComponentModel.DataAnnotations;

namespace ExamAPI.Models;

public class Answer
{
    public Guid Id { get; set; }
    public string Text { get; set; } = null!;
    public bool IsCorrect { get; set; } = false;
    public Quastion Quastion { get; set; } = null!;
    public Guid QuastionId { get; set; }
}
