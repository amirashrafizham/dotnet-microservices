using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;
using PlatformService.SyncDataServices.Http;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public PlatformsController(IPlatformRepo repository, IMapper mapper, ICommandDataClient commandDataClient)
        {
            _repository = repository;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
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
        public async Task<ActionResult<PlatformReadDto>> AddPlatform(PlatformCreateDto plat)
        {
            var platformItem = _mapper.Map<Platform>(plat);
            _repository.CreatePlatform(platformItem);
            _repository.SaveChanges();

            var platformReadDto = _mapper.Map<PlatformReadDto>(platformItem);

            try
            {
                await _commandDataClient.SendPlatformToCcommand(platformReadDto);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"---> Could not send syncrhonously: {ex.Message}");
            }

            return CreatedAtRoute("GetPlatformById", new { Id = platformReadDto.Id }, platformReadDto);
        }


    }
}
