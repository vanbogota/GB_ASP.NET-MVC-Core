using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class ComplexProductAdapter : IProduct
    {
        private readonly AnotherProduct _anotherProduct;
        public ComplexProductAdapter(AnotherProduct anotherProduct) => _anotherProduct = anotherProduct;
        public int Id
        {
            get
            {
                return _anotherProduct.Id;
            }
            set
            {
                _anotherProduct.Id = value;
            }
        }
        public long Amount
        { 
            get
            {
                return _anotherProduct.TotalAmount;
            }
            set
            {
                _anotherProduct.TotalAmount = value;
            }
        }
        public string AnotherInformation
        {
            get 
            {
                return $"{_anotherProduct.Name}, {_anotherProduct.Description}";
            }
            set
            {
                _anotherProduct.Name = value;
                _anotherProduct.Description = value;
            }
        }
    }
}
