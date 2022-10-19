using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRecruitAPI.Dto;
using SRecruitAPI.Models;

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

        // GET: api/<jobskills>///
        [HttpGet]
        public async Task<ActionResult<List<JobSkillDTO>>> Get()
        {
            var List = await DBContext.JobSkills.Select(
             s => new JobSkillDTO
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
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<jobskills>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<jobskills>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<jobskills>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
