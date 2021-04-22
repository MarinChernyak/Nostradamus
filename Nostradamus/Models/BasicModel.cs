using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nostradamus.Models
{
    public class BasicModel
    {
        private Dictionary<String, SMTypes.ErrorContainer> _errors;
        public Dictionary<String, SMTypes.ErrorContainer> Errors
        {
            get
            {
                if (_errors == null)
                {
                    _errors = new Dictionary<String, SMTypes.ErrorContainer>();
                }
                return _errors;
            }

        }
        public void ClearErrors()
        {
            foreach (SMTypes.ErrorContainer err in Errors.Values)
            {
                err.ErrorMessage = String.Empty;
            }
        }
        protected void AddError(String propName, String errMsg, String funcName)
        {
            SMTypes.ErrorContainer err = new SMTypes.ErrorContainer();
            err.AppID = Constants.AppID;
            err.ErrorCode = SMTypes.Constants.ErrorCode.SME_UNDEFINED;
            err.ErrorMessage = errMsg;
            err.FunctionName = funcName;

            Errors[propName] = err;

        }
        protected void AddMessage(String propName, String infoMsg, String funcName)
        {
            SMTypes.ErrorContainer err = new SMTypes.ErrorContainer();
            err.AppID = Constants.AppID;
            err.ErrorCode = SMTypes.Constants.ErrorCode.SME_NOERRORS;
            err.ErrorMessage = infoMsg;
            err.FunctionName = funcName;

            Errors[propName] = err;

        }
    }
}
