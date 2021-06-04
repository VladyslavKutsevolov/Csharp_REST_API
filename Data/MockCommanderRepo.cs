using System.Collections.Generic;
using Csharp_REST_API.Models;

namespace Csharp_REST_API.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        { 
            var commands = new List<Command>
            {
                new Command {Id = 0, HowTo = "Do something", Line = "something", Platform = "something else"},
                new Command {Id = 1, HowTo = "Do something2", Line = "something2", Platform = "something else2"},
                new Command {Id = 2, HowTo = "Do something3", Line = "something3", Platform = "something else3"}
            };
            
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{Id = 0, HowTo = "Do something", Line = "something", Platform = "something else"};
        }

        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}