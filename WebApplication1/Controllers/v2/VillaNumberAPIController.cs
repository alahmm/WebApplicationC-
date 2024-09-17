using Asp.Versioning;
using AutoMapper;
using Magi.Models;
using Magi.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.Dto;

namespace Magi.Controllers.v2
{
    [Route("/api/v{version:apiVersion}/VillaNumberAPI")]
    [ApiController]//activate the validation
    [ApiVersion("2.0", Deprecated = true)]
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
            _response = new();
            _villaRepository = villaRepository;
        }

        //[MapToApiVersion("2.0")]
        [HttpGet("GetString")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
