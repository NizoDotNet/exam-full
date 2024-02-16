using ExamAPI.Models.DTOs.Quastion;

namespace ExamAPI.Models.DTOs.Subject;

public class SubjectDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<QuastionDto> Quastions { get; set; }
}

