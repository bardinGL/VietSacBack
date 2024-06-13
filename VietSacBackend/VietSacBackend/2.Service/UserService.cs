using AutoMapper;
using VietSacBackend._2.Service.Interface;
using VietSacBackend._3.Repository.BaseRepository;
using VietSacBackend._3.Repository.Data;
using VietSacBackend._4.Core.Model;
using VietSacBackend._4.Core.Model.User;

namespace VietSacBackend._2.Service
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<UserEntity> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IGenericRepository<UserEntity> repository, IMapper mapper)
        {
            _userRepository = repository;
            _mapper = mapper;
        }

        //Get ALL
        public ResponseModel GetAll()
        {
            var response = _mapper.Map<List<ResponseUserModel>>(_userRepository.GetAll().ToList());
            return new ResponseModel
            {
                Data = response,
                MessageError = "",
                StatusCode = StatusCodes.Status200OK
            };
        }
        //GetID
        public ResponseModel GetSingle(string id)
        {
            var userEntity = _userRepository.GetSingle(x => x.Id.Equals(id));
            var responseUserModel = _mapper.Map<ResponseUserModel>(userEntity);
            return new ResponseModel
            {
                Data = userEntity,
                MessageError = "",
                StatusCode = StatusCodes.Status200OK
            };
        }
        //Update
        public ResponseModel UpdateUser(string id, RequestUserModel requestUserModel)
        {
            var userEntity = _userRepository.GetSingle(x => id.Equals(x.Id));
            if (userEntity == null)
            {
                return new ResponseModel
                {
                    MessageError = "Khong tim thay",
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            _mapper.Map(requestUserModel, userEntity);
            _userRepository.Update(userEntity);
            return new ResponseModel
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
        //Delete bY ID
        public ResponseModel DeleteUser(string id)
        {
            var userEntity = _userRepository.GetSingle(x => x.Id.Equals(id));
            if (userEntity == null)
            {
                return new ResponseModel
                {
                    MessageError = "Khong tim thay",
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            _userRepository.Delete(userEntity);
            return new ResponseModel
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}
