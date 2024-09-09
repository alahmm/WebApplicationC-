using AutoMapper;
using Magi.Models;
using Magi.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.Dto;

namespace WebApplication1.Controllers
{
    [Route("/api/VillaNumberAPI")]
    [ApiController]//activate the validation
    public class VillaNumberAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IVillaNumberRepository _villaNumberRepository;
        private readonly IMapper _mapper;
        private readonly IVillaRepository _villaRepository;
        public VillaNumberAPIController(IVillaNumberRepository villaNumberReposirory, IMapper mapper, IVillaRepository villaRepository)
        {
            _villaNumberRepository = villaNumberReposirory;
            _mapper = mapper;
            this._response = new();
            _villaRepository = villaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetVillaNumbers()
        {
            try
            {
                IEnumerable<VillaNumber> villaNumbers = await _villaNumberRepository.GetAll(includeProperties:"Villa");
                _response.Result = _mapper.Map<List<VillaNumberDTO>>(villaNumbers);
                _response.StatusCodeCode = HttpStatusCode.OK;
                return Ok(_response);//the distenation type is between <>
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id:int}", Name = "GetVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCodeCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var villaNumber = await _villaNumberRepository.Get(u => u.VillaNo == id);
                if (villaNumber == null)
                {
                    _response.StatusCodeCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<VillaNumberDTO>(villaNumber);
                _response.StatusCodeCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> createVillaNumber([FromBody] VillaNumberCreateDTO createDTO)
        {
            try
            {
                var villa = await _villaRepository.Get(u => u.Id == createDTO.VillaID);
                if (villa == null)
                {
                    ModelState.AddModelError("customError", "Villa ID is Invalid.");
                    return BadRequest(ModelState);
                }
                if (await _villaNumberRepository.Get(u => u.VillaNo == createDTO.VillaNo) != null)
                {
                    ModelState.AddModelError("customError", "Villa Number already exists");//
                    return BadRequest(ModelState);
                }
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                VillaNumber model = _mapper.Map<VillaNumber>(createDTO);

                await _villaNumberRepository.Create(model);

                _response.Result = _mapper.Map<VillaNumberDTO>(model);
                _response.StatusCodeCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetVillaNumber", new { id = model.VillaNo }, _response);// this returns 201 or just ok(object)
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpDelete("{id:int}", Name = "DeleteVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var villaNumber = await _villaNumberRepository.Get(u => u.VillaNo == id);
                if (villaNumber == null)
                {
                    return NotFound();
                }
                await _villaNumberRepository.Remove(villaNumber);

                _response.StatusCodeCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut("{id:int}", Name = "UpdateVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<APIResponse>> updateVillaNumber(int id, [FromBody] VillaNumberUpdateDTO updateDTO)
        {
            try { 
                var villa = await _villaRepository.Get(u => u.Id == updateDTO.VillaID);
            if (villa == null)
            {
                ModelState.AddModelError("customError", "Villa ID is Invalid.");
                return BadRequest(ModelState);
            }

            if (updateDTO == null || updateDTO.VillaNo != id)
                {
                    return BadRequest();
                }

                VillaNumber model = _mapper.Map<VillaNumber>(updateDTO);

                await _villaNumberRepository.Update(model);

                _response.StatusCodeCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }


        [HttpPatch("{id:int}", Name = "UpdatePartialVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> updatePartialVillaNumber(int id, JsonPatchDocument<VillaNumberUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var villaNumber = await _villaNumberRepository.Get(u => u.VillaNo == id, tracked: false);//to have the ability to use the same id again for the model

            VillaNumberUpdateDTO villaNumberUpdateDTO = _mapper.Map<VillaNumberUpdateDTO>(villaNumber);

            if (villaNumber == null)
            {
                return NotFound();
            }
            patchDTO.ApplyTo(villaNumberUpdateDTO, ModelState);

            VillaNumber model = _mapper.Map<VillaNumber>(villaNumberUpdateDTO);
            await _villaNumberRepository.Update(model);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();

        }
    }
}
