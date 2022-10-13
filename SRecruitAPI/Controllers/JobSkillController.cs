using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRecruitAPI.Dto;
using SRecruitAPI.Models;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SRecruitAPI.Controllers
{
    [Route("api/jobskills")]
    [ApiController]
    public class JobSkillController : ControllerBase
    {
        private readonly SRecruitDBContext DBContext;
        public JobSkillController(SRecruitDBContext dBContext)
        {
           this.DBContext = dBContext;
        }

        // GET: api/<jobskills>
        [HttpGet]
        public async Task<ActionResult<List<JobSkill>>> Get()
        {
            var List = await DBContext.JobSkills.Select(
             s => new JobSkill
             {
                 JobSkillsId = s.JobSkillsId,
                 JobSkillsTitle = s.JobSkillsTitle
             }
         ).ToListAsync();


            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }

        // GET api/<jobskills>/5
      /*  [HttpGet("{jobSkillsId}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<jobskills>
        [HttpPost]
        public async Task<ActionResult<JobSkill>> Post(JobSkill jobSkill)
        {
            var entity = new JobSkill()
            {
                JobSkillsTitle = jobSkill.JobSkillsTitle
            };
            DBContext.JobSkills.Add(entity);
            await DBContext.SaveChangesAsync();
         
            return entity;
        }

        // PUT api/<jobskills>/5
        [HttpPut("{jobSkillsId}")]
        public async Task<ActionResult<JobSkill>> Put(JobSkill jobSkill)
        {
            var entity = await DBContext.JobSkills.FirstOrDefaultAsync(s => s.JobSkillsId == jobSkill.JobSkillsId);


            entity.JobSkillsId = jobSkill.JobSkillsId;
            entity.JobSkillsTitle = jobSkill.JobSkillsTitle;

            await DBContext.SaveChangesAsync();
            return entity;

        }

        // DELETE api/<jobskills>/5
        [HttpDelete("{jobSkillsId}")]
        public async Task<HttpStatusCode> Delete(int jobSkillsId)
        {
            var entity = new JobSkill()
            {
                JobSkillsId = jobSkillsId
            };
            DBContext.JobSkills.Attach(entity);
            DBContext.JobSkills.Remove(entity);

            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;


        }
    }
}
