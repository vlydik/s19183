using System.Collections.Generic;
using LectureOnline2.Models;

namespace LectureOnline2.Services
{
    public class SqlServerDb : IStudentsDb
    {
        public IEnumerable<Student> GetStudents()
        {
            throw new System.NotImplementedException();
        }
    }
}