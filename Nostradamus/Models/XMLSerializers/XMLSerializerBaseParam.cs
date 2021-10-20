using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Nostradamus.Models.XMLSerializers
{
    public abstract class XMLSerializerBaseParam : XMLSerializerBase
    {
        public XMLSerializerBaseParam(object param)
        {
            _filename = Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1", "Models\\Data\\");
            UpdateFile(param);
            GetData();
        }
        public XMLSerializerBaseParam(object param, object data)
        {
            _filename = Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1", "Models\\Data\\");
            UpdateFile(param);
            Data = data;
            Save();
        }
        protected abstract void UpdateFile(object param);
    }
}
