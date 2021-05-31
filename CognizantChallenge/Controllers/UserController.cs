using System.Threading.Tasks;
using CognizantChallenge.Application.User.DTO;
using CognizantChallenge.Application.User.Services;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace CognizantChallenge.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase {
        [NotNull]
        private readonly IUserService userService;

        public UserController([NotNull] IUserService userService) {
            this.userService = userService;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ListUserOutput>> ListUsers() {
            var users = await this.userService.ListUsers();
            return Ok(users);
        }
    }
}