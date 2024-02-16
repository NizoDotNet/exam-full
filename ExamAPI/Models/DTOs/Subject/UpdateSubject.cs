using ExamAPI.Models.DTOs.Quastion;

namespace ExamAPI.Models.DTOs.Subject;

public class UpdateSubject
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public IList<UpdateQuastion> Quastions { get; set; }
}
