using NostradamusDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Nostradamus.Models
{
    public class BaseModel
    {
        protected string _connection { get; }
        public BaseModel(string connection = Constants.ConnectionLocal)
        {
            _connection = connection;
        }
    }
}
