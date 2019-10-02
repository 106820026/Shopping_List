using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList
{
    class PageManagement
    {
        const int TWO = 2;
        const int THREE = 3;
        const int FOUR = 4;
        const int FIVE = 5;
        // current page
        int _motherBoardCurrentPage = 1;
        int _centralProcessUnitCurrentPage = 1;
        int _diskCurrentPage = 1;
        int _memoryCurrentPage = 1;
        int _graphicsProcessUnitCurrentPage = 1;
        int _computerCurrentPage = 1;
        int[] _allCurrentPage;
        // total page
        int _motherBoardTotalPage = TWO;
        int _centralProcessUnitTotalPage = TWO;
        int _diskTotalPage = TWO;
        int _memoryTotalPage = TWO;
        int _graphicsProcessUnitTotalPage = TWO;
        int _computerTotalPage = TWO;
        int[] _allTotalPage;
        // tab Index
        const int MOTHER_BOARD = 0;
        const int CENTRAL_PROCESS_UNIT = 1;
        const int DISK = TWO;
        const int MEMORY = THREE;
        const int GRAPHICS_PROCESS_UNIT = FOUR;
        const int COMPUTER = FIVE;

        public PageManagement()
        {
            _allCurrentPage = new int[] { _motherBoardCurrentPage, _centralProcessUnitCurrentPage , _diskCurrentPage, _memoryCurrentPage, _graphicsProcessUnitCurrentPage, _computerCurrentPage };
            _allTotalPage = new int[] { _motherBoardTotalPage, _centralProcessUnitTotalPage, _diskTotalPage, _memoryTotalPage, _graphicsProcessUnitTotalPage, _computerTotalPage };
        }

        // 取得目前頁數
        public int GetCurrentPage(int tabIndex)
        {
            return _allCurrentPage[tabIndex];
        }

        //取得總頁數
        public int GetTotalPage(int tabIndex)
        {
            return _allTotalPage[tabIndex];
        }

        // 處理換頁動作
        public void SwitchPage(int tabIndex, int offset)
        {
            _allCurrentPage[tabIndex] += offset;
        }
    }
}
