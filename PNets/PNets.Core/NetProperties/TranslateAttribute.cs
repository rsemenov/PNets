using System;

namespace PNets.Core.NetProperties
{
    public class TranslateAttribute : Attribute
    {
        public string ShowName { get; private set; }
        public TranslateAttribute(string name)
        {
            ShowName = name;
        }
    }
}