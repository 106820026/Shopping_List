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
            List<String> currentTypeItemSection = new List<String>();
            foreach (String section in _allSections)
                if (typeName == _initial.GetType(section))
                {
                    count++;
                    currentTypeItemSection.Add(section);
                }
            return (int)(Math.Ceiling(count / 6.0F));
        }

        // 取得目前分類的所有section
        public List<String> GetCurrentTypeItemSections(String typeName)
        {
            List<String> currentTypeItemSection = new List<String>();
            foreach (String section in _allSections)
                if (typeName == _initial.GetType(section))
                    currentTypeItemSection.Add(section);
            return currentTypeItemSection;
        }
    }
}
