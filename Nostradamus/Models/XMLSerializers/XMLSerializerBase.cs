using System;
using System.Collections.Generic;
using System.Text;

namespace Nostradamus.Models
{
    public abstract class XMLSerializerBase
    {
        protected string _filename;

        protected abstract void InitDefaults();
        public abstract void Save();
        public abstract void GetData();
    }
}
