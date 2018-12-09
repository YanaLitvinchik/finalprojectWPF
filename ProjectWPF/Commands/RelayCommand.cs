﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectWPF
{
    public class RelayCommand : ICommand
    {
        readonly Action<object> action;
        readonly Predicate<object> predicate;
        public RelayCommand(Action<object> a, Predicate<object> p = null)
        {
            action = a;
            predicate = p;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return predicate == null ? true : predicate(parameter);
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }
    }
}
