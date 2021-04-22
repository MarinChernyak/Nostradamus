using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Nostradamus.ViewModels.Commands
{
    public class cmdCloseApp :CommandBase
    {
        public cmdCloseApp(vmMainWindow parent)
     : base(parent)
        {

        }
        public override void Execute(object parameter)
        {

            foreach (Window item in App.Current.Windows)
            {
               item.Close();
            }
        }
    }
}

