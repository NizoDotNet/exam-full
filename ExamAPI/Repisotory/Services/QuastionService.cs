using ExamAPI.DatabaseContext;
using ExamAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ExamAPI.Repisotory.Services;

public class QuastionService : IQuastionRepository
{
    private readonly ExamApplicationDatabaseContext _db;

    public QuastionService(ExamApplicationDatabaseContext db)
    {
        _db = db;
    }

    public async Task<Quastion> AddAsync(Quastion obj)
    {
        bool exist = await _db.Subjects.AnyAsync(c => c.Id == obj.SubjectId);
        if (exist && obj is not null)
        {
            await _db.Quastions.AddAsync(obj);
            await _db.SaveChangesAsync();
        }
        return obj;
    }

    public async Task AddRangeAsync(IEnumerable<Quastion> items)
    {
        if (items.Count() > 0)
        {
            await _db.Quastions.AddRangeAsync(items);
            await _db.SaveChangesAsync();

        }
    }

    public async Task Delete(Quastion obj)
    {
        if (obj != null)
        {
            _db.Quastions.Remove(obj);
            await _db.SaveChangesAsync();

        }
    }

    public async Task<IEnumerable<Quastion>> GetAllAsync()
    {
        return await _db.Quastions.ToListAsync();
    }

    public async Task<Quastion> GetAsync(Guid id)
    {
        var quastion = await _db.Quastions
                    .Include(c => c.Answers)    
                    .FirstOrDefaultAsync(c => c.Id == id);
        return quastion;
    }

    public async Task<IEnumerable<Quastion>> GetBySubjectID(Guid subjectId)
    {
        var quastions = await _db.Quastions
            .Where(c => c.SubjectId == subjectId)
            .Include(c => c.Answers)
            .ToListAsync();
        return quastions;
    }

    public async Task<Quastion> UpdateAsync(Guid id, Quastion obj)
    {
        var quastion = await _db.Quastions.Include(c => c.Answers).FirstOrDefaultAsync(c => c.Id == id);
        if(quastion != null && obj != null)
        {
            quastion.Text = obj.Text;
            quastion.Answers = obj.Answers;
            await _db.SaveChangesAsync();
        }
        return quastion;
    }
}
