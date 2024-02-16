using ExamAPI.Models.DTOs.Answer;

namespace ExamAPI.Models.DTOs.Quastion;

public class UpdateQuastion
{
    
    public string Text { get; set; } = null!;
    public IList<UpdateAnswer> Answers { get; set; } 
}
