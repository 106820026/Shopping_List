using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList
{
    class PageManagement
    {
        // current page
        int _motherBoardCurrentPage = 1;
        int _centralProcessUnitCurrentPage = 2;
        int _diskCurrentPage = 1;
        int _memoryCurrentPage = 1;
        int _graphicsProcessUnitCurrentPage = 1;
        int _computerCurrentPage = 1;
        // total page
        int _motherBoardTotalPage = 2;
        int _centralProcessUnitTotalPage = 2;
        int _diskTotalPage = 2;
        int _memoryTotalPage = 2;
        int _graphicsProcessUnitTotalPage = 2;
        int _computerTotalPage = 2;

        public PageManagement()
        {

        }

        // 取得目前頁數
        public int GetCurrentPage(int tabIndex)
        {
            switch (tabIndex)
            {
                case 0:
                    return _motherBoardCurrentPage;
                case 1:
                    return _centralProcessUnitCurrentPage;
                case 2:
                    return _diskCurrentPage;
                case 3:
                    return _memoryCurrentPage;
                case 4:
                    return _graphicsProcessUnitCurrentPage;
                case 5:
                    return _computerCurrentPage;
                default:
                    return 0;
            }
        }

        //取得總頁數
        public int GetTotalPage(int tabIndex)
        {
            switch (tabIndex)
            {
                case 0:
                    return _motherBoardTotalPage;
                case 1:
                    return _centralProcessUnitTotalPage;
                case 2:
                    return _diskTotalPage;
                case 3:
                    return _memoryTotalPage;
                case 4:
                    return _graphicsProcessUnitTotalPage;
                case 5:
                    return _computerTotalPage;
                default:
                    return 0;
            }
        }
    }
}
