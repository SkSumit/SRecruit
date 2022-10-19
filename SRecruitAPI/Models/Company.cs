using System;
using System.Collections.Generic;

namespace SRecruitAPI.Models
{
    public partial class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string? Location { get; set; }
    }
}
