using System;
using System.Collections.Generic;
using System.Text;

namespace Nostradamus.Models.DataProcessors
{
    public abstract class BaseProcessor
    {

        public BaseProcessor(bool initData)
        {
            if(initData)
            {
                GetData();
            }
        }
        protected abstract void GetData();
    }
}
