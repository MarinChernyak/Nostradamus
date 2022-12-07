using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Nostradamus.Models
{
    public class LogMaster
    {
        protected string Path { get; }
        public LogMaster()
        {
            Path = @"C:\Nostradamus\Data\Logs";
            if(!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
        }
        public void SetLog(string log)
        {
            DateTime dt = DateTime.Now;
            string filename = $"Nostradamus{dt.ToShortDateString()}.log".Replace("/","_");
            string path = $"{Path}\\{filename}";
            if(!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path))
                {
                    byte[] bytes = Encoding.Unicode.GetBytes(log);
                    fs.Write(bytes);
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(log);
                }
            }
        }
    }
}
