using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Nostradamus.Models
{
    public abstract class XMLSerializerBase
    {
        protected string _filename;
        public virtual object Data { get; set; }
        public XMLSerializerBase()
        {
            _filename = Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1", "Models\\Data\\");
            UpdateFile();
            if(Data==null)
            {
                GetData();
            }
        }
        public XMLSerializerBase(object data)
        {
            _filename = Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1", "Models\\Data\\");
            UpdateFile();
            Data = data;
            Save();
        }
        //protected abstract void InitDefaults();
        public abstract void Save();
        public abstract void GetData();
        protected abstract void UpdateFile();      

    }
}
