using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ontap1.Models
{
    public class Student
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Passw { get; set; }

        public string City { get; set; }
        public string Gender { get; set; }
        public string Subjects { get; set; }
    }
}