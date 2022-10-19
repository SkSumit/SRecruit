using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRecruitAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SRecruitAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostingController : ControllerBase
    {
        private readonly SRecruitDBContext _dbContext;
        public JobPostingController(SRecruitDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<JobPostingController>
        [HttpGet]
        public async Task<ActionResult<List<JobPosting>>> Get()
        {
            var List = await _dbContext.JobPostings.Select(
                s => new JobPosting
                {
                    JobPostingId = s.JobPostingId,
                    JobRoleId = s.JobRoleId,
                    JobPostingYoe = s.JobPostingYoe,
                    CompanyId = s.CompanyId
                }
            ).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(List);
            }
        }

        // GET api/<JobPostingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<JobPostingController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<JobPostingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JobPostingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
