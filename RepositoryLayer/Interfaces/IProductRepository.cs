using DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        Product GetProduct(long id);
        IEnumerable<Product> GetProducts();
        bool DeleteProduct(long productId);
        IEnumerable<Product> GetUserProducts(long userId);
        void AddProductToUser(long userId, long productId);
    }
}
