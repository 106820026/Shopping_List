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
        int _centralProcessUnitCurrentPage = 1;
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
        // tab Index
        const int MOTHER_BOARD          = 0;
        const int CENTRAL_PROCESS_UNIT  = 1;
        const int DISK                  = 2;
        const int MEMORY                = 3;
        const int GRAPHICS_PROCESS_UNIT = 4;
        const int COMPUTER              = 5;

        public PageManagement()
        {
            _motherBoardCurrentPage = 1;
        }

        // 取得目前頁數
        public int GetCurrentPage(int tabIndex)
        {
            switch (tabIndex)
            {
                case MOTHER_BOARD:
                    return _motherBoardCurrentPage;
                case CENTRAL_PROCESS_UNIT:
                    return _centralProcessUnitCurrentPage;
                case DISK:
                    return _diskCurrentPage;
                case MEMORY:
                    return _memoryCurrentPage;
                case GRAPHICS_PROCESS_UNIT:
                    return _graphicsProcessUnitCurrentPage;
                case COMPUTER:
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
                case MOTHER_BOARD:
                    return _motherBoardTotalPage;
                case CENTRAL_PROCESS_UNIT:
                    return _centralProcessUnitTotalPage;
                case DISK:
                    return _diskTotalPage;
                case MEMORY:
                    return _memoryTotalPage;
                case GRAPHICS_PROCESS_UNIT:
                    return _graphicsProcessUnitTotalPage;
                case COMPUTER:
                    return _computerTotalPage;
                default:
                    return 0;
            }
        }

        // 處理換頁動作
        public void SwitchPage(int tabIndex, int offset)
        {
            switch (tabIndex)
            {
                case MOTHER_BOARD:
                    _motherBoardCurrentPage += offset;
                    break;
                case CENTRAL_PROCESS_UNIT:
                    _centralProcessUnitCurrentPage += offset;
                    break;
                case DISK:
                    _diskCurrentPage += offset;
                    break;
                case MEMORY:
                    _memoryCurrentPage += offset;
                    break;
                case GRAPHICS_PROCESS_UNIT:
                    _graphicsProcessUnitCurrentPage += offset;
                    break;
                case COMPUTER:
                    _computerCurrentPage += offset;
                    break;
                default:
                    break;
            }
        }
    }
}
