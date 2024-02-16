using ExamAPI.Models;
using FluentValidation;

namespace ExamAPI.FluentValidation;

public class SubjectValidator : AbstractValidator<Subject>
{
    public SubjectValidator()
    {
        RuleFor(x => x.Quastions)
            .NotEmpty()
            .WithMessage("Quastions can't be empty");

        RuleFor(x => x.Name)
            .NotEmpty();

        RuleForEach(x => x.Quastions)
            .SetValidator(new QuastionValidator());
    }
}

public class QuastionValidator : AbstractValidator<Quastion>
{
    public QuastionValidator()
    {
        RuleFor(x => x.Text)
            .NotEmpty();

        RuleFor(x => x.Answers)
            .NotEmpty()
            .WithMessage("Answers can't be empty")
            .Must(x => x.Any(x => x.IsCorrect))
            .WithMessage("One of the answer must be correct answer")
            .Must(x => x.Count(x => x.IsCorrect) == 1)
            .WithMessage("Only one answer can be correct");

        RuleForEach(x => x.Answers)
            .SetValidator(new AnswerValidator());
            
    }
}

public class AnswerValidator : AbstractValidator<Answer>
{
    public AnswerValidator()
    {
        RuleFor(x => x.Text)
            .NotEmpty()
            .WithMessage("Answer text can't be empty");
    }
}