using System;
using System.Collections.Generic;

namespace SalesAssistant
{
    //List of products
    public class Products
    {
        //Fields
        private List<Product> _products = new List<Product>();
        //properties
        public List<Product> ProductList 
        {
            get
            {
                return _products;
            }
        }
        //Methods
        //Add Product to the list
        public void Add(Product p)
        {
            _products.Add(p);
        }
        //search for specific Product in list
        public Product returnProduct(uint id, string colour, string size)
        {
            foreach (Product p in ProductList)
            {
                if (p.ID == id && p.Colour == colour && p.Size == size)
                {
                    return p;
                }
            }
            return null;
        }
    }
}
