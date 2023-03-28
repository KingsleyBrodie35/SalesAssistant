using System;
using System.Collections.Generic;
using ConsoleTables;

namespace SalesAssistant
{
    class OrderCommand
    {
        //fields
        private Order _order = new Order();
        private uint _productID;
        private int _qty;
        private Product _p;
        private Products _products;
        private Product _result;
        private float _total;
        private float _totalPrice;
        //constructor

        //methods 
        public void Execute(Customer c, Products products)
        {
            //Add new order to customer.
            _order = c.AddOrder();
            //Get OrderRows from order
            OrderRows or = _order.Rows;
            //for access throughout the whole class
            _products = products;
            //search for product
            _p = Search(products);
            Console.WriteLine($"{_p.ID}", _p.Name);
            //print p to screen
            var table = new ConsoleTable("ID", "Name", "Supplier", "Colour", "Size", "Price");
            table.AddRow($"{_p.ID}", $"{_p.Name}", $"{_p.Supplier}", $"{_p.Colour}", $"{_p.Size}", $"${_p.Price}ea");
            table.Write();
            //grab input
            Console.WriteLine("1: Enter quantity\n2: Enter Lm/m2");
            string ipt = Console.ReadLine();
            //convert quantity from string to int
            Console.Write("Please enter amount: ");
            string sqty = Console.ReadLine();
            try
            {
                _qty = Int32.Parse(sqty);
            }
            catch (FormatException)
            {
                Console.WriteLine($"unable to parse {_qty}");
            }
            //create order row with
            OrderRow row = new OrderRow(_p);
            //add rows to row
            or.AddRow(row);
            //calculate from units
            if (ipt == "1" || ipt == "Enter quantity")
            {
                _total = _qty;
                _totalPrice = row.calculatePrice(_qty);
            }
            //calculate from Lm/m2
            if (ipt == "2" || ipt == "Enter Lm/m2")
            {
                _total = row.calculateArea(_qty);
                _totalPrice = row.calculatePrice(_total);
            }
            Console.WriteLine($"total amount of {_p.Name}'s = {_total}\ntotal price = ${_totalPrice}");
        }
        private Product Search(Products p)
        {
            //get user input to search
            Console.Write("Please select a product ID: ");
            string stringID = Console.ReadLine();
            Console.Write("Please select the colour: ");
            string colour = Console.ReadLine();
            Console.Write("Please select the size: ");
            string size = Console.ReadLine();
            //convert id to uint
            try
            {
                _productID = UInt32.Parse(stringID); 
            } catch (FormatException)
            {
                Console.WriteLine($"unable to parse {stringID}");
            }             
            _result = p.returnProduct(_productID, colour, size);
            if (_result == null)
            {
                Console.WriteLine("I'm sorry no paver matches your query. Please try again");
                _p = Search(_products);
            }
            return _result;
        }
    }
}
