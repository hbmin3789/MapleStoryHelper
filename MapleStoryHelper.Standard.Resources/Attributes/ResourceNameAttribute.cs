using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Resources.Attributes
{
    public class ResourceNameAttribute : Attribute
    {
        public string ResourceName { get; set; }

        public ResourceNameAttribute(string Name)
        {
            ResourceName = Name;
        }

    }
}
