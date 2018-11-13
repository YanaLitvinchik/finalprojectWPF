using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWPF
{
    class ViewModel
    {
        public ObservableCollection<Alcohol> AlcoholV { get; set; }

        public Alcohol SelectedAlcohol { get; set; }
        public ViewModel()
        {
            AlcoholV = Alcohol.GetAll();
        }
    }
}
