﻿using AutoMapper;
using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

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
			var response = await _villaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));

			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
			}
		
			return View(list);
		}

        [Authorize(Roles ="admin")]
		public async Task<IActionResult> CreateVilla()
		{
			
			return View();
		}

        [Authorize(Roles = "admin")]
        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateVilla(VillaDTOCreate villaDTO)
		{
			if (ModelState.IsValid)//check the validity of properties that we defined alredy in villacreteDTO
			{
				var response = await _villaService.CreateAsync<APIResponse>(villaDTO, HttpContext.Session.GetString(SD.SessionToken));

				if (response != null && response.IsSuccess)
				{
                    TempData["success"] = "Villa created successfully";
                    return RedirectToAction(nameof(IndexVilla));
				}
			}
            TempData["error"] = "Error encountered.";
            return View(villaDTO);
		}

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateVilla(int villaId)
        {

            var response = await _villaService.GetAsync<APIResponse>(villaId, HttpContext.Session.GetString(SD.SessionToken));

            if (response != null && response.IsSuccess)
            {
                VillaDTO model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<VillaDTOUpdate>(model));
            }

            return NotFound();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVilla(VillaDTOUpdate villaDTO)
        {
            if (ModelState.IsValid)//check the validity of properties that we defined alredy in villacreteDTO
            {
                var response = await _villaService.UpdateAsync<APIResponse>(villaDTO, HttpContext.Session.GetString(SD.SessionToken));

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Villa updated successfully";
                    return RedirectToAction(nameof(IndexVilla));
                }
            }
            TempData["error"] = "Error encountered.";
            return View(villaDTO);//update view
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteVilla(int villaId)
        {

            var response = await _villaService.GetAsync<APIResponse>(villaId, HttpContext.Session.GetString(SD.SessionToken));

            if (response != null && response.IsSuccess)
            {
                VillaDTO model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVilla(VillaDTO villaDTO)
        {

             var response = await _villaService.DeleteAsync<APIResponse>(villaDTO.Id, HttpContext.Session.GetString(SD.SessionToken));

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Villa deleted successfully";
                return RedirectToAction(nameof(IndexVilla));
            }
            TempData["error"] = "Error encountered.";
            return View(villaDTO);//delete view
        }
    }
}
