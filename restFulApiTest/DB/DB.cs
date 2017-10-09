using restFulApiTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restFulApiTest.DB
{
    public class DB
    {
        public DB()
        {
            this.Students = new List<Student>();
            this.Classes = new List<Class>();
            this.Classes.Add(new Class {
                Id = 1,
                Name = "牛班"
            });
            this.Classes.Add(new Class
            {
                Id = 2,
                Name = "好牛班"
            });
            this.Students.Add(new Student
            {
                Id = 1,
                ClassId = 1,
                Gender = "男",
                Name = "小刚"
            });
            this.Students.Add(new Student
            {
                Id = 2,
                ClassId = 1,
                Gender = "男",
                Name = "小明"
            });
            this.Students.Add(new Student
            {
                Id = 3,
                ClassId = 1,
                Gender = "女",
                Name = "小红"
            });
            this.Students.Add(new Student
            {
                Id = 4,
                ClassId = 2,
                Gender = "女",
                Name = "小陈"
            });
        }
        public List<Student> Students { get; set; }
        public List<Class> Classes { get; set; }
    }
}