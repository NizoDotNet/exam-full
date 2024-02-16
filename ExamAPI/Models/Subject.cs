using System.ComponentModel.DataAnnotations;

namespace ExamAPI.Models;

public class Subject
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Quastion> Quastions { get; set; }
}
