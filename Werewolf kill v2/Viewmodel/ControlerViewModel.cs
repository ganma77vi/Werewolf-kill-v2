using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf_kill_v2.Viewmodel
{
    class ControlerViewModel:BaseViewModel
    {
        private ObservableCollection<Model.Controler> controlers;
        public ObservableCollection<Model.Controler> Controlers
        {
            get
            {
                return controlers;
            }
            set
            {
                controlers = value;
                RaisePropertyChanged(nameof(Controlers));
            }
        }
    }
}
