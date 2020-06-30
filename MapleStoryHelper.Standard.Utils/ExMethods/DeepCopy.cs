using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace MapleStoryHelper.Standard.Utils.ExMethods
{
    public static class DeepCopyExMethods
    {
        public static T DeepCopy<T>(this object obj) where T : new()
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, obj);
            ms.Position = 0;
            return (T)bf.Deserialize(ms);
        }

    }
}
