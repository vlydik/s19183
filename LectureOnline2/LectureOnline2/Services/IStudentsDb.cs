using System.Collections.Generic;
using LectureOnline2.Models;

namespace LectureOnline2.Services
{
    public interface IStudentsDb
    {
        IEnumerable<Student> GetStudents();
    }
}