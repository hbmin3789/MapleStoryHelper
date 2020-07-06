using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WzComparerR2.CharaSim;

namespace MapleStoryHelper.Framework.ResourceManager
{
    public partial class MapleWz
    {
        #region SetItem

        public void SetItemList()
        {
            setItemManager.SetItemList(EtcWzStruct.WzNode);
        }

        public List<SetItem> GetSetItemList()
        {
            return setItemManager.SetItemOptions;
        }

        #endregion
    }
}
