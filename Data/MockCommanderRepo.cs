using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return new List<Command> {
new Command { Id = 0, HowTo = "Boil an egg", CommandLine = "Boil water", Platform = "Kettle & Pan" },
new Command { Id = 1, HowTo = "Make bread", CommandLine = "Mix flour, water, salt, and yeast", Platform = "Kettle & Pan" },
new Command { Id = 2, HowTo = "Knead pizza dough", CommandLine = "Physical energy", Platform = "Kettle & Pan" },
};
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "Boil an egg", CommandLine = "Boil water", Platform = "Kettle & Pan" };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }
    }
}