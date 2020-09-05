using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.MNetwork.Common
{
    public class MResponse<T>
    {
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
