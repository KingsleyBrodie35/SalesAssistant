using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAssistant
{
    class Commands
    {
        //Fields
        private List<Command> _commands;
        //Constructor
        public Commands()
        {
            _commands = new List<Command>();
            _commands.Add(new RetainingWallCommand());
            _commands.Add(new PaverCommand());
        }
        //Methods
        public Products Process(string id)
        {
            foreach (Command i in _commands)
            {
                if (i.AreYou(id))
                {
                    return i.Execute();
                }
            }
            return null;
        }
    }
}
