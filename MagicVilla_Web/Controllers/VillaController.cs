using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVilla_Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;

        public VillaController(IVillaService villaService, IMapper mapper)
        {
                _mapper = mapper;
            _villaService = villaService;
        }
        public async Task<IActionResult> IndexVilla()
        {
			List<VillaDTO> list = new();
			try
			{
				var response2 = await _villaService.GetAsync<APIResponse>(4);

				var response = await _villaService.GetAllAsync<APIResponse>();

				if (response != null && response.IsSuccess)
				{
					list = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Fehler: {ex.Message}");
			}

			return View(list);
		}
    }
}
