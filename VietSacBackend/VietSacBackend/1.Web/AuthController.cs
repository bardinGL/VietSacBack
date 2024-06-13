using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VietSacBackend._2.Service.Interface;
using VietSacBackend._4.Core.Model.Auth;

namespace VietSacBackend._1.Web
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("api/[controller]/SignUpUser")]
        public IActionResult CreateUser(SignUpModel signUpModel)
        {
            var responseModel = _authService.SignUp(signUpModel);
            return Ok(responseModel);
        }

        [HttpPost]
        [Route("api/[controller]/SignInUser")]
        public IActionResult CreateUser(SignInModel signIpModel)
        {
            var responseModel = _authService.SignIn(signIpModel);
            return Ok(responseModel);
        }
    }
}