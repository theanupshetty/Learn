using System.Collections.Generic;
using Cluestart.Backend.Models;

namespace Cluestart.Backend.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAppCommands();
        Command GetCommandById(int id);
    }
}