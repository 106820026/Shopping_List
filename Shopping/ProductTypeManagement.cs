using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList
{
    public class ProductTypeManagement
    {
        Initial _initial;
        List<String> _allSections;
        List<String> _allTypes;

        public ProductTypeManagement(Initial initial)
        {
            _initial = initial;
            _allSections = _initial.GetAllSections().Cast<String>().ToList(); // 取得所有商品Section的List
            _allTypes = _initial.GetAllType();
        }

        // 取得每個分類的總頁數
        public int GetTotalPage(String typeName)
        {
            float count = 0;
            List<String> _currentTypeItemSection = new List<String>();
            foreach (String section in _allSections)
                if (typeName == _initial.GetType(section))
                {
                    count++;
                    _currentTypeItemSection.Add(section);
                }
            return (int)(Math.Ceiling(count/6.0f));
        }

        // 取得目前分類的所有section
        public List<String> GetCuttentTypeItemSections(String typeName)
        {
            List<String> _currentTypeItemSection = new List<String>();
            foreach (String section in _allSections)
                if (typeName == _initial.GetType(section))
                    _currentTypeItemSection.Add(section);
            return _currentTypeItemSection;
        }
    }
}
