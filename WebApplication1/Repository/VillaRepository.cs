using Magi.Repository.IRepository;
using WebApplication1.Data;
using WebApplication1.Models;

namespace Magi.Repository
{
    public class VillaRepository : Repository<Villa>, IVillaRepository 
    {
        private readonly ApplicationDbContext _db;
        public VillaRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public async Task<Villa> Update(Villa villa)
        {
            villa.UpdatedDate = DateTime.Now;
            _db.Villas.Update(villa);
            await _db.SaveChangesAsync();
            return villa;
        }
    }
}
