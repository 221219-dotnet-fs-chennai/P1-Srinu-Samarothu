using Business_Logic;
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

        [HttpGet("BySkill/{Skill}")]

        public ActionResult GetTrainersBySkill([FromRoute] string Skill)
        {
            try
            {
                var x = logic.GetTrainersBySkill(Skill);
                if (x != null)
                    return Ok(x);
                else
                    return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ByGender/{Gender}")]

        public ActionResult GetTrainersByGender([FromRoute] string Gender)
        {
            try
            {
                var x = logic.GetTrainerByGender(Gender);
                if (x != null)
                    return Ok(x);
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("BySkill/{Skill}/{Gender}")]

        public ActionResult GetTrainersBySkillAndGender([FromRoute] string Skill, [FromRoute] string Gender)
        {
            try
            {
                var x = logic.GetTrainersBySkillAndGender(Skill, Gender);
                if (x != null)
                    return Ok(x);
                else
                    return NoContent();
            }  
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("ByCity/{City}")]

        public ActionResult GetTrainersByCity([FromRoute] string City)
        {
            try
            {
                var x = logic.GetTrainerByCity(City);
                if (x != null)
                    return Ok(x);
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
