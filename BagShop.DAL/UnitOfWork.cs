using BagShop.Common.Entities;
using BagShop.Common.Interfaces;
using BagShop.DAL.Repositories;
using System;
using System.Threading.Tasks;

namespace BagShop.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private BagShopContext _context;
        private IRepository<Order> _orderRepository;
        private IRepository<BlogPost> _blogPostRepository;
        private IRepository<ShoppingItem> _productRepository;
        private IRepository<Colour> _colourRepository;
        private IExternalLoginRepository _externalLoginRepository;
        private IRoleRepository _roleRepository;
        private IUserRepository _userRepository;
        #endregion

        public UnitOfWork(string connectionString)
        {
            _context = new BagShopContext(connectionString);
        }

        #region IUnitOfWork Members

        public IRepository<Order> OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new Repository<Order>(_context);

                return _orderRepository;
            }
        }

        public IRepository<BlogPost> BlogPostRepository
        {
            get
            {
                if (_blogPostRepository == null)
                    _blogPostRepository = new Repository<BlogPost>(_context);

                return _blogPostRepository;
            }
        }

        public IRepository<ShoppingItem> ProductRepository
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_context);

                return _productRepository;
            }
        }

        public IRepository<Colour> ColourRepository
        {
            get
            {
                if (_colourRepository == null)
                    _colourRepository = new Repository<Colour>(_context);

                return _colourRepository;
            }
        }

        public IExternalLoginRepository ExternalLoginRepository
        {
            get { return _externalLoginRepository ?? (_externalLoginRepository = new ExternalLoginRepository(_context)); }
        }

        public IRoleRepository RoleRepository
        {
            get { return _roleRepository ?? (_roleRepository = new RoleRepository(_context)); }
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_context)); }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            _externalLoginRepository = null;
            _roleRepository = null;
            _userRepository = null;
            _context.Dispose();
        }
        #endregion
    }
}
