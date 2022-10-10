using System;
using System.Collections.Generic;

#nullable disable

namespace APIProject.Models
{
    public partial class JobRole
    {
        public int? JobRoleId { get; set; }
        public string JobRoleTitle { get; set; }
        public int? JobRoleSkill { get; set; }
    }
}
