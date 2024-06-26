using AutoMapper;
using VietSacBackend._3.Repository.Data;
using VietSacBackend._4.Core.Model.Auth;
using VietSacBackend._4.Core.Model.Category;
using VietSacBackend._4.Core.Model.Product;
using VietSacBackend._4.Core.Model.Role;
using VietSacBackend._4.Core.Model.User;
using VietSacBackend._4.Core.Model.Order;

namespace VietSacBackend._4.Core.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            //Role
            CreateMap<RoleEntity, RequestRoleModel>().ReverseMap();
            CreateMap<RoleEntity, ResponseRoleModel>().ReverseMap();

            //User
            CreateMap<UserEntity, RequestUserModel>().ReverseMap();
            CreateMap<UserEntity, ResponseUserModel>().ReverseMap();

            //User Auth
            CreateMap<UserEntity, SignUpModel>().ReverseMap();
            CreateMap<UserEntity, SignInModel>().ReverseMap();

            //Product
            CreateMap<ProductEntity, ProductModel>().ReverseMap();
            //CreateMap<RequestProductModel, ProductEntity>().ReverseMap();
            CreateMap<RequestProductModel, ProductEntity>()
            .ForMember(dest => dest.category_id, opt => opt.MapFrom(src => src.category_id)) 
            .ReverseMap();
            CreateMap<ProductEntity, ResponseProductModel>().ReverseMap();
            CreateMap<ProductEntity, GetProductModel>().ReverseMap();

            //Category
            CreateMap<CategoryEntity, RequestCategoryModel>().ReverseMap();
            CreateMap<CategoryEntity, ResponseCategoryModel>().ReverseMap();

            // Order
            CreateMap<OrderEntity, RequestOrderModel>().ReverseMap();
            CreateMap<OrderEntity, ResponseOrderModel>().ReverseMap();

            // Cart
            CreateMap<CartEntity, RequestCartModel>().ReverseMap();
            CreateMap<CartEntity, ResponseCartModel>().ReverseMap();
        }
    }
}
