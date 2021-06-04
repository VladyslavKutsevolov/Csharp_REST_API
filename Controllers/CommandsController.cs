
using System.Collections.Generic;
using AutoMapper;
using Csharp_REST_API.Data;
using Csharp_REST_API.Dtos;
using Csharp_REST_API.Models;
using Microsoft.AspNetCore.JsonPatch;
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
        
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            if (commandItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CommandReadDto>(commandItem));
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto cmdCreateDto)
        {
            var commandModel = _mapper.Map<Command>(cmdCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDto.Id}, commandReadDto);

        }

        [HttpPut("{id}")]

        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var command = _repository.GetCommandById(id);

            if (command == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, command);
            _repository.UpdateCommand(command);

            _repository.SaveChanges();

            return NoContent();

        }


        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDocument)
        {
            var command = _repository.GetCommandById(id);

            if (command == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(command);
            
            patchDocument.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }
            
            _mapper.Map(commandToPatch, command);
            _repository.UpdateCommand(command);
            _repository.SaveChanges();
            
            return NoContent();
        }
            
    }
}