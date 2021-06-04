using System.Collections.Generic;
using Csharp_REST_API.Models;

namespace Csharp_REST_API.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
    }
}