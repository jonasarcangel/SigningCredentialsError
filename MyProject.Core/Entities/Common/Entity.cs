﻿using MyProject.Core.Entities.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyProject.Core.Entities.Common
{
    public class Entity
    {
        [Key]
        public string Id { get; set; }
    }
}
