﻿using Business_Logic;
using Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        ILogic logic;
        public EducationController(ILogic _logic)
        {
            logic = _logic;
        }

        [HttpGet("Get/{Email}")]
        public ActionResult GetTrainer([FromRoute] string? Email)
        {
            try
            {
                var education = logic.GetTrainerEducation(Email);
                if (education != null)
                    return Ok(education);
                else
                    return BadRequest("No Trainer education found");
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
        public ActionResult Add([FromRoute] string? Email, [FromBody] Education education)
        {
            try
            {
                var newEducation = logic.AddTrainerEducation(Email, education);
                return CreatedAtAction("Add", newEducation);
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
        public ActionResult Delete(string? Email)
        {
            try
            {
                if (!string.IsNullOrEmpty(Email))
                {
                    var education = logic.DeleteTrainerEducation(Email);
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


        [HttpPut("Modify/{Email}")]
        public ActionResult Update([FromRoute] string? Email, [FromBody] Education education)
        {
            try
            {
                if (!string.IsNullOrEmpty(Email))
                {
                    logic.UpdateTrainerEducation(Email, education);
                    return Ok(education);
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
