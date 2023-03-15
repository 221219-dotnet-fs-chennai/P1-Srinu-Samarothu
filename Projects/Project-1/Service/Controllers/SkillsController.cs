using Business_Logic;
using Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        ILogic logic;
        public SkillsController(ILogic _logic)
        {
            logic = _logic;
        }

        [HttpGet("GetAll")]
        public ActionResult GetAll([FromQuery] string? Email)
        {
            try
            {
                var skills = logic.GetTrainerSkill(Email);
                if (skills != null)
                    return Ok(skills);
                else
                    return BadRequest("No Trainer logins found");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSkill")]
        public ActionResult GetSkill([FromQuery] string? Email, [FromQuery] string? skill)
        {
            try
            {
                var skills = logic.GetTrainerSkill(Email, skill);
                if (skills != null)
                    return Ok(skills);
                else
                    return BadRequest("No Trainer logins found");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("Add")]
        public ActionResult Add([FromQuery] string? Email, [FromBody] Skill skill)
        {
            try
            {
                var newTrainerSkill = logic.AddTrainerSkill(Email, skill);
                return CreatedAtAction("Add", newTrainerSkill);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("DeleteAll")]
        public ActionResult Delete([FromQuery] string? Email)
        {
            try
            {
                if (!string.IsNullOrEmpty(Email))
                {
                    var skill = logic.DeleteAllTrainerSkill(Email);
                    if (skill != null)
                        return Ok(skill);
                    else
                        return NotFound();
                }
                else
                    return BadRequest("Email entered is invalid");

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("Delete")]
        public ActionResult Delete([FromQuery] string? Email, [FromQuery] string? _skill)
        {
            try
            {
                if (!string.IsNullOrEmpty(Email))
                {
                    var skill = logic.DeleteTrainerSkill(Email, _skill);
                    if (skill != null)
                        return Ok(skill);
                    else
                        return NotFound();
                }
                else
                    return BadRequest("Email entered is invalid");

            }   
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut("Modify")]
        public ActionResult Update([FromQuery] string? Email, [FromQuery] string? skill, [FromBody] Skill modelSkill)
        {
            try
            {
                if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(skill))
                {
                    logic.UpdateTrainerSkill(Email, skill, modelSkill);
                    return Ok(modelSkill);
                }
                else
                    return BadRequest($"something wrong with {Email} input, please try again!");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
