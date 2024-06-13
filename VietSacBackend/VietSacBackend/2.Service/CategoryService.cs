using AutoMapper;
using VietSacBackend._2.Service.Interface;
using VietSacBackend._3.Repository.Repository;
using VietSacBackend._3.Repository.Data;
using VietSacBackend._4.Core.Model.Category;
using VietSacBackend._4.Core.Model;

namespace VietSacBackend._2.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public ResponseModel CreateCategory(RequestCategoryModel requestCategoryModel)
        {
            var categoryEntity = _mapper.Map<CategoryEntity>(requestCategoryModel);
            _categoryRepository.Create(categoryEntity);
            return new ResponseModel
            {
                Data = _mapper.Map<ResponseCategoryModel>(categoryEntity),
                StatusCode = StatusCodes.Status201Created
            };
        }

        public ResponseModel UpdateCategory(string id, RequestCategoryModel requestCategoryModel)
        {
            var categoryEntity = _categoryRepository.GetById(id);
            if (categoryEntity == null)
            {
                return new ResponseModel
                {
                    MessageError = "Category not found",
                    StatusCode = StatusCodes.Status404NotFound
                };
            }

            _mapper.Map(requestCategoryModel, categoryEntity);
            _categoryRepository.Update(categoryEntity);
            return new ResponseModel
            {
                Data = _mapper.Map<ResponseCategoryModel>(categoryEntity),
                StatusCode = StatusCodes.Status200OK
            };
        }

        public ResponseModel DeleteCategory(string id)
        {
            var categoryEntity = _categoryRepository.GetById(id);
            if (categoryEntity == null)
            {
                return new ResponseModel
                {
                    MessageError = "Category not found",
                    StatusCode = StatusCodes.Status404NotFound
                };
            }

            _categoryRepository.Delete(categoryEntity);
            return new ResponseModel
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public ResponseModel GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            return new ResponseModel
            {
                Data = _mapper.Map<List<ResponseCategoryModel>>(categories),
                StatusCode = StatusCodes.Status200OK
            };
        }

        public ResponseModel GetCategoryById(string id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                return new ResponseModel
                {
                    MessageError = "Category not found",
                    StatusCode = StatusCodes.Status404NotFound
                };
            }

            return new ResponseModel
            {
                Data = _mapper.Map<ResponseCategoryModel>(category),
                StatusCode = StatusCodes.Status200OK
            };
        }

        public IEnumerable<ResponseCategoryModel> GetCategoriesByBrand(string brand)
        {
            var categories = _categoryRepository.Get(c => c.Brand == brand);
            return _mapper.Map<IEnumerable<ResponseCategoryModel>>(categories);
        }

        public IEnumerable<ResponseCategoryModel> GetCategoriesByPurpose(string purpose)
        {
            var categories = _categoryRepository.Get(c => c.Purpose == purpose);
            return _mapper.Map<IEnumerable<ResponseCategoryModel>>(categories);
        }
    }
}
