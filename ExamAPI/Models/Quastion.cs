using System.ComponentModel.DataAnnotations;

namespace ExamAPI.Models;

public class Quastion
{
    public Guid Id { get; set; }
    public string Text { get; set; } = null!;
    public ICollection<Answer> Answers { get; set; }
    public Subject Subject { get; set; }
    public Guid SubjectId { get; set; }
}
