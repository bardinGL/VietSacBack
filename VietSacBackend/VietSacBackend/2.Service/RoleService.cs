using AutoMapper;
using VietSacBackend._2.Service.Interface;
using VietSacBackend._3.Repository.BaseRepository;
using VietSacBackend._3.Repository.Data;
using VietSacBackend._4.Core.Model;
using VietSacBackend._4.Core.Model.Role;

namespace VietSacBackend._2.Service
{
    public class RoleService : IRoleService
    {
        private readonly IGenericRepository<RoleEntity> _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IGenericRepository<RoleEntity> repositoryBase, IMapper mapper)
        {
            _roleRepository = repositoryBase;
            _mapper = mapper;
        }

        //Create
        public ResponseModel CreateRole(RequestRoleModel entity)
        {
            var roleEntity = _mapper.Map<RoleEntity>(entity);
            _roleRepository.Create(roleEntity);
            return new ResponseModel
            {
                Data = roleEntity,
                MessageError = "",
                StatusCode = StatusCodes.Status200OK
            };
        }
        //Get ALL
        public ResponseModel GetAll()
        {
            var entities = _roleRepository.GetAll().ToList();
            var response = _mapper.Map<List<ResponseRoleModel>>(entities.ToList());
            return new ResponseModel
            {
                Data = response,
                MessageError = "",
                StatusCode = StatusCodes.Status200OK
            };
        }

        //GetID
        public ResponseModel GetRoleID(string id)
        {
            var roleEntity = _roleRepository.GetSingle(x => x.Id.Equals(id));
            var responseRoleModel = _mapper.Map<ResponseRoleModel>(roleEntity);
            return new ResponseModel
            {
                Data = roleEntity,
                MessageError = "",
                StatusCode = StatusCodes.Status200OK
            };
        }

        //Update
        public ResponseModel UpdateRole(string id, RequestRoleModel requestRoleModel)
        {
            var roleEntity = _roleRepository.GetSingle(x => id.Equals(x.Id));
            if (roleEntity == null)
            {
                return new ResponseModel
                {
                    MessageError = "Khong tim thay",
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            _mapper.Map(requestRoleModel, roleEntity);
            _roleRepository.Update(roleEntity);
            return new ResponseModel
            {
                StatusCode = StatusCodes.Status200OK
            };

        }

        //Delete bY ID
        public ResponseModel DeleteRole(string id)
        {
            var roleEntity = _roleRepository.GetSingle(x => x.Id.Equals(id));
            if (roleEntity == null)
            {
                return new ResponseModel
                {
                    MessageError = "Khong tim thay",
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            _roleRepository.Delete(roleEntity);
            return new ResponseModel
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}
