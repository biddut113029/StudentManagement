﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreWithAngular.Models
{
    public class Course
    {
        public int ID { get; set; }

        public string credit { get; set; }

        public string course{ get; set; }

        public string student { get; set; }

        public string semester { get; set; }

        public int CourseID { get; set; }
        public int StudentID { get; set; }
    }
}
