using System.ComponentModel.DataAnnotations;

namespace SRecruitAPI.Models
{
    public class SpJobPosting
    {
        [Key]
        
        public Int64 id { get; set; }
        public int job_posting_id { get; set; }
        public string Company_name { get; set; }
        public string Location { get; set; }
        public int job_posting_yoe { get; set; }
        public string job_role_title { get; set; }
        public string job_skills_title { get; set; }
        public int job_skills_id { get; set; }
    }
}





