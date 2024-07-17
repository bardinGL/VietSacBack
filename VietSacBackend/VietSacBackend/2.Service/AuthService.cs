using AutoMapper;
using VietSacBackend._2.Service.Interface;
using VietSacBackend._3.Repository.Data;
using VietSacBackend._4.Core.Model.Auth;
using VietSacBackend._4.Core.Model.User;
using VietSacBackend._4.Core.Model;
using VietSacBackend._3.Repository.BaseRepository;
using VietSacBackend._4.Core.Helper;

namespace VietSacBackend._2.Service
{
    public class AuthService : IAuthService
    {
        private readonly IGenericRepository<UserEntity> _userRepository;
        private readonly IMapper _mapper;
        private readonly GenerateToken _generateTokenRepository;

        public AuthService(IGenericRepository<UserEntity> repositoryBase, IMapper mapper, GenerateToken generateToken)
        {
            _userRepository = repositoryBase;
            _mapper = mapper;
            _generateTokenRepository = generateToken;
        }

        public ResponseModel SignIn(SignInModel signInModel)
        {
            var userLogin = _userRepository.GetSingle(x => x.email.Equals(signInModel.email) &&
            x.password.Equals(signInModel.password), x => x.Role);

            if (userLogin == null)
            {
                return new ResponseModel
                {
                    MessageError = "Invalid email or password",
                    StatusCode = StatusCodes.Status404NotFound
                };
            }

            var token = _generateTokenRepository.GenerateTokenModel(userLogin);
            var responseTokenModel = new ResponseTokenModel
            {
                Token = token.Token,
                RefreshToken = token.RefreshToken,
                ResponseUserModel = _mapper.Map<ResponseUserModel>(userLogin)
            };

            return new ResponseModel
            {
                Data = responseTokenModel,
                StatusCode = StatusCodes.Status200OK
            };
        }

        public ResponseModel SignUp(SignUpModel signUpModel)
        {
            var userEntity = _mapper.Map<UserEntity>(signUpModel);
            var existUserSignUp = _userRepository.GetSingle(x => x.userName.Equals(signUpModel.userName));
            if (existUserSignUp != null)
            {
                return new ResponseModel
                {
                    MessageError = "Username already exists",
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            _userRepository.Create(userEntity);
            return new ResponseModel
            {
                Data = userEntity,
                StatusCode = StatusCodes.Status201Created
            };
        }
    }
}
