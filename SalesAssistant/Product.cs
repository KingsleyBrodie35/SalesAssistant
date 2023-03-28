using System;
using System.Collections.Generic;

namespace SalesAssistant
{
    public abstract class Product
    {
        //Fields
        private uint _ProductID;
        private string _name;
        private string _supplier;
        private string _colour;
        private string _size;
        private float _price;
        //Constructor
        public Product(uint ProductID, string name, string supplier, string colour, string size, float price)
        {
            _ProductID = ProductID;
            _name = name;
            _supplier = supplier;
            _colour = colour;
            _size = size;
            _price = price;
        }
        //Properties
        public uint ID
        {
            get
            {
                return _ProductID;
            }
        }
        public string Colour
        {
            get
            {
                return _colour;
            }
        }
        public string Size
        {
            get
            {
                return _size;
            }
        }
        public float Price
        {
            get
            {
                return _price;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
        }
        public string Supplier
        {
            get
            {
                return _supplier;
            }
        }
        //methods
        public abstract float CalculateArea(int qty);
        public abstract float CalculatePrice(float qty);

    }
}
