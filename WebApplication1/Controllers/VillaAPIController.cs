using AutoMapper;
using Magi.Models;
using Magi.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.Dto;

namespace WebApplication1.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]//activate the validation
    public class VillaAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IVillaRepository _villaRepository;
        private readonly IMapper _mapper;
        public VillaAPIController(IVillaRepository villaReposirory, IMapper mapper)
        {
            _villaRepository = villaReposirory;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetVillas()
        {
            try
            {
                IEnumerable<Villa> villas = await _villaRepository.GetAll();
                _response.Result = _mapper.Map<List<VillaDTO>>(villas);
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

        [HttpGet("{id:int}", Name = "GetVilla")]//or {id:int}
                                                //[ProducesResponseType(200), Type = typeof(VillaDTO)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCodeCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var villa = await _villaRepository.Get(u => u.Id == id);
                if (villa == null)
                {
                    _response.StatusCodeCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<VillaDTO>(villa);
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
        public async Task<ActionResult<APIResponse>> createVilla([FromBody] VillaDTOCreate createDTO)
        {
            try
            {
                if (await _villaRepository.Get(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("customError", "Villa already exists");//
                    return BadRequest(ModelState);
                }
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }
                //we need to convert villaDto to villa

                Villa model = _mapper.Map<Villa>(createDTO);

                await _villaRepository.Create(model);

                _response.Result = _mapper.Map<VillaDTO>(model);
                _response.StatusCodeCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetVilla", new { id = model.Id }, _response);// this returns 201 or just ok(object)
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<APIResponse>> DeleteVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var villa = await _villaRepository.Get(u => u.Id == id);
                if (villa == null)
                {
                    return NotFound();
                }
                await _villaRepository.Remove(villa);

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

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<APIResponse>> updateVilla(int id, [FromBody] VillaDTOUpdate updateDTO)
        {
            try
            {

                if (updateDTO == null || updateDTO.Id != id)
                {
                    return BadRequest();
                }

                Villa model = _mapper.Map<Villa>(updateDTO);

                await _villaRepository.Update(model);

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


        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> updatePartialVilla(int id, JsonPatchDocument<VillaDTOUpdate> patchDTO)
        {
                if (patchDTO == null || id == 0)
                {
                    return BadRequest();
                }
                var villa = await _villaRepository.Get(u => u.Id == id, tracked: false);//to have the ability to use the same id again for the model

                VillaDTOUpdate villaDTOUpdate = _mapper.Map<VillaDTOUpdate>(villa);

                if (villa == null)
                {
                    return NotFound();
                }
                patchDTO.ApplyTo(villaDTOUpdate, ModelState);

                Villa model = _mapper.Map<Villa>(villaDTOUpdate);
                await _villaRepository.Update(model);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return NoContent();

        }
    }
}
