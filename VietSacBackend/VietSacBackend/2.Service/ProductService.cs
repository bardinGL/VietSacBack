using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
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
        private readonly VietSacContext _context;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, VietSacContext context, IMapper mapper)
        {
            _productRepository = productRepository;
            _context = context;
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
            var productEntity = _context.productEntities
                .Include(p => p.Category)
                .FirstOrDefault(p => p.Id == id);

            if (productEntity == null)
            {
                return new ResponseModel
                {
                    MessageError = "Product not found",
                    StatusCode = StatusCodes.Status404NotFound
                };
            }

            // Ensure category_id is not inadvertently set to null
            if (string.IsNullOrWhiteSpace(requestProductModel.category_id))
            {
                requestProductModel.category_id = productEntity.category_id;
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
            var product = _context.productEntities
                .Include(p => p.Category)
                .FirstOrDefault(p => p.Id == id);

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
            var products = _context.productEntities
                .Include(p => p.Category)
                .ToList();

            return new ResponseModel
            {
                Data = _mapper.Map<List<ResponseProductModel>>(products),
                StatusCode = StatusCodes.Status200OK
            };
        }

        public IEnumerable<ResponseProductModel> GetProductsByCategory(string categoryId)
        {
            var products = _context.productEntities
                .Include(p => p.Category)
                .Where(p => p.category_id == categoryId)
                .ToList();

            return _mapper.Map<IEnumerable<ResponseProductModel>>(products);
        }

        public IEnumerable<ResponseProductModel> GetProductsByBrand(string brand)
        {
            var products = _context.productEntities
                .Include(p => p.Category)
                .Where(p => p.Category.Brand == brand)
                .ToList();

            return _mapper.Map<IEnumerable<ResponseProductModel>>(products);
        }

        public IEnumerable<ResponseProductModel> GetProductsByPurpose(string purpose)
        {
            var products = _context.productEntities
                .Include(p => p.Category)
                .Where(p => p.Category.Purpose == purpose)
                .ToList();

            return _mapper.Map<IEnumerable<ResponseProductModel>>(products);
        }

        // New methods to handle product images
        public IEnumerable<string> GetAllProductImages()
        {
            var products = _context.productEntities.ToList();
            return products.Select(p => p.image).Where(img => img != null).ToList();
        }

        public string GetProductImageById(string id)
        {
            var product = _productRepository.GetById(id);
            return product?.image;
        }

        public ResponseModel<GetProductModel> GetProductsWithHighestDiscount()
        {
            var products = _context.productEntities.ToList();

            // Order by discount descending and take the top three products
            var topThreeDiscountProducts = products
                .OrderByDescending(p => p.discount)
                .Take(3)
                .ToList();

            return new ResponseModel<GetProductModel>
            {
                Data = _mapper.Map<List<GetProductModel>>(topThreeDiscountProducts),
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}
