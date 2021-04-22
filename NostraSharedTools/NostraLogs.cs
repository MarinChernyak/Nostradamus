using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.C

namespace NostraSharedTools
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    namespace NoostraCommonTools
    {
        public class NostraLoger
        {
            private String _Path;
            private bool _bLog;

            protected string _fienName;
            public String FileName
            {
                get
                {
                    return _fienName;
                }
            }
            private bool _shouldLogAtfterfail;
            public bool ShouldLogAtfterFail { get { return _shouldLogAtfterfail; } }
            protected string _projnName;
            public String ProjectName
            {
                get
                {
                    return _projnName;
                }
            }
            public NostraLoger()
            {
                CheckDirectory();
                String dt = DateTime.Now.ToString();
                _projnName = "Nostra";
                _fienName = String.Format("{0}_{1}.log", _projnName, dt);
            }
            public NostraLoger(string filename, string projectname)
            {
                CheckDirectory();
                _projnName = projectname;
                String dt = DateTime.Now.ToString();
                _fienName = String.Format("{0}-{1}_{2}.log", projectname, filename, dt);
            }
            private void CheckDirectory()
            {
                String dir = ConfigurationManager.AppSettings.Get("LogDir");
                _bLog = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("ShouldLog"));
                _shouldLogAtfterfail = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("ShouldContinueLogAfterFail"));
                if (String.IsNullOrEmpty(dir) && _bLog)
                {
                    dir = "Logs";
                }
                _Path = String.Format("{0}/{1}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), dir);

                if (!Directory.Exists(_Path))
                {
                    DirectoryInfo dinf = Directory.CreateDirectory(_Path);
                }

            }

            public void SetLog(String msg)
            {
                StreamWriter sw = null;
                String AppName = ConfigurationManager.AppSettings.Get("AppName");

                if (_bLog)
                {
                    try
                    {
                        sw = new StreamWriter(String.Format("{0}/{1}", _Path, FileName), true);

                        String sOut = String.Format("{0}        ->{1}", msg, DateTime.Now.ToShortTimeString());
                        sw.WriteLine(sOut);
                        sw.Close();

                    }
                    catch (Exception ex)
                    {
                        if (sw != null)
                        {
                            String sOut = String.Format("NostraLoger Error: {0}        ->{1}", ex.Message, DateTime.Now.ToShortTimeString());
                            sw.WriteLine(sOut);
                            sw.Close();
                            sw.Dispose();
                            sw = null;
                        }
                    }
                    finally
                    {
                        if (sw != null)
                        {
                            sw.Close();
                            sw.Dispose();
                        }
                    }
                }
            }
        }
    }

}
