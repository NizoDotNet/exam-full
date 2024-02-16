namespace ExamAPI.Repisotory;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetAsync(Guid id);
    Task<T> AddAsync(T obj);
    Task<T> UpdateAsync(Guid id,T obj);
    Task Delete(T obj);
    Task AddRangeAsync(IEnumerable<T> items);
}
