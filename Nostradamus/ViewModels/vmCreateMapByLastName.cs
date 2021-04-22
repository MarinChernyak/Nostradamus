using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nostradamus.ViewModels.VMUserControls
{
    public class vmCreateMapByLastName: BaseViewModel
    {
        private String _lastName;
        public String LastName
        {
            get { return _lastName; }
            set {
                _lastName = value;
                RaisePropertyChanged("LastName");
            }
        }

    }
}
