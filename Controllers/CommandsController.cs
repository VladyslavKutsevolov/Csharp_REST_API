
using System.Collections.Generic;
using AutoMapper;
using Csharp_REST_API.Data;
using Csharp_REST_API.Dtos;
using Csharp_REST_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Csharp_REST_API.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            
            

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems)); 
        }
        
        [HttpGet("{id}")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            if (commandItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CommandReadDto>(commandItem));
        }
    }
}