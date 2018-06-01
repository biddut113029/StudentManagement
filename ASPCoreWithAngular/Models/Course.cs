﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreWithAngular.Models
{
    public class Course
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string Department { get; set; }

        public string City { get; set; }

        public int CourseID { get; set; }
        public int StudentID { get; set; }
    }
}
