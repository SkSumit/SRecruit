using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRecruitAPI.Dto;
using SRecruitAPI.Models;
using System.Net;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SRecruitAPI.Controllers
{
    [Route("api/jobrole")]
    [ApiController]
    public class JobRoleController : ControllerBase
    {
        private readonly SRecruitDBContext DBContext;
        public JobRoleController(SRecruitDBContext dBContext)
        {
            this.DBContext = dBContext;
        }

        // GET: api/<JobRoleController>
        [HttpGet]
        public IQueryable<SpGetRolesWithSkillName> Get()
        {


            var res = DBContext.SpGetRolesWithSkillName.FromSqlInterpolated($"EXECUTE GetRolesWithSkillName");

            return res;

        }

        // GET api/<JobRoleController>/5
        /* [HttpGet("{id}")]
         public string Get(int id)
         {
             return "value";
         }*/

        // POST api/<JobRoleController>
        [HttpPost]
        public async Task<ActionResult<JobRole>> Post(JobRole jobRole)
        {
            var entity = new JobRole()
            {
                JobRoleId = jobRole.JobRoleId,
                JobRoleSkill = jobRole.JobRoleSkill,
                JobRoleTitle= jobRole.JobRoleTitle,

            };
            DBContext.JobRoles.Add(entity);
            await DBContext.SaveChangesAsync();

            return entity;
        }


        // PUT api/<JobRoleController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<JobRole>> Put(JobRole jobRole)
        {
            var entity = await DBContext.JobRoles.FirstOrDefaultAsync(s => s.Id == jobRole.Id);
            entity.JobRoleId = jobRole.JobRoleId;
            entity.JobRoleSkill = jobRole.JobRoleSkill;
            entity.JobRoleTitle = jobRole.JobRoleTitle;


            await DBContext.SaveChangesAsync();
            return entity;

        }

        // DELETE api/<JobRoleController>/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            var entity = new JobRole()
            {
                Id = id,
            };
            DBContext.JobRoles.Attach(entity);
            DBContext.JobRoles.Remove(entity);

            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;


        }
    }
}
