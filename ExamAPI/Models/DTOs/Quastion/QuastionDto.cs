using ExamAPI.Models.DTOs.Answer;

namespace ExamAPI.Models.DTOs.Quastion;

public class QuastionDto
{
    public Guid Id { get; set; }
    public string Text { get; set; } = null!;
    public IList<AnswerDto> Answers { get; set; }
}
