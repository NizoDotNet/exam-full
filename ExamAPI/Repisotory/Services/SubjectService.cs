using ExamAPI.DatabaseContext;
using ExamAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamAPI.Repisotory.Services
{
    public class SubjectService : ISubjectRepository
    {
        private readonly ExamApplicationDatabaseContext _db;

        public SubjectService(ExamApplicationDatabaseContext db)
        {
            _db = db;
        }

        public async Task<Subject> AddAsync(Subject obj)
        {
            await _db.Subjects.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task AddRangeAsync(IEnumerable<Subject> items)
        {
            await _db.Subjects.AddRangeAsync(items);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Subject obj)
        {
            _db.Subjects.Remove(obj);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            var subject = await _db.Subjects
                .ToListAsync();
            return subject;
        }

        public async Task<Subject> GetAsync(Guid id)
        {
            var subject = await _db.Subjects
                .Include(c => c.Quastions)
                .ThenInclude(c => c.Answers.OrderByDescending(c => c.IsCorrect))
                .FirstOrDefaultAsync(c => c.Id == id);
            return subject;
        }

        public async Task<Subject> UpdateAsync(Guid id, Subject obj)
        {
            var subject = await _db.Subjects
                .Include(c => c.Quastions)
                .ThenInclude(c => c.Answers)
                .FirstOrDefaultAsync(c => c.Id == id);
            if(subject != null)
            {
                subject.Name = obj.Name;
                subject.Quastions = obj.Quastions;
                await _db.SaveChangesAsync();
            }
            return subject;
        }
    }
}
