using BagShop.Common.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace BagShop.Common.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role FindByName(string roleName);
        Task<Role> FindByNameAsync(string roleName);
        Task<Role> FindByNameAsync(CancellationToken cancellationToken, string roleName);
    }
}
