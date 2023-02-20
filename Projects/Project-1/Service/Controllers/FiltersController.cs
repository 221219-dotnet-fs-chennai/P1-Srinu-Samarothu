using Business_Logic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiltersController : ControllerBase
    {
        ILogic logic;

        public FiltersController(ILogic _logic)
        {
            logic = _logic;
        }
        [EnableCors("corspolicy")]
        [HttpGet("BySkill")]

        public ActionResult GetTrainersBySkill([FromQuery] string Skill)
        {
            try
            {
                var x = logic.GetTrainersBySkill(Skill);
                if (x != null)
                    return Ok(x);
                else
                    return BadRequest("No Trainers found");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [EnableCors("corspolicy")]
        [HttpGet("ByGender")]

        public ActionResult GetTrainersByGender([FromQuery] string Gender)
        {
            try
            {
                var x = logic.GetTrainerByGender(Gender);
                if (x != null)
                    return Ok(x);
                else
                    return BadRequest("No Trainers found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [EnableCors("corspolicy")]
        [HttpGet("BySkillAndGender")]

        public ActionResult GetTrainersBySkillAndGender([FromQuery] string Skill, [FromQuery] string Gender)
        {
            try
            {
                var x = logic.GetTrainersBySkillAndGender(Skill, Gender);
                if (x != null)
                    return Ok(x);
                else
                    return BadRequest("No Trainers found");
            }  
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [EnableCors("corspolicy")]
        [HttpGet("ByCity")]

        public ActionResult GetTrainersByCity([FromQuery] string City)
        {
            try
            {
                var x = logic.GetTrainerByCity(City);
                if (x != null)
                    return Ok(x);
                else
                    return BadRequest("No Trainers found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
