using System;
using System.Collections.Generic;

#nullable disable

namespace APIProject.Models
{
    public partial class Company
    {
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
    }
}
