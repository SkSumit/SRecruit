using System.ComponentModel.DataAnnotations;

namespace SRecruitAPI.Dto
{
    public class ShortlistedCandidate
    {
        [Key]
        public int ShortListId { get; set; }
        public string ShortListName { get; set; }
        public string ShortListNumber { get; set; }
        public string ShortListLocation { get; set; }
        public string ShortListRoleTitle { get; set; }
        public string ShortListSkillTitle { get; set; }
    }
}
