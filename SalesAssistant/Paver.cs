using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAssistant
{
    class Paver : Product
    {
        //Fields
        private bool _crushRock;
        private float _unitsM2;
        private float _length;
        private float _width;
        //Constructor
        public Paver (uint ProductID, string name, string supplier, bool crushRock ,string colour, string size, float price) : base(ProductID, name, supplier, colour, size, price)
        {
            _crushRock = crushRock;
        }
        //Methods
        public override float CalculateArea(int qty)
        {
            string[] dimensions = Size.Split("x");
            dimensions[2] = dimensions[2].Remove(2);
            //put a decimal in front of int's to convert to mm measurements
            dimensions[0] = "." + dimensions[0];
            dimensions[1] = "." + dimensions[1];
            try
            {
                _length = float.Parse(dimensions[0]);
                _width = float.Parse(dimensions[1]);
                
            }
            catch (FormatException)
            {
                Console.WriteLine("unable to parse strings");
            }
            //calculate how many pavers to a m2
            
            _unitsM2 = 1 / _length * 1 / _width;
            Console.WriteLine($"units: {_unitsM2}, length: {_length}, width: {_width}");
            return qty * _unitsM2;
        }
        public override float CalculatePrice(float qty)
        {
            return qty * Price;
        }
    }
}
