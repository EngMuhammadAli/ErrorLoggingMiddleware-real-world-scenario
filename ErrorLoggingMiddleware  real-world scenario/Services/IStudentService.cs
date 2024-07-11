using ErrorLoggingMiddleware__real_world_scenario.Models;

namespace ErrorLoggingMiddleware__real_world_scenario.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);
        Task AddStudent(Student student);
        Task UpdateStudent(Student student);
        Task DeleteStudent(int id);
    }
}
