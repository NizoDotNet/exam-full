using ExamAPI.Models;

namespace ExamAPI.Repisotory;

public interface IAnswerRepository : IRepository<Answer>
{
    Task<IEnumerable<bool>> Check(List<Guid> ids);
}
