using System.Collections.Generic;
using Csharp_REST_API.Models;

namespace Csharp_REST_API.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAppCommands();
        Command GetCommandById(int id);
    }
}