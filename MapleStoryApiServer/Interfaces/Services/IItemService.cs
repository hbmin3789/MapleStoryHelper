using MapleStoryHelper.Standard;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Equipment;
using MapleStoryHelper.Standard.Server.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
        MResponse<List<EquipmentItem>> EquipItem(string keyWord, EEquipmentCategory equipCategory);


    }
}
