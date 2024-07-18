using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using VietSacBackend._2.Service.Interface;
using VietSacBackend._3.Repository.BaseRepository;
using VietSacBackend._3.Repository.Data;
using VietSacBackend._4.Core.Model.Order;
using VietSacBackend._4.Core.Model;
using VietSacBackend._3.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace VietSacBackend._2.Service
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IGenericRepository<UserEntity> _userRepository;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly VietSacContext _context;

        public CartService(
            ICartRepository cartRepository,
            IProductRepository productRepository,
            IGenericRepository<UserEntity> userRepository,
            IProductService productService,
            ICategoryService categoryService,
            IMapper mapper,
            VietSacContext context)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
            _context = context;
        }

        public ResponseModel AddToCart(string userId, RequestCartModel requestCart)
        {
            // Validate user
            var user = _userRepository.GetById(userId);
            if (user == null)
            {
                return new ResponseModel
                {
                    MessageError = "User not found",
                    StatusCode = StatusCodes.Status404NotFound
                };
            }

            // Validate product
            var productResponse = _productService.GetProductById(requestCart.ProductId);
            if (productResponse == null || productResponse.Data == null)
            {
                return new ResponseModel
                {
                    MessageError = "Product not found",
                    StatusCode = StatusCodes.Status404NotFound
                };
            }

            var product = _mapper.Map<ProductEntity>(productResponse.Data);

            // Fetch and set the category explicitly
            var categoryResponse = _categoryService.GetCategoryById(product.category_id);
            if (categoryResponse != null && categoryResponse.Data != null)
            {
                var category = _mapper.Map<CategoryEntity>(categoryResponse.Data);
                var existingCategory = _context.categoryEntities.Local.FirstOrDefault(c => c.Id == category.Id);
                if (existingCategory == null)
                {
                    _context.Entry(category).State = EntityState.Unchanged;
                    product.Category = category;
                }
                else
                {
                    product.Category = existingCategory;
                }
            }

            // Calculate total price
            var totalPrice = (product.price ?? 0) * requestCart.Quantity;

            Console.WriteLine($"User ID: {userId}");
            Console.WriteLine($"Product ID: {requestCart.ProductId}, Quantity: {requestCart.Quantity}, Total Price: {totalPrice}");

            // Check if the item already exists in the cart
            var existingCartItem = _cartRepository.Get(c => c.user_id == userId && c.product_id == requestCart.ProductId).FirstOrDefault();
            if (existingCartItem != null)
            {
                // Update the quantity and total price if the item already exists
                existingCartItem.quantity += requestCart.Quantity;
                existingCartItem.price += totalPrice;
                _cartRepository.Update(existingCartItem);
                return new ResponseModel
                {
                    Data = _mapper.Map<ResponseCartModel>(existingCartItem),
                    StatusCode = StatusCodes.Status200OK
                };
            }

            // Add new item to the cart
            var cartEntity = _mapper.Map<CartEntity>(requestCart);
            cartEntity.user_id = userId; // Set the UserId
            cartEntity.price = totalPrice; // Set total price
            cartEntity.product_id = product.Id; // Set ProductId
            cartEntity.quantity = requestCart.Quantity; // Set quantity
            cartEntity.order_id = null; // Initialize order_id if not part of the request

            // Set navigation properties
            cartEntity.Product = null;
            cartEntity.User = null;

            // Create the cart entity
            _cartRepository.Create(cartEntity);

            // Attach the navigation properties after creation to avoid tracking conflicts
            cartEntity.Product = product;
            cartEntity.User = user;

            // Save changes again to update the relationships
            _context.SaveChanges();

            return new ResponseModel
            {
                Data = _mapper.Map<ResponseCartModel>(cartEntity),
                StatusCode = StatusCodes.Status201Created
            };
        }






        public ResponseCartModel GetCartById(string id)
        {
            var cart = _cartRepository.Get(c => c.Id == id, c => c.Product, c => c.User).FirstOrDefault();
            if (cart == null) return null;

            // Ensure the related category is included and tracked properly
            var product = cart.Product;
            if (product != null)
            {
                var categoryResponse = _categoryService.GetCategoryById(product.category_id);
                if (categoryResponse != null && categoryResponse.Data != null)
                {
                    var category = _mapper.Map<CategoryEntity>(categoryResponse.Data);
                    var existingCategory = _context.categoryEntities.Local.FirstOrDefault(c => c.Id == category.Id);
                    if (existingCategory == null)
                    {
                        _context.Entry(category).State = EntityState.Unchanged;
                        product.Category = category;
                    }
                    else
                    {
                        product.Category = existingCategory;
                    }
                }
            }

            return _mapper.Map<ResponseCartModel>(cart);
        }




        public IEnumerable<ResponseCartModel> GetAllCarts()
        {
            var carts = _cartRepository.Get(null, c => c.Product, c => c.User).ToList();

            foreach (var cart in carts)
            {
                var product = cart.Product;
                if (product != null)
                {
                    var categoryResponse = _categoryService.GetCategoryById(product.category_id);
                    if (categoryResponse != null && categoryResponse.Data != null)
                    {
                        var category = _mapper.Map<CategoryEntity>(categoryResponse.Data);
                        var existingCategory = _context.categoryEntities.Local.FirstOrDefault(c => c.Id == category.Id);
                        if (existingCategory == null)
                        {
                            _context.Entry(category).State = EntityState.Unchanged;
                            product.Category = category;
                        }
                        else
                        {
                            product.Category = existingCategory;
                        }
                    }
                }
            }

            return _mapper.Map<IEnumerable<ResponseCartModel>>(carts);
        }





        public ResponseModel UpdateCart(string id, RequestCartModel requestCart)
        {
            var cartEntity = _cartRepository.GetById(id);
            if (cartEntity == null) throw new Exception("Cart not found");

            _mapper.Map(requestCart, cartEntity);
            _cartRepository.Update(cartEntity);
            return new ResponseModel
            {
                Data = _mapper.Map<ResponseCartModel>(cartEntity),
                StatusCode = StatusCodes.Status200OK
            };
        }

        public bool RemoveFromCart(string id)
        {
            var cartEntity = _cartRepository.GetById(id);
            if (cartEntity == null) return false;

            _cartRepository.Delete(cartEntity);
            return true;
        }

        public List<ResponseCartModel> GetUserCart(string userId)
        {
            var cartEntities = _cartRepository.Get(c => c.user_id == userId).ToList();
            return _mapper.Map<List<ResponseCartModel>>(cartEntities);
        }
    }
}
