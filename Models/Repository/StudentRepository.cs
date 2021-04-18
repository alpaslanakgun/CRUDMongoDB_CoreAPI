
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBCrudDemo.DbModels;
using MongoDBCrudDemo.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBCrudDemo.Models.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ObjectContext _context = null;
        public StudentRepository(IOptions<Settings> settings)
        {
            _context = new ObjectContext(settings);

        }

        public Task Add(Student student)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Student>> Get()
        {
            return await _context.Student.Find(x => true).ToListAsync();
        }

        public async Task<Student> Get(string id)
        {
            var student = Builders<Student>.Filter.Eq("Id", id);
            return await _context.Student.Find(student).FirstOrDefaultAsync();
        }

        public async Task<DeleteResult> Remove(string id)
        {
            return await _context.Student.DeleteOneAsync(Builders<Student>.Filter.Eq("Id", id));

        }

        public async Task<DeleteResult> RemoveAll()
        {
            return await _context.Student.DeleteManyAsync(new BsonDocument());
        }

        public Task<string> Update(string id, Student student)
        {
            throw new NotImplementedException();
        }
    }
}
