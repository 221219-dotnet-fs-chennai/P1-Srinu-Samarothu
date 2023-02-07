using Business_Logic;
using Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        ILogic logic;
        public ExperienceController(ILogic _logic)
        {
            logic = _logic;
        }

        [HttpGet("GetAll/{Email}")]
        public ActionResult GetAll([FromRoute] string? Email)
        {
            try
            {
                var experiences = logic.GetTrainerExperience(Email);
                if (experiences != null)
                    return Ok(experiences);
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
        public ActionResult Add([FromRoute] string? Email, [FromBody] Experience experience)
        {
            try
            {
                var newTrainerLogin = logic.AddTrainerExperience(Email, experience);
                return CreatedAtAction("Add", newTrainerLogin);
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
                    var education = logic.DeleteAllTrainerExperience(Email);
                    if (education != null)
                        return Ok(education);
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

        [HttpDelete("Delete/{Email}/{Company}")]
        public ActionResult Delete([FromRoute] string? Email, [FromRoute] string? Company)
        {
            try
            {
                if (!string.IsNullOrEmpty(Email))
                {
                    var education = logic.DeleteTrainerExperience(Email, Company);
                    if (education != null)
                        return Ok(education);
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


        [HttpPut("Modify/{Email}/{Company}")]
        public ActionResult Update([FromRoute] string? Email, [FromRoute] string? Company, [FromBody] Experience experience)
        {
            try
            {
                if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Company))
                {
                    logic.UpdateTrainerExperience(Email, Company, experience);
                    return Ok(experience);
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
