using System.Collections.Generic;
using Cluestart.Backend.Models;

namespace Cluestart.Backend.Data
{
    public class CommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAppCommands()
        {
            var commands = new List<Command>
            { new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & pan" },
new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & pan" },
new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & pan" },
            };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & pan" };
        }
    }
}