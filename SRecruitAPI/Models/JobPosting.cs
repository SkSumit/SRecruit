using System;
using System.Collections.Generic;

namespace SRecruitAPI.Models
{
    public partial class JobPosting
    {
        public int JobPostingId { get; set; }
        public int? CompanyId { get; set; }
        public int? JobRoleId { get; set; }
        public int? JobPostingYoe { get; set; }
    }
}
