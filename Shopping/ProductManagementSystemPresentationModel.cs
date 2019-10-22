using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList
{
    class ProductManagementSystemPresentationModel
    {
        #region Member Data
        const String MOTHER_BOARD = "主機板";
        const String CENTRAL_PROCESS_UNIT = "CPU";
        const String MEMORY = "記憶體";
        const String DISK = "硬碟";
        const String GRAPHICS_PROCESS_UNIT = "顯卡";
        const String COMPUTER = "套裝電腦";
        String[] _types = { MOTHER_BOARD, CENTRAL_PROCESS_UNIT, MEMORY, DISK, GRAPHICS_PROCESS_UNIT, COMPUTER };
        #endregion

        // 回傳商品類別的index
        public int GetItemType(String itemType)
        {
            for (int i = 0; i < _types.Length; i++)
                if (itemType == _types[i])
                    return i;
            return 0;
        }
    }
}
