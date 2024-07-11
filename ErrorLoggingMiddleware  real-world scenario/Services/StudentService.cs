using ErrorLoggingMiddleware__real_world_scenario.Models;

namespace ErrorLoggingMiddleware__real_world_scenario.Services
{
    public class StudentService : IStudentService
    {
        private readonly List<Student> _students;

        public StudentService()
        {
            // Initialize with some dummy data
            _students = new List<Student>
            {
                new Student { Id = 1, Name = "John Doe", Age = 15, Grade = "10th Grade" },
                new Student { Id = 2, Name = "Jane Smith", Age = 14, Grade = "9th Grade" },
                new Student { Id = 3, Name = "Sam Brown", Age = 16, Grade = "11th Grade" }
            };
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await Task.FromResult(_students);
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await Task.FromResult(_students.Find(s => s.Id == id));
        }

        public async Task AddStudent(Student student)
        {
            _students.Add(student);
            await Task.CompletedTask;
        }

        public async Task UpdateStudent(Student student)
        {
            var existingStudent = await GetStudentById(student.Id);
            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Age = student.Age;
                existingStudent.Grade = student.Grade;
            }
        }

        public async Task DeleteStudent(int id)
        {
            var studentToRemove = await GetStudentById(id);
            if (studentToRemove != null)
            {
                _students.Remove(studentToRemove);
            }
        }
    }
}

