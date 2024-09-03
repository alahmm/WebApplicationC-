using Magi.Models;
using Magi.Repository.IRepository;
using WebApplication1.Data;
using WebApplication1.Models;

namespace Magi.Repository
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly ApplicationDbContext _db;
        public VillaNumberRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public async Task<VillaNumber> Update(VillaNumber villaNumber)
        {
            villaNumber.UpdatedDate = DateTime.Now;
            _db.VillaNumbers.Update(villaNumber);
            await _db.SaveChangesAsync();
            return villaNumber;
        }
    }
}
