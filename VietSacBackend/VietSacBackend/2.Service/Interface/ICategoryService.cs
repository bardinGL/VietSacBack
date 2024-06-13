using VietSacBackend._4.Core.Model;
using VietSacBackend._4.Core.Model.Category; // Ensure you have Category models

namespace VietSacBackend._2.Service.Interface
{
    public interface ICategoryService
    {
        ResponseModel CreateCategory(RequestCategoryModel requestCategoryModel);
        ResponseModel UpdateCategory(string id, RequestCategoryModel requestCategoryModel);
        ResponseModel DeleteCategory(string id);
        ResponseModel GetAllCategories();
        ResponseModel GetCategoryById(string id);
        IEnumerable<ResponseCategoryModel> GetCategoriesByBrand(string brand);
        IEnumerable<ResponseCategoryModel> GetCategoriesByPurpose(string purpose);
    }
}
