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

        [HttpGet("GetAll/{Email}")]
        public ActionResult GetAll([FromRoute] string? Email)
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


        [HttpPost("Add/{Email}")]
        public ActionResult Add([FromRoute] string? Email, [FromBody] Skill skill)
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

        [HttpDelete("Delete/{Email}")]
        public ActionResult Delete([FromRoute] string? Email)
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

        [HttpDelete("Delete/{Email}/{skill}")]
        public ActionResult Delete([FromRoute] string? Email, [FromRoute] string? _skill)
        {
            try
            {
                if (!string.IsNullOrEmpty(Email))
                {
                    var skill = logic.DeleteTrainerExperience(Email, _skill);
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

        [HttpPut("Modify/{Email}/{skill}")]
        public ActionResult Update([FromRoute] string? Email, [FromRoute] string? skill, [FromBody] Skill modelSkill)
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
