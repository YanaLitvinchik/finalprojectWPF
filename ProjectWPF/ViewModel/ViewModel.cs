﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace ProjectWPF
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private  ObservableCollection<Alcohol> alcoholV;
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
        public Alcohol SelectedAlcohol
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
        public ViewModel()
        {
            AlcoholV = Alcohol.GetAll();
        }

        #region commamds


        private RelayCommand add;
        public ICommand Add
        {
            get { return add ?? (add = new RelayCommand(x => AddAlcohol())); }
        }
        private RelayCommand delete;
        public ICommand Delete
        {
            get
            {
                return delete ?? (delete = new RelayCommand(x => DeleteAlcohol(), y => SelectedAlcohol != null));
            }
        }
        private void DeleteAlcohol()
        {
            AlcoholV.Remove(SelectedAlcohol);
        }
        private void AddAlcohol()
        {
            //SqliteDataAccess.SaveItem
            //AlcoholV.Add(new Alcohol()
            //{
            //    Image = "../Image/gibsons.jpg",
            //    Name = "Name",
            //    Type = "Type",
            //    Manufacturer = "Manufacturer",
            //    Year = "Year"
            //});
            var a = new Alcohol()
            {
                Image = "../Image/gibsons.jpg",
                Name = "Name",
                Type = "Type",
                Manufacturer = "Manufacturer",
                Year = "Year"
            };
            SqliteDataAccess.SaveItem(a);
        }
        private RelayCommand openFolder;
        public ICommand OpenFolder
        {
            get
            {
                return openFolder ??
                  (openFolder = new RelayCommand(x => ChangeImage(), y => SelectedAlcohol != null));
            }
        }

        private void ChangeImage()
        {
            OpenFileDialog f = new OpenFileDialog()
            {
                Filter =
            "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
            };

            if (f.ShowDialog() == true)
                SelectedAlcohol.Image = f.FileName;
        }
        private RelayCommand sort;
        public ICommand Sort
        {
            get { return sort ?? (sort = new RelayCommand(SortList)); }
        }
        #endregion

        #region sorting

        private void SortList(object obj)
        {
            switch (obj.ToString())
            {
                case "Name":
                    AlcoholV = new ObservableCollection<Alcohol>(AlcoholV.OrderBy(x => x.Name));
                    break;
                case "Manufacturer":
                    AlcoholV = new ObservableCollection<Alcohol>(AlcoholV.OrderBy(x => x.Manufacturer));
                    break;
                case "Type":
                    AlcoholV = new ObservableCollection<Alcohol>(AlcoholV.OrderBy(x => x.Type));
                    break;
                case "Year":
                    AlcoholV = new ObservableCollection<Alcohol>(AlcoholV.OrderBy(x => x.Year));
                    break;
            }
        }
        #endregion
    }
}
