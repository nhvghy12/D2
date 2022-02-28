using D2.Data.Entities;

namespace D2.Services;
public interface IStudentService
{
    public Task<IList<Student>> GetAllAsync();
    public Task<Student?> GetOneAsync(int id);
    public Task<Student?> AddAsync(Student entity);
    public Task<Student?> EditAsync(Student entity);
    public Task RemoveAsync(int id);
}