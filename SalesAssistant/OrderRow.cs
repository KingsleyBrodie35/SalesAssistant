using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAssistant
{
    class OrderRow
    {
        //fields
        private Product _product;
        private float _total;
        private float _price;
        //constructor
        public OrderRow(Product p)
        {
            _product = p;
        }
        public string displayRow
        {
            get
            {
                return $"{_product.Name}, qty: {_total}, price: ${_price}";
            }
        }
        //methods
        public float calculateArea(int qty)
        {
            _total = _product.CalculateArea(qty);
            return _total;
        }
        public float calculatePrice(float total)
        {
            _total = total;
            _price = _product.CalculatePrice(total);
            return _price;
        }
    }
}
