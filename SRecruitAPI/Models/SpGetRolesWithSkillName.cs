using System.ComponentModel.DataAnnotations;

namespace SRecruitAPI.Models
{
    public class SpGetRolesWithSkillName
    {
        [Key]
        public int jobRoleId { get; set; }
        public string jobRoleTitle { get; set; }
        public string jobSkillTitle { get; set; }
    }
}
