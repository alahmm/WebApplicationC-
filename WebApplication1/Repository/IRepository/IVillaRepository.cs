
using WebApplication1.Models;

namespace Magi.Repository.IRepository
{
    public interface IVillaRepository : IRepository<Villa>
    {
        Task<Villa> Update(Villa villa);
    }
}
