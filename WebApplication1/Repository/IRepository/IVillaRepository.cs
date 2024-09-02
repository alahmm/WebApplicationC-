using System.Linq.Expressions;
using WebApplication1.Models;

namespace Magi.Repository.IRepository
{
    public interface IVillaRepository
    {
        Task<List<Villa>> GetAll(Expression<Func<Villa, bool>> filter = null);

        Task<Villa> Get(Expression<Func<Villa>> filter = null, bool tracked = true);

        Task Create(Villa villa);
        Task Remove(Villa villa);
        Task Save();
        Task Update (Villa villa);
    }
}
