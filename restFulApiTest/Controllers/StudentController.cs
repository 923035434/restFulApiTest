using restFulApiTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace restFulApiTest.Controllers
{
    public class StudentController : ApiController
    {
        DB.DB db = new DB.DB();
        // GET: api/Student
        public ApiResult Get()
        {
            return new ApiResult {
                Code = 0,
                Data = db.Students
            };
        }

        // GET: api/Student/5
        public ApiResult Get(int id)
        {
            var student = db.Students.Where(s => s.Id == id).FirstOrDefault();
            if (student == null)
            {
                return new ApiResult
                {
                    Code = 404,
                    Message = "没有找到相应的对象"
                };
            }
            return new ApiResult
            {
                Code = 0,
                Data = student
            };
        }

        // GET: api/Student/Name
        public ApiResult Get(string Name)
        {
            var student = db.Students.Where(s => s.Name == Name).FirstOrDefault();
            if (student == null)
            {
                return new ApiResult
                {
                    Code = 404,
                    Message = "没有找到相应的对象"
                };
            }
            return new ApiResult
            {
                Code = 0,
                Data = student
            };
        }

        // POST: api/Student
        public ApiResult Post([FromBody]Student param)
        {
            int id = db.Students.Max<Student, int>(s => s.Id) + 1;
            if (param.ClassId == null || param.Gender == null || param.Name == null)
            {
                return new ApiResult
                {
                    Code = 501,
                    Message = "参数错误"
                };
            }
            db.Students.Add(new Student
            {
                Id = id,
                ClassId = param.ClassId,
                Gender = param.Gender,
                Name = param.Name
            });
            return new ApiResult
            {
                Code = 0,
                Message = "添加成功"
            };
        }

        // PUT: api/Student/5
        public ApiResult Put(int id, [FromBody]Student param)
        {
            var student = db.Students.Where(s => s.Id == id).FirstOrDefault();
            if (student == null)
            {
                return new ApiResult {
                    Code = 404,
                    Message = "没有找到相应的对象"
                };
            }
            student.Name = param.Name ?? student.Name;
            student.ClassId = param.ClassId ?? student.ClassId;
            student.Gender = param.Gender ?? student.Gender;
            return new ApiResult
            {
                Code = 0,
                Message = "修改成功"
            };
        }

        // DELETE: api/Student/5
        public ApiResult Delete(int id)
        {
            var student = db.Students.Where(s => s.Id == id).FirstOrDefault();
            if (student == null)
            {
                return new ApiResult
                {
                    Code = 404,
                    Message = "没有找到相应的对象"
                };
            }
            db.Students.Remove(student);
            return new ApiResult
            {
                Code = 0,
                Message = "删除成功"
            };
        }

        // GET: api/Class/{classId}/Student
        [Route("~/api/Class/{classId:int}/Student")]
        [HttpGet]
        public ApiResult GetForClassId(int classId)
        {
            var students = db.Students.Where(s => s.ClassId == classId).ToList();
            return new ApiResult
            {
                Code = 0,
                Data = students
            };
        }

        // GET: api/Class/{className}/Student
        [Route("~/api/Class/{className}/Student")]
        [HttpGet]
        public ApiResult GetForClassName(string className)
        {
            var classItem = db.Classes.Where(s => s.Name == className).FirstOrDefault();
            if (classItem == null)
            {
                return new ApiResult
                {
                    Code = 404,
                    Message = "没有找到相应的对象"
                };
            }
            var students = db.Students.Where(s => s.ClassId == classItem.Id).ToList();
            return new ApiResult
            {
                Code = 0,
                Data = students
            };
        }
    }
}
