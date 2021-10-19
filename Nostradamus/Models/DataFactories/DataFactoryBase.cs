
using System;
using System.Collections.Generic;
using System.Text;

namespace Nostradamus.Models.DataFactories
{
 
    public abstract class DataFactoryBase<T>
    {

        public T Data { get; set; }
        protected XMLSerializerBase _serializer;

        public DataFactoryBase()
        {
            CreateSerializer();
            GetData();
        }
        protected void GetData()
        {
            _serializer.GetData();
            Data = (T)_serializer.Data;
            if (Data == null)
            {
                CreateDefaultData();
            }
        }
        public void SetData(object data)
        {
            _serializer.Data = (T)data;
            _serializer.Save();
        }
        public void SetData()
        {
            _serializer.Data = Data;
            _serializer.Save();
        }
        protected abstract void CreateSerializer();
        protected abstract void CreateDefaultData();
    }
}
