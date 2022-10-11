using System;
using System.Collections.Generic;

namespace SRecruitAPI.Models
{
    public partial class JobRole
    {
        public int? JobRoleId { get; set; }
        public string JobRoleTitle { get; set; } = null!;
        public int? JobRoleSkill { get; set; }
    }
}
