﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3_huseyingulerman.Core.Entities
{
    public class Pet:BaseEntity
    {
        public string Name { get; set; }
        public string Species { get; set; }
        [ForeignKey("AppUserId")]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<Health> Healths { get; set; }
        public List<Activity> Activities { get; set; }
        public List<Food> Foods { get; set; }

    }
}
