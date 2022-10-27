using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRecruitAPI.Models;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SRecruitAPI.Controllers
{
    [Route("api/jobposting")]
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
        public IQueryable<SpJobPosting> Get()
        {
            var res = _dbContext.SpJobPosting.FromSqlInterpolated($"EXECUTE getJobPostings");
            return res;
        }

        // GET api/<JobPostingController>/5
        [HttpGet("{id}")]
        public IQueryable<Candidate> Get(int id)
        {
            var res = _dbContext.Candidates.FromSqlInterpolated($"EXECUTE getCandidatesForAJob {id}");
            return res;
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
