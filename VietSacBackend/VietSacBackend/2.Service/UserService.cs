using AutoMapper;
using VietSacBackend._2.Service.Interface;
using VietSacBackend._3.Repository.BaseRepository;
using VietSacBackend._3.Repository.Data;
using VietSacBackend._4.Core.Model;
using VietSacBackend._4.Core.Model.User;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

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

        // Get ALL users
        public ResponseModel GetAll()
        {
            var users = _userRepository.GetAll().ToList();
            var responseUsers = _mapper.Map<List<ResponseUserModel>>(users);
            return new ResponseModel
            {
                Data = responseUsers,
                StatusCode = StatusCodes.Status200OK
            };
        }

        // Get user by ID
        public ResponseModel GetSingle(string id)
        {
            var user = _userRepository.GetSingle(x => x.Id.Equals(id));
            if (user == null)
            {
                return new ResponseModel
                {
                    MessageError = "User not found",
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            var responseUser = _mapper.Map<ResponseUserModel>(user);
            return new ResponseModel
            {
                Data = responseUser,
                StatusCode = StatusCodes.Status200OK
            };
        }

        // Update user
        public ResponseModel UpdateUser(string id, RequestUserModel requestUserModel)
        {
            var user = _userRepository.GetSingle(x => x.Id.Equals(id));
            if (user == null)
            {
                return new ResponseModel
                {
                    MessageError = "User not found",
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            _mapper.Map(requestUserModel, user);
            _userRepository.Update(user); // SaveChanges is called within the repository

            var updatedUser = _mapper.Map<ResponseUserModel>(user);
            return new ResponseModel
            {
                Data = updatedUser,
                StatusCode = StatusCodes.Status200OK
            };
        }

        // Delete user by ID
        public ResponseModel DeleteUser(string id)
        {
            var user = _userRepository.GetSingle(x => x.Id.Equals(id));
            if (user == null)
            {
                return new ResponseModel
                {
                    MessageError = "User not found",
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            _userRepository.Delete(user); // SaveChanges is called within the repository

            return new ResponseModel
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}
