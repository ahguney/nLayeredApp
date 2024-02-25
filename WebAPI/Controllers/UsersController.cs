using Business.Abstract;
using Business.Request.User;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public ActionResult Register(RegisterRequest request)
        {
            _userService.Register(request);
            return Ok();
        }
        
        [HttpPost("login")]
        public AccessToken Login(LoginRequest request)
        {

            return _userService.Login(request);
        }
    }
}
