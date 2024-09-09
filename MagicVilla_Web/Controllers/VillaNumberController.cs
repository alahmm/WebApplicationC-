using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MagicVilla_Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IVillaNumberService _villaNumberService;
        private readonly IMapper _mapper;

        public VillaNumberController(IVillaNumberService villaNumberService, IMapper mapper)
        {
                _mapper = mapper;
            _villaNumberService = villaNumberService;
        }
        public async Task<IActionResult> IndexVillaNumber()
        {
			List<VillaNumberDTO> list = new();
			var response = await _villaNumberService.GetAllAsync<APIResponse>();

			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<VillaNumberDTO>>(Convert.ToString(response.Result));
			}
		
			return View(list);
		}

		//public async Task<IActionResult> CreateVilla()
		//{
			
		//	return View();
		//}

		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> CreateVilla(VillaDTOCreate villaDTO)
		//{
		//	if (ModelState.IsValid)//check the validity of properties that we defined alredy in villacreteDTO
		//	{
		//		var response = await _villaService.CreateAsync<APIResponse>(villaDTO);

		//		if (response != null && response.IsSuccess)
		//		{
		//			return RedirectToAction(nameof(IndexVilla));
		//		}
		//	}
		//	return View(villaDTO);
		//}

  //      public async Task<IActionResult> UpdateVilla(int villaId)
  //      {

  //          var response = await _villaService.GetAsync<APIResponse>(villaId);

  //          if (response != null && response.IsSuccess)
  //          {
  //              VillaDTO model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
  //              return View(_mapper.Map<VillaDTOUpdate>(model));
  //          }

  //          return NotFound();
  //      }

  //      [HttpPost]
  //      [ValidateAntiForgeryToken]
  //      public async Task<IActionResult> UpdateVilla(VillaDTOUpdate villaDTO)
  //      {
  //          if (ModelState.IsValid)//check the validity of properties that we defined alredy in villacreteDTO
  //          {
  //              var response = await _villaService.UpdateAsync<APIResponse>(villaDTO);

  //              if (response != null && response.IsSuccess)
  //              {
  //                  return RedirectToAction(nameof(IndexVilla));
  //              }
  //          }
  //          return View(villaDTO);//update view
  //      }

  //      public async Task<IActionResult> DeleteVilla(int villaId)
  //      {

  //          var response = await _villaService.GetAsync<APIResponse>(villaId);

  //          if (response != null && response.IsSuccess)
  //          {
  //              VillaDTO model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
  //              return View(model);
  //          }

  //          return NotFound();
  //      }

  //      [HttpPost]
  //      [ValidateAntiForgeryToken]
  //      public async Task<IActionResult> DeleteVilla(VillaDTO villaDTO)
  //      {

  //           var response = await _villaService.DeleteAsync<APIResponse>(villaDTO.Id);

  //          if (response != null && response.IsSuccess)
  //          {
  //              return RedirectToAction(nameof(IndexVilla));
  //          }
  //          return View(villaDTO);//delete view
  //      }
    }
}
