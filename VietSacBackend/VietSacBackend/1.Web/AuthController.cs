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
        public IActionResult SignUpUser(SignUpModel signUpModel)
        {
            var responseModel = _authService.SignUp(signUpModel);
            return StatusCode(responseModel.StatusCode, responseModel);
        }

        [HttpPost]
        [Route("api/[controller]/SignInUser")]
        public IActionResult SignInUser(SignInModel signInModel)
        {
            var responseModel = _authService.SignIn(signInModel);
            return StatusCode(responseModel.StatusCode, responseModel);
        }
    }
}
