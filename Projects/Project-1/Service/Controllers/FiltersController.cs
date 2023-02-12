using Business_Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("BySkill/{skill}")]

        public ActionResult GetTrainersBySkill([FromRoute] string skill)
        {
            try
            {
                var x = logic.GetTrainersBySkill(skill);
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
    }
}
