using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDBCrudDemo.Models;
using MongoDBCrudDemo.Models.IRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBCrudDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet]
        public Task<string> Get()
        {
            return this.GetStudent();
        }
        private async Task<string> GetStudent()
        {
            var students = await _studentRepository.Get();
            return JsonConvert.SerializeObject(students);
        }
        [HttpGet]
        public Task<string> Get(string id)
        {
            return this.GetStudentById(id);
        }
        private async Task<string> GetStudentById(string id)
        {
            var students = await _studentRepository.Get(id) ?? new Student();
            return JsonConvert.SerializeObject(students);
        }

        [HttpPost]
        public async Task<string> Post([FromBody] Student student)
        {
            await _studentRepository.Add(student);
            return "";
        }

        [HttpPut("{id}")]
        public async Task<string> Put(string id,[FromBody]Student student)
        {
            if (string.IsNullOrEmpty(id)) return "Invalid id !!!";
           return await _studentRepository.Update(id,student);
      
            
        }
        [HttpDelete("{id}")]
        public async Task<string>Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return "Invalid id !!!";
            await _studentRepository.Remove(id);
            return "";

        }



    }
}
