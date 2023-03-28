using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAssistant
{
    class Order
    {
        //fields
        private OrderRows _rows;
        private float _total;
        private string _delDate;
        //constructor
        public Order()
        {
            _rows = new OrderRows();
        }
        //properties 
        public OrderRows Rows
        {
            get
            {
                return _rows;
            }
        }
        //methods 
        //add row to orderRow
        public void AddRow(OrderRow r)
        {
            _rows.Rows.Add(r);
        }
    }
}
