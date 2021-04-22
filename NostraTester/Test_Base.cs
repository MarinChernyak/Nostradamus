using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostraTester
{
    public abstract class Test_Base
    {
        protected StringBuilder _result;
        public String Result { get { return _result == null ? String.Empty : _result.ToString(); } }
        protected String testName { get; set; }
        private bool _IsPassed;
        public bool IsPassed
        {
            get { return _IsPassed; }
        }
        protected bool _Continue;
        public bool ShouldContinue { get { return _Continue; } }
        public abstract void GoTest();

        public Test_Base()
        {
            _Continue = true;
            _IsPassed = true;
            _result = new StringBuilder();
        }
        protected void SetErrorMessage()
        {
            _IsPassed = false;
            _result.AppendLine(String.Format("{0} :\t-> {1}", testName, Constants.TestError));
            
        }
        protected void SetErrorMessage(String sMsg)
        {
            _IsPassed = false;
            _result.AppendLine(String.Format("{0} :\t-> {1}", testName, sMsg));
            
        }
        protected void SetSuccessMessage()
        {
            _result.AppendLine(String.Format("{0} \t-> {1}", testName, Constants.TestPassedOK));
            
        }
        protected void SetExceptionMessage(String message)
        {
            _IsPassed = false;
            _result.AppendLine(String.Format("{2}. Exception in {0} :\t-> {1}", testName, message, Constants.TestError));
            
        }
        protected void SetInfoMessage(String message)
        {
            _result.AppendLine(String.Format("{0} :\t-> {1}", testName, message));
            
        }
        protected void SetTestResult(bool result)
        {
            if (result)
                SetSuccessMessage();
            else
                SetErrorMessage();
        }
        #region AUXULURALY


        protected void ProcessArray<T>(T[] array, int correctNumberElenments)
        {
            Type type = typeof(T);
            if (array == null)
            {
                SetErrorMessage(String.Format("A test of collection of {0}(s) were not found!", type.Name));
            }
            else if (array.Length != correctNumberElenments)
            {
                SetErrorMessage(String.Format("Wrong number of {0} element(s) were returned!", type.Name));
            }
        }
        #endregion
    }
}
