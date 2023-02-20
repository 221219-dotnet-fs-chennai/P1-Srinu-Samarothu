using Business_Logic;
using Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        ILogic logic;
        public TrainerController(ILogic _logic)
        {
            logic = _logic;
        }

        [HttpGet("Get")]
        public ActionResult GetTrainer([FromQuery] string? Email)
        {
            try
            {
                var trainer = logic.GetTrainerDetails(Email);
                if (trainer != null)
                    return Ok(trainer);
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
        public ActionResult Add([FromBody] TraineeTrainerDetail trainer)
        {
            try
            {
                var newTrainer = logic.AddTrainer(trainer);
                return CreatedAtAction("Add", newTrainer);
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
                    var trainer = logic.DeleteTrainer(Email);
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
        public ActionResult Update([FromQuery] string? Email, [FromBody] TraineeTrainerDetail trainer)
        {
            try
            {
                if (!string.IsNullOrEmpty(Email))
                {
                    logic.UpdateTrainer(Email, trainer);
                    return Ok(trainer);
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
