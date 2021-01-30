using MyProject.Core.Entities.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Services.Configuration.Models
{
    public class SecurityAppSettings
    {
        public Setting[] RoleUserSettings { get; set; }
        public Setting[] PermissionSettings { get; set; }
    }
}
