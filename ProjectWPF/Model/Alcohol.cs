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
   public class Alcohol : INotifyPropertyChanged
    {
        private string image;
        private string name;
        private string manufacturer;
        private string year;
        private string type;
        public int Id { get; set; }

        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                Notify();
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                Notify();
            }
        }
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                Notify();
            }
        }
        public string Manufacturer
        {
            get { return manufacturer; }
            set
            {
                manufacturer = value;
                Notify();
            }
        }
        public string  Year
        {
            get { return year; }
            set
            {
                year = value;
                Notify();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Notify([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public static ObservableCollection<Alcohol> GetAll()
        {
            return new ObservableCollection<Alcohol>(SqliteDataAccess.LoadAlcohol());
        }
    }
}
