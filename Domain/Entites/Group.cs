﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public ICollection<StudentGroup> StudentGroups { get; set; }
        public ICollection<Education> Educations { get; set; }
    }
}