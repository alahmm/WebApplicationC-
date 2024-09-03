
using Magi.Models;
using WebApplication1.Models;

namespace Magi.Repository.IRepository
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {
        Task<VillaNumber> Update(VillaNumber villaNumber);
    }
}
