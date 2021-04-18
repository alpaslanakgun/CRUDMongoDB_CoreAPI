using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBCrudDemo.Models.IRepository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> Get();
        Task<Student> Get(string id);
        Task Add(Student student);
        Task<string> Update(string id, Student student);
        Task<DeleteResult> Remove(string id);
        Task<DeleteResult> RemoveAll();

    }
}
