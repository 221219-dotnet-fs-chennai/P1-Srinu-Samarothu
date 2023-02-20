using Business_Logic;
using Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerContactController : ControllerBase
    {
        ILogic logic;
        public TrainerContactController(ILogic _logic)
        {
            logic = _logic;
        }


        [HttpGet("Get")]
        public ActionResult GetTrainer([FromQuery] string? Email)
        {
            try
            {
                var contact = logic.GetTrainerContact(Email);
                if (contact != null)
                    return Ok(contact);
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
        public ActionResult Add([FromQuery] string? Email, [FromBody] TraineeContactDetail contact)
        {
            try
            {
                var newContact = logic.AddTrainerContact(Email, contact);
                return CreatedAtAction("Add", newContact);
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
        public ActionResult Delete(string? Email)
        {
            try
            {
                if (!string.IsNullOrEmpty(Email))
                {
                    var trainer = logic.DeleteTrainerContact(Email);
                    if (trainer != null)
                        return Ok(trainer);
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
        public ActionResult Update([FromQuery] string? Email, [FromBody] TraineeContactDetail contact)
        {
            try
            {
                if (!string.IsNullOrEmpty(Email))
                {
                    logic.UpdateTrainerContact(Email, contact);
                    return Ok(contact);
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
