using MyProject.Core.Entities.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Services.Configuration.Models
{
    public class ContentAppSettings
    {
        public Setting[] RoleWeightSettings { get; set; }
        public Setting[] PageSizeSettings { get; set; }
    }
}
