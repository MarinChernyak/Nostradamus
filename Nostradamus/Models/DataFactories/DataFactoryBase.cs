
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
        public DataFactoryBase(T data)
        {
            CreateSerializer();
            SetData(data);
        }
        protected void GetData()
        {
            _serializer.GetData();
            Data = (T)_serializer.Data;
            ConsiderDefaultData();
            
        }
        protected void SetData(T data)
        {
            _serializer.Data = data;
            _serializer.Save();
        }
        protected void SetData()
        {
            _serializer.Data = Data;
            _serializer.Save();
        }
        protected abstract void CreateSerializer();
        protected abstract void ConsiderDefaultData();
    }
}
