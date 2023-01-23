using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            var platformItem = _repository.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));

        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatform(int id)
        {
            var platformItem = _repository.GetPlatformById(id);
            if (platformItem is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PlatformReadDto>(platformItem));

        }

        [HttpPost]
        public ActionResult<PlatformReadDto> AddPlatform(PlatformCreateDto plat)
        {
            var platformItem = _mapper.Map<Platform>(plat);
            _repository.CreatePlatform(platformItem);
            _repository.SaveChanges();

            var platformReadDto = _mapper.Map<PlatformReadDto>(platformItem);

            return CreatedAtRoute("GetPlatformById", new { Id = platformReadDto.Id }, platformReadDto);
        }


    }
}
