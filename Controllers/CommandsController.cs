
using System.Collections.Generic;
using Csharp_REST_API.Data;
using Csharp_REST_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Csharp_REST_API.Controllers
{
    [Route("api/command")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;

        public CommandsController(ICommanderRepo repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAppCommands();

            return Ok(commandItems); 
        }
        
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            return Ok(commandItem);
        }
    }
}