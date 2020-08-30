using MapleStoryHelper.Standard;
using MapleStoryHelper.Standard.Item.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace MapleStoryApiServer.Interfaces.Services
{
    [ServiceContract]
    public interface IItemSearchService
    {
        [WebGet]

        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.WrappedRequest)]

        void ItemSearch(EItemCategory itemCategory, string keyWord, EEquipmentCategory equipCategory);


    }
}
