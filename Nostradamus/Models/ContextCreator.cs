using NostradamusDAL.Entities;
using NostradamusDAL.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nostradamus.Models
{
    public class ContextCreator
    {
        private static NostradamusTestContext _context;
        public static string Connection { get; set; }
        public static NostradamusTestContext Context
        {
            get
            {
                if (_context == null)
                {
                    if (string.IsNullOrEmpty(Connection))
                    {
                        Connection = Constants.ConnectionLocal;
                    }
                    _context = new NostradamusContextFactory().CreateDbContext(new string[1] { Connection });
                }
                return _context;
            }
        }
    }
}
