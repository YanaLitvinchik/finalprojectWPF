using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWPF
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Alcohol> alcoholV { get; set; }
        public Alcohol SelectedAlcohol { get; set; }
        public ViewModel()
        {
            AlcoholV = Alcohol.GetAll();
        }
        public ObservableCollection<Alcohol> AlcoholV
        {
            get
            {
                return alcoholV;
            }
            set
            {
                alcoholV = value;
                OnPropertyChanged();
            }
        }

        private Alcohol alcohol;
        public Alcohol SelectedItem
        {
            get
            {
                return alcohol;
            }
            set
            {
                alcohol = value;
                OnPropertyChanged();
            }
        }
        private void OnPropertyChanged([CallerMemberName]string s = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
        }
    }
}
