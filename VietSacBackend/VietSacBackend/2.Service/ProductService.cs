using AutoMapper;
using VietSacBackend._2.Service.Interface;
using VietSacBackend._3.Repository.Repository;
using VietSacBackend._3.Repository.Data;
using VietSacBackend._4.Core.Model.Product;
using VietSacBackend._4.Core.Model;

namespace VietSacBackend._2.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public ResponseModel CreateProduct(RequestProductModel requestProductModel)
        {
            var productEntity = _mapper.Map<ProductEntity>(requestProductModel);
            _productRepository.Create(productEntity);
            return new ResponseModel
            {
                Data = _mapper.Map<ResponseProductModel>(productEntity),
                StatusCode = StatusCodes.Status201Created
            };
        }

        public ResponseModel UpdateProduct(string id, RequestProductModel requestProductModel)
        {
            var productEntity = _productRepository.GetById(id);
            if (productEntity == null)
            {
                return new ResponseModel
                {
                    MessageError = "Product not found",
                    StatusCode = StatusCodes.Status404NotFound
                };
            }

            _mapper.Map(requestProductModel, productEntity);
            _productRepository.Update(productEntity);
            return new ResponseModel
            {
                Data = _mapper.Map<ResponseProductModel>(productEntity),
                StatusCode = StatusCodes.Status200OK
            };
        }

        public ResponseModel DeleteProduct(string id)
        {
            var productEntity = _productRepository.GetById(id);
            if (productEntity == null)
            {
                return new ResponseModel
                {
                    MessageError = "Product not found",
                    StatusCode = StatusCodes.Status404NotFound
                };
            }

            _productRepository.Delete(productEntity);
            return new ResponseModel
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public ResponseModel GetProductById(string id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return new ResponseModel
                {
                    MessageError = "Product not found",
                    StatusCode = StatusCodes.Status404NotFound
                };
            }

            return new ResponseModel
            {
                Data = _mapper.Map<ResponseProductModel>(product),
                StatusCode = StatusCodes.Status200OK
            };
        }

        public ResponseModel GetAllProducts()
        {
            var products = _productRepository.GetAll();
            return new ResponseModel
            {
                Data = _mapper.Map<List<ResponseProductModel>>(products),
                StatusCode = StatusCodes.Status200OK
            };
        }

        public IEnumerable<ResponseProductModel> GetProductsByCategory(string categoryId)
        {
            var products = _productRepository.Get(p => p.category_id == categoryId);
            return _mapper.Map<IEnumerable<ResponseProductModel>>(products);
        }

        public IEnumerable<ResponseProductModel> GetProductsByBrand(string brand)
        {
            var products = _productRepository.Get(p => p.Category.Brand == brand);
            return _mapper.Map<IEnumerable<ResponseProductModel>>(products);
        }

        public IEnumerable<ResponseProductModel> GetProductsByPurpose(string purpose)
        {
            var products = _productRepository.Get(p => p.Category.Purpose == purpose);
            return _mapper.Map<IEnumerable<ResponseProductModel>>(products);
        }
    }
}
