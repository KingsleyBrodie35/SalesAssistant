using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAssistant
{
    public class IdentifiableObject
    {
        //fields
        private List<string> _identifiers;
        //constructor
        public IdentifiableObject(string[] idents)
        {
            _identifiers = new List<string>();
            foreach (string i in idents)
            {
                AddIdentifer(i);
            }
        }
        //properties
        public string FirstId
        {
            get
            {
                if (_identifiers.Count == 0)
                {
                    return "";
                }
                return _identifiers[0];
            }
        }
        //methods
        public bool AreYou(string id)
        {
            foreach (string i in _identifiers)
            {
                id = id.ToLower();
                if (_identifiers.Contains(id))
                {
                    return true;
                }
            }
            return false;
        }
        public void AddIdentifer(string id)
        {
            id = id.ToLower();
            _identifiers.Add(id);
        }
    }
}
