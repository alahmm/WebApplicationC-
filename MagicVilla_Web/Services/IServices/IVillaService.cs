using MagicVilla_Web.Models.Dto;

namespace MagicVilla_Web.Services.IServices
{
    public interface IVillaService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(VillaDTOCreate dto);
        Task<T> UpdateAsync<T>(VillaDTOUpdate dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
