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
            //return new ObservableCollection<Alcohol>
            //{
            //    new Alcohol { Image = "../Image/gibsons.jpg",  Name = "Gibson's",Type = "Gin", Manufacturer ="London", Year = "2018"},
            //    new Alcohol { Image = "../Image/jw.png",  Name = "Alpha",Type = "Viski", Manufacturer ="Riga", Year = "1990"},
            //    new Alcohol { Image = "../Image/vn.png",  Name = "Victor",Type = "Vine", Manufacturer ="Lima", Year = "2000"}
            //};
            return new ObservableCollection<Alcohol>(SqliteDataAccess.LoadAlcohol());
            
        }
    }
}
