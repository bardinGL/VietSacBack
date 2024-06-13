using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VietSacBackend._2.Service.Interface;
using VietSacBackend._4.Core.Model.User;

namespace VietSacBackend._1.Web
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        //Get All;
        [HttpGet]
        [Route("api/[controller]/GetAllUser")]
        public IActionResult GetAllUser()
        {
            var responseModel = _userService.GetAll();
            return Ok(responseModel);
        }
        // GET ID
        [HttpGet]
        [Route("api/[controller]/GetSingleID")]
        public IActionResult GetSingleID(string id)
        {
            var responseModel = _userService.GetSingle(id);
            return Ok(responseModel);

        }
        // Update 
        [HttpPut]
        [Route("api/[controller]/UpdateUser")]
        public IActionResult UpdateUser(string id, RequestUserModel requestUserModel)
        {
            var responseModel = _userService.UpdateUser(id, requestUserModel);
            return Ok(responseModel);
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteUser")]
        public IActionResult DeleteUser(string id)
        {
            var responseModel = _userService.DeleteUser(id);
            return Ok(responseModel);
        }


    }
}
