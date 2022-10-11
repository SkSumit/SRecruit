using System;
using System.Collections.Generic;

namespace SRecruitAPI.Models
{
    public partial class Candidate
    {
        public int CandidateId { get; set; }
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string EmailId { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? JobSkillTitle { get; set; }
        public string? PreferredLocation { get; set; }
        public int YearOfExperience { get; set; }
    }
}
