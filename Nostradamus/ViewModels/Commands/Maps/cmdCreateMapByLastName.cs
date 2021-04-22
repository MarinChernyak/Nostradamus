using Nostradamus.ViewModels.Commands;
using Nostradamus.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Nostradamus.ViewModels.Commands
{
    public class cmdCreateMapByLastName :CommandBase
    {
        public cmdCreateMapByLastName(vmMainWindow parent)
            :base(parent)
        {

        }
        public override void Execute(object parameter)
        {
            CreateMapByLastName content = Activator.CreateInstance<CreateMapByLastName>();
            ((BaseViewModel)(content.DataContext)).ParentVM = _parentVM;
            content.Show();
            //((vmMainWindow)_parentVM).ContentControl = content;
        }
    }
}
