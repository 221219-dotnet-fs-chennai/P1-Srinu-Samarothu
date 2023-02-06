using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Business_Logic;
using Models;
using System.ComponentModel.DataAnnotations;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILogic logic;
        public LoginController(ILogic _logic)
        {
            logic = _logic;
        }

        [HttpGet("GetAllLogins")]
        public ActionResult GetLogins()
        {
            try
            {
                var logins = logic.GetLoginDetails();
                if (logins != null)
                    return Ok(logins);
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
        public ActionResult Add([FromBody] TraineeLogin login)
        {
            try
            {
                var newTrainerLogin = logic.AddLogin(login);
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


        [HttpDelete("DeleteLogin/{Email}")]
        public ActionResult Delete(string? Email)
        {
            try
            {
                if (!string.IsNullOrEmpty(Email))
                {
                    var login = logic.DeleteLogin(Email);
                    if (login != null)
                        return Ok(login);
                    else
                        return NotFound();
                }
                else
                    return BadRequest("Entered Email is Invalid");

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

        [HttpPut("modify/{Email}/{Password}")]
        public ActionResult Update([FromRoute] string? Email, [FromRoute] string? Password, [FromBody] TraineeLogin login)
        {
            try
            {
                if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
                {
                    logic.UpdateLogin(Email, Password, login);
                    return Ok(login);
                }
                else
                    return BadRequest($"something wrong with {login.Email} input, please try again!");
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
