using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands;
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(p => p.Id == id);
        }

        public void CreateCommand(Command command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            _context.Commands.Add(command);
        }

        public void UpdateCommand(Command command)
        {

        }

        public void DeleteCommand(Command command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            _context.Commands.Remove(command);
        }
    }
}