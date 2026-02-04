using Microsoft.AspNetCore.Mvc;
using TravelExperience.Experience;
using TravelExperience.ExperienceWorker;

namespace TravelExperience.Api.Controllers
{
    [ApiController]
    [Route("Experience/[Action]")]
    public class ExperienceController : ControllerBase
    {
        private readonly ExperienceManager _experienceManager;
        public ExperienceController(ExperienceManager experienceManager)
        {
            _experienceManager = experienceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetExperienceByIdAsync([FromQuery] Guid id)
        {
            ExperienceDTO experience = await _experienceManager.GetExperienceByIdAsync(id);
            if(experience == null) 
                return NotFound("Not Found");
            return Ok(experience);
        }
        [HttpGet]
        public async Task<IActionResult> GetExperiencesBySearchAsync([FromQuery] string search)
        {
            List<ExperienceDTO> experienceList = await _experienceManager.GetExperiencesBySearchAsync(search);
             return Ok(experienceList);
                
        }
        [HttpGet]
        public async Task<IActionResult> GetAllExperiencesAsync()
        {
            List<ExperienceDTO> allExperience = await _experienceManager.GetAllExperiencesAsync();
            return Ok(allExperience);
        }
        [HttpPost]
        public async Task<IActionResult> CreateExperienceAsync([FromBody] ExperienceDTO experience)
        {
            string userID = "prova";//prendere dai claims del JWT quando implementato
            try
            {
                await _experienceManager.CreateExperienceAsync(experience, userID);
                return Ok("Experience created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateExperienceAsync([FromBody] ExperienceDTO experience)
        {
            string userID = "prova";//prendere dai claims del JWT quando implementato
            try
            {
                await _experienceManager.UpdateExperienceAsync(experience, userID);
                return Ok(experience);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }         
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteExperienceAsync([FromQuery] string experienceId)
        {
            try
            {
                await _experienceManager.DeleteExperienceAsync(experienceId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
