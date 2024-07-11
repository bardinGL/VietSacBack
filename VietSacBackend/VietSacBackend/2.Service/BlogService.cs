using System.Threading.Tasks;
using AutoMapper;
using VietSacBackend._2.Service.Interface;
using VietSacBackend._3.Repository.Repository;
using VietSacBackend._4.Core.Model.Blog;
using VietSacBackend._4.Core.Model;
using VietSacBackend._3.Repository.Data;

namespace VietSacBackend._2.Service
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public BlogService(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<ResponseModel> AddBlogAsync(RequestBlogModel requestBlogModel)
        {
            var blogEntity = _mapper.Map<BlogEntity>(requestBlogModel);
            await Task.Run(() => _blogRepository.Create(blogEntity));

            return new ResponseModel
            {
                Data = _mapper.Map<ResponseBlogModel>(blogEntity),
                StatusCode = StatusCodes.Status201Created
            };
        }

        public async Task<ResponseBlogModel> GetBlogByIdAsync(string id)
        {
            var blog = await Task.Run(() => _blogRepository.GetById(id));
            if (blog == null)
            {
                return null;
            }

            return _mapper.Map<ResponseBlogModel>(blog);
        }

        public async Task<IEnumerable<ResponseBlogModel>> GetAllBlogsAsync()
        {
            var blogs = await Task.Run(() => _blogRepository.GetAll());
            return _mapper.Map<IEnumerable<ResponseBlogModel>>(blogs);
        }
    }
}
