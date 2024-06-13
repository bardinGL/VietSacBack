using VietSacBackend._4.Core.Model.Product;
using VietSacBackend._4.Core.Model;

namespace VietSacBackend._2.Service.Interface
{
    public interface IProductService
    {
        ResponseModel CreateProduct(RequestProductModel requestProductModel);
        ResponseModel UpdateProduct(string id, RequestProductModel requestProductModel);
        ResponseModel DeleteProduct(string id);
        ResponseModel GetAllProducts();
        ResponseModel GetProductById(string id);
        IEnumerable<ResponseProductModel> GetProductsByBrand(string brand);
        IEnumerable<ResponseProductModel> GetProductsByPurpose(string purpose);
        IEnumerable<ResponseProductModel> GetProductsByCategory(string categoryId);
    }
}
