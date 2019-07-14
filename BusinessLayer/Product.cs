using BusinessLayer.Interfaces;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Product : IProduct
    {
        private readonly IUnitOfWork _uow;
        public Product(IUnitOfWork uow)
        {
            _uow = uow;
        }
        
        public bool AddProductToUser(long userId, long productId)
        {
            if (userId <= default(int))     
                throw new ArgumentException("Invalid user id");
            if (productId <= default(int))
                throw new ArgumentException("Invalid product id");
            if (_uow.Product.GetProduct(productId) == null)
                throw new InvalidOperationException("Invalid product");
            if (_uow.User.GetUser(userId) == null)
                throw new InvalidOperationException("Invalid user");

            var userProducts = _uow.Product.GetUserProducts(userId);
            if (userProducts.Any(up => up.Id == productId))
                throw new InvalidOperationException("Products are already maped");

            _uow.Product.AddProductToUser(userId, productId);
            _uow.Complete();
            return true;
        }

        public bool DeleteProduct(long productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetUserProducts(long userId)
        {
            throw new NotImplementedException();
        }

        public Product UpsertProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
