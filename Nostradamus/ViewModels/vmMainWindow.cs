using Nostradamus.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Nostradamus.ViewModels
{
    public class vmMainWindow : BaseViewModel
    {
        public vmMainWindow()
        {
        }
        protected UserControl _contentControl;
        public UserControl ContentControl
        {
            get { return _contentControl; }
            set
            {
                _contentControl = value;
                RaisePropertyChanged("ContentControl");
            }
        }

        #region Commands
        protected cmdCreateMapByLastName _createmapbyLastName;
        public ICommand CreateMapByLastName
        {
            get
            {
                if (_createmapbyLastName == null)
                    _createmapbyLastName = new cmdCreateMapByLastName(this);

                return _createmapbyLastName;
            }
        }
        protected cmdCloseApp _closeApp;
        public ICommand CloseApp
        {
            get
            {
                if (_closeApp == null)
                    _closeApp = new cmdCloseApp(this);

                return _closeApp;
            }
        }
        #endregion
    }
}
