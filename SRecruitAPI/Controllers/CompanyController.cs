using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRecruitAPI.Models;
using System.Data.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SRecruitAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly SRecruitDBContext _dbContext;
        public CompanyController(SRecruitDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<CompanyController>
        [HttpGet]
        public async Task<ActionResult<List<Company>>> Get()
        {
            var List = await _dbContext.Companies.Select(
                s => new Company
                {
                    CompanyId = s.CompanyId,
                    CompanyName = s.CompanyName,
                    Location = s.Location
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
        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CompanyController>
        [HttpPost]
        public async Task<ActionResult<List<Company>>> CreateCompany(Company company)
        {
            _dbContext.Companies.Add(company);
            await _dbContext.SaveChangesAsync();

            return Ok(await _dbContext.Companies.ToListAsync());
        }

        // PUT api/<CompanyController>/5
        [HttpPut]
        public async Task<ActionResult<List<Company>>> UpdateCompany(Company company)
        {
            var dbCompany = await _dbContext.Companies.FindAsync(company.CompanyId);
            if (dbCompany == null)
                return BadRequest("Company not found");
            dbCompany.CompanyId = company.CompanyId;
            dbCompany.CompanyName = company.CompanyName;
            dbCompany.Location = company.Location;

            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Companies.ToListAsync());
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Candidate>>> DeleteC(int id)
        {
            var dbCompany = await _dbContext.Companies.FindAsync(id);
            if (dbCompany == null)
                return BadRequest("Candidate not found");
            _dbContext.Companies.Remove(dbCompany);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Companies.ToListAsync());
        }
    }
}
