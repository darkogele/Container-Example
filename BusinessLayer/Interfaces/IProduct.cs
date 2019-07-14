using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IProduct
    {
        Product UpsertProduct(Product product);
        IEnumerable<Product> GetProducts();
        bool DeleteProduct(long productId);
        IEnumerable<Product> GetUserProducts(long userId);
        bool AddProductToUser(long userId, long productId);
    }
}
