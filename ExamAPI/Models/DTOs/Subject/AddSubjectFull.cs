namespace ExamAPI.Models.DTOs.Subject;

public class AddSubjectFull
{
    public string Name { get; set; }
    public List<AddQuastionFull> Quastions { get; set; }
}

public class AddQuastionFull
{
    public string Text { get; set; }
    public List<AddAnswerFull> Answers { get; set; }
}

public class AddAnswerFull
{
    public string Text { get; set; }
    public bool IsCorrect { get; set; } = false;
}
