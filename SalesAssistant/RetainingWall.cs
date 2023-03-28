using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAssistant
{
    class RetainingWall : Product
    {
        //fields
        private int _maxHeight;
        private bool _canCurve;
        private float _length;
        private float _unitsLM;
        //constructor
        public RetainingWall(uint ProductID, string name, string supplier, int maxHeight, bool canCurve, string colour, string size, float price) : base(ProductID, name, supplier, colour, size, price)
        {
            _maxHeight = maxHeight;
            _canCurve = canCurve;
        }
        //methods
        public override float CalculateArea(int qty)
        {
            string[] dimensions = Size.Split("x");
            //put a decimal in front of int's to convert to mm measurements
            dimensions[0] = "." + dimensions[0];
            dimensions[1] = "." + dimensions[1];
            try
            {
                _length = float.Parse(dimensions[0]);
            }
            catch (FormatException)
            {
                Console.WriteLine("unable to parse strings");
            }
            _unitsLM = 1 / _length;
            return _unitsLM * qty;
        }
        public override float CalculatePrice(float qty)
        {
            return qty * Price;
        }
    }
}
