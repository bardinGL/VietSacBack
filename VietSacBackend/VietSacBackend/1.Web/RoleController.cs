using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VietSacBackend._2.Service.Interface;
using VietSacBackend._4.Core.Model.Role;

namespace VietSacBackend._1.Web
{
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        ////Create
        [HttpPost]
        [Route("api/[controller]/CreateRole")]
        public IActionResult CreateRole(RequestRoleModel requestRoleModel)
        {
            var responseModel = _roleService.CreateRole(requestRoleModel);
            return Ok(responseModel);
        }

        //Get ALL
        [HttpGet]
        [Route("api/[controller]/GetAllRole")]
        public IActionResult GetAllRole()
        {
            var responseModel = _roleService.GetAll();
            return Ok(responseModel);
        }
        //Get
        [HttpGet]
        [Route("api/[controller]/GetRoleID")]
        public IActionResult GetRoleID(string id)
        {
            var responseModel = _roleService.GetRoleID(id);
            return Ok(responseModel);

        }

        //Update
        //[HttpPut]
        //[Route("api/[controller]/UpdateRole")]
        //public IActionResult UpdateRole(string id, RequestRoleModel requestRoleModel)
        //{
        //    var responseModel = _roleService.UpdateRole(id, requestRoleModel);
        //    return Ok(responseModel);
        //}

        [HttpDelete]
        [Route("api/[controller]/DeleteRole")]
        public IActionResult DeleteRole(string id)
        {
            var responseModel = _roleService.DeleteRole(id);
            return Ok(responseModel);
        }
    }
}
