using MapleStoryHelper.Standard.Item.Equipment;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.MNetwork.Model
{
    public class EquipItemSearchRequest
    {
        [JsonProperty("keyWord")]
        public string KeyWord { get; set; }
        [JsonProperty("equipCategory")]
        public EEquipmentCategory Category { get; set; }
    }
}
