using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRecruitAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SRecruitAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly SRecruitDBContext _dbContext;
        public CandidateController(SRecruitDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<CandidateController>
        [HttpGet]
        public async Task<ActionResult<List<Candidate>>> Get()
        {
            var List = await _dbContext.Candidates.Select(
                s => new Candidate
                {
                    CandidateId = s.CandidateId,
                    FullName = s.FullName,
                    PhoneNumber = s.PhoneNumber,
                    EmailId = s.EmailId,
                    Address = s.Address,
                    PreferredLocation = s.PreferredLocation,
                    JobSkillTitle = s.JobSkillTitle,
                    YearOfExperience = s.YearOfExperience
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

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        //Creating Candidate
        // POST api/<CandidateController>
        [HttpPost]
        public async Task<ActionResult<List<Candidate>>> CreateCandidate(Candidate candidate)
        {
            _dbContext.Candidates.Add(candidate);
            await _dbContext.SaveChangesAsync();

            return Ok(await _dbContext.Candidates.ToListAsync());
        }

        //Update Candidate
        // PUT api/<CandidateController>/5
        [HttpPut]
        public async Task<ActionResult<List<Candidate>>> UpdateCandidate(Candidate candidate)
        {
            var dbCandidate = await _dbContext.Candidates.FindAsync(candidate.CandidateId);
            if (dbCandidate == null)
                return BadRequest("Candidate not found");
            dbCandidate.CandidateId = candidate.CandidateId;
            dbCandidate.FullName = candidate.FullName;
            dbCandidate.PhoneNumber = candidate.PhoneNumber;
            dbCandidate.EmailId = candidate.EmailId;
            dbCandidate.Address = candidate.Address;
            dbCandidate.PreferredLocation = candidate.PreferredLocation;
            dbCandidate.JobSkillTitle = candidate.JobSkillTitle;
            dbCandidate.YearOfExperience = candidate.YearOfExperience;

            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Candidates.ToListAsync());
        }

        //Delete 
        // DELETE api/<CandidateController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Candidate>>> DeleteCandidate(int id)
        {
            var dbCandidate = await _dbContext.Candidates.FindAsync(id);
            if (dbCandidate == null)
                return BadRequest("Candidate not found");
            _dbContext.Candidates.Remove(dbCandidate);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Candidates.ToListAsync());
        }
    }
}
