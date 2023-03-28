using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAssistant
{
    class Customer
    {
        //fields
        private string _name;
        private string _ph;
        private List<Order> _orders;
        //consturctor
        public Customer(string name)
        {
            _name = name;
            _orders = new List<Order>();
        }
        //properties
        public string Phone
        {
            get
            {
                return _ph;
            }
            set
            {
                _ph = value;
            }
        }
        //methods
        //add a new order to the list and return order
        public Order AddOrder()
        {
            Order o = new Order();
            _orders.Add(o);
            return o;
        }
    }
}
