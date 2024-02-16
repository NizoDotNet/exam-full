using ExamAPI.DatabaseContext;
using ExamAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamAPI.Repisotory.Services;

public class AnswerService : IAnswerRepository
{
    private readonly ExamApplicationDatabaseContext _db;

    public AnswerService(ExamApplicationDatabaseContext db)
    {
        _db = db;
    }
    public async Task<Answer> AddAsync(Answer obj)
    {
        if(obj != null)
        {
            await _db.Answers.AddAsync(obj);
            await _db.SaveChangesAsync();
        }
        return obj;
    }

    public async Task AddRangeAsync(IEnumerable<Answer> items)
    {
        if(items.Count() > 0)
        {
            await _db.Answers.AddRangeAsync(items);
            await _db.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<bool>> Check(List<Guid> ids)
    {
        var checkedAnswers = await _db.Answers
            .Where(c => ids.Contains(c.Id))
            .Select(c => c.IsCorrect)
            .ToListAsync();
        return checkedAnswers;
    }

    public async Task Delete(Answer obj)
    {
        if(obj != null)
        {
            _db.Answers.Remove(obj);
            await _db.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Answer>> GetAllAsync()
    {
        return await _db.Answers.ToListAsync();
    }

    public async Task<Answer> GetAsync(Guid id)
    {
        var answer = await _db.Answers.FirstOrDefaultAsync(c => c.Id == id);
       return answer;
    }


    public async Task<Answer> UpdateAsync(Guid id, Answer obj)
    {
        var answer = await _db.Answers.FirstOrDefaultAsync(c => c.Id == id);
        if(obj != null)
        {
            answer.IsCorrect = obj.IsCorrect;
            answer.Text = obj.Text;
            await _db.SaveChangesAsync();
            return answer;
        }
        return new();
    }
}
