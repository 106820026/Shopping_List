using System;

namespace ShopList.Model
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
            //set
            //{
            //    _name = value;
            //}
        }
    }
}
