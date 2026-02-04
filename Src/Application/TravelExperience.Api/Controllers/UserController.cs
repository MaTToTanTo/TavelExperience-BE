using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TravelExperience.UserWorker;

namespace TravelExperience.Api.Controllers
{
    [ApiController]
    [Route("User/[Action]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager _userManager;
        public UserController(UserManager userManager)
        {
            _userManager = userManager;
        }

    }
}
