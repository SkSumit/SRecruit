using System;
using System.Collections.Generic;

#nullable disable

namespace APIProject.Models
{
    public partial class Candidate
    {
        public int CandidateId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string JobSkillTitle { get; set; }
        public string PreferredLocation { get; set; }
        public int YearOfExperience { get; set; }
    }
}
