using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_app_ef.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstmidname { get; set; }
        public int Age { get; set; }
        public DateTime Enrollmentdate { get; set; }
        public int CourseId { get; set; }
    }
}