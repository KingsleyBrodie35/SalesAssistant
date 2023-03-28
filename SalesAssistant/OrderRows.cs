using System;
using System.Collections.Generic;


namespace SalesAssistant
{
    class OrderRows
    {
        //fields
        private List<OrderRow> _rows;
        //constructor
        public OrderRows()
        {
            _rows = new List<OrderRow>();
        }
        //properties
        public List<OrderRow> Rows
        {
            get
            {
                return _rows;
            }
        }
        //add row to list
        public void AddRow(OrderRow r)
        {
            _rows.Add(r);
        }
    }
}
