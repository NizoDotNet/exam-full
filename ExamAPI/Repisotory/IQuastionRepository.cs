using ExamAPI.Models;

namespace ExamAPI.Repisotory;

public interface IQuastionRepository : IRepository<Quastion>
{
    public Task<IEnumerable<Quastion>> GetBySubjectID(Guid subjectId);
}
