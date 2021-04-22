using Nostradamus.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nostradamus.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel ParentVM
        {
            get;
            set;
        }
        private BasicModel _model;
        protected BasicModel model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected PropertyChangedEventHandler handler;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        protected String GetErrorMessage(String propertyName)
        {
            String msg = String.Empty;
            if (model != null && model.Errors.ContainsKey(propertyName))
            {
                msg = model.Errors[propertyName].ErrorMessage;
            }
            return msg;
        }
        protected String _errgenmessage;
        public String errGenMessage
        {

            get { return _errgenmessage; }
            set
            {
                _errgenmessage = GetErrorMessage("errGenMessage");
                RaisePropertyChanged("errGenMessage");
            }
        }
        protected virtual void RaiseAllErrorPropertiesChanged()
        {
            foreach (String key in model.Errors.Keys)
            {
                RaisePropertyChanged(key);
            }
        }
    }
}
