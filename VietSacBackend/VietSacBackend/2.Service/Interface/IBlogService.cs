using System.Threading.Tasks;
using VietSacBackend._4.Core.Model;
using VietSacBackend._4.Core.Model.Blog;

namespace VietSacBackend._2.Service.Interface
{
    public interface IBlogService
    {
        Task<ResponseBlogModel> GetBlogByIdAsync(string id);
        Task<ResponseModel> AddBlogAsync(RequestBlogModel requestBlogModel);
    }
}
