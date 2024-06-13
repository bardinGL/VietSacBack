    using VietSacBackend._4.Core.Model.Auth;
    using VietSacBackend._4.Core.Model;

    namespace VietSacBackend._2.Service.Interface
    {
        public interface IAuthService
        {
            public ResponseModel SignUp(SignUpModel signUpModel);
            public ResponseModel SignIn(SignInModel signInModel);
        }
    }
