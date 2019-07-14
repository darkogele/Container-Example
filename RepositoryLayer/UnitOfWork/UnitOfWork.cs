using RepositoryLayer.AppDataContext;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private IUserRepository _User; 

        private IProductRepository _Product;


        public IUserRepository User
        {
            get
            {
                if (_User != null)
                {
                    _User = new UserRepository(dbContext);
                }
                return _User;
            }
        }

        public IProductRepository Product
        {
            get
            {
                if (_Product != null)
                {
                    _Product = new ProductRepository(dbContext);
                }
                return _Product;
            }
        }

        public int Complete()
        {
            return dbContext.SaveChanges();
        }
        public void Dispose() => dbContext.Dispose();

        public async Task<int> CompleteAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
