using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostraTester
{
    public abstract class GroupTestsBase
    {
        protected string separator;
        protected String _grouptestname;
        protected bool _passed;

        public bool Passed { get { return _passed; } }
        protected bool _interapted;
        public bool Interapted { get { return _interapted;}}

        protected StringBuilder _result;
        public String Result { get { return _result == null ? String.Empty : _result.ToString(); } }

        protected List<Test_Base> _testCollection;
        public GroupTestsBase()
        {
            _result = new StringBuilder();
            _testCollection = new List<Test_Base>();
            separator = Constants.GetSeparator("_");
            SetGroupName();
            CreateGroup();
        }
        public void StartGroupTests()
        {
            _interapted=false;
           _passed = true;
           SetGroupStarted();
            foreach (Test_Base tb in _testCollection)
            {
                tb.GoTest();
                _result.AppendLine(tb.Result);
                if (!tb.IsPassed)
                    _passed = false;

                if (!_passed && !tb.ShouldContinue)
                {
                    _interapted=true;
                    break;
                }
            }
            if (_passed)
                SetGroupSuccess();
            else
                SetGroupFailed();

        }
        protected abstract void CreateGroup();
        protected abstract void SetGroupName();

        protected void SetGroupStarted()
        {
            _result.AppendLine(String.Format("{0} has started: ", _grouptestname));
        }
        protected void SetGroupFailed()
        {
            _result.AppendLine(String.Format("{0} has failed! ", _grouptestname));
            _result.AppendLine(separator);
        }
        protected void SetGroupSuccess()
        {
            _result.AppendLine(String.Format("{0} has finished successfully. ", _grouptestname));
            _result.AppendLine(separator);
        }
    }
}
