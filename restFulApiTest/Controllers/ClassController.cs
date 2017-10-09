using restFulApiTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace restFulApiTest.Controllers
{
    public class ClassController : ApiController
    {
        // GET: api/Class
        DB.DB db = new DB.DB();
        public ApiResult Get()
        {            
            return new ApiResult {
                Code = 0,
                Data = db.Classes
            };
        }

        // GET: api/Class/1
        public ApiResult Get(int id)
        {
            var classInfo = db.Classes.Where(c => c.Id == id).FirstOrDefault();
            if (classInfo == null)
            {
                return new ApiResult
                {
                    Code = 404,
                    Message = "没有找到相应的对象"
                };
            }
            return new ApiResult {
                Code = 0,
                Data = classInfo
            };
        }

        // POST: api/Class
        public ApiResult Post([FromBody]Class param)
        {
            int id = db.Classes.Max<Class, int>(c => c.Id) + 1;
            db.Classes.Add(new Class
            {
                Id = id,
                Name = param.Name
            });
            return new ApiResult
            {
                Code = 0,
                Message = "添加成功！"
            };
        }

        // PUT: api/Class/1
        public ApiResult Put(int id, [FromBody]Class param)
        {
            var classInfo = db.Classes.Where(c => c.Id == id).FirstOrDefault();
            if (classInfo == null)
            {
                return new ApiResult
                {
                    Code = 404,
                    Data = "没有找到相应的对象"
                };
            }
            classInfo.Name = param.Name;
            return new ApiResult
            {
                Code = 0,
                Message = "修改成功"
            };
        }

        // DELETE: api/Class/1
        public ApiResult Delete(int id)
        {
            var classInfo = db.Classes.Where(c => c.Id == id).FirstOrDefault();
            if (classInfo == null)
            {
                return new ApiResult
                {
                    Code = 404,
                    Data = "没有找到相应的对象"
                };
            }
            db.Classes.Remove(classInfo);
            return new ApiResult
            {
                Code = 0,
                Data = "删除成功"
            };
        }
    }
}
