using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList
{
    public class Category
    {
        String _name;

        public Category(String name)
        {
            _name = name;
        }

        public String CategoryName
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
    }
}
