using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Nostradamus.Models
{
    public abstract class XMLSerializerBase
    {
        protected string _filename;
        public XMLSerializerBase()
        {
            _filename = Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1", "Models\\Data\\");
            UpdateFile();
            GetData();
        }
        public XMLSerializerBase(object param)
        {
            _filename = Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1", "Models\\Data\\");
            UpdateFile(param);
            GetData();
        }
        //protected abstract void InitDefaults();
        public abstract void Save();
        public abstract void GetData();
        protected abstract void UpdateFile();
        protected abstract void UpdateFile(object param);
        public abstract void SaveAsNew();

    }
}
