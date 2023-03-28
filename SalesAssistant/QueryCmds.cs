using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAssistant
{
    interface QueryCmds
    {
        public abstract void QueryDB();
        public abstract void CreateClause();
    }
}
