using System;
using System.Collections.Generic;

namespace SalesAssistant
{
    public abstract class Command : IdentifiableObject
    {
        //fields 
        private string _connString = @"server=localhost;userid=root;password=@Bryan9615;database=salesassistant";
        //properties
        public string ConnString
        {
            get
            {
                return _connString;
            }
        }
        //constructor
        public Command(string[] ids) : base (ids) {}
        //methods
        public abstract Products Execute();
        
    }
}
