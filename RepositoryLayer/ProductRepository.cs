using DomainLayer;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.AppDataContext;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext context;
        public ProductRepository(AppDbContext dbContext)
        {
            this.context = dbContext;
        }

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
        }

        public void AddProductToUser(long userId, long productId)
        {
            context.UserProducts.Add(new UserProduct()
            {
                ProductId = productId,
                UserId = userId
            });
        }

        public bool DeleteProduct(long productId)
        {
            var removed = false;
            Product product = GetProduct(productId);
            if (product != null)
            {
                removed = true;
                context.Products.Remove(product);
            }
            return removed;
        }

        public Product GetProduct(long id)
        {
            return context.Products.Find(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products;
        }

        public IEnumerable<Product> GetUserProducts(long userId)
        {
            //return context.Products.Where(p => p.Id == userId).AsEnumerable();
            return context.UserProducts.Include(up => up.Product)
                  .Where(up => up.UserId == userId)
                  .Select(p => p.Product)
                  .AsEnumerable();
        }
    }
}
