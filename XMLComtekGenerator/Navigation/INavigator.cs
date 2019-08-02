using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLComtekGenerator.Navigation
{
    interface INavigator
    {
        void Register(ViewModelBase viewModel);
        void NavigateTo<T>() where T : ViewModelBase;
        void NavigateTo(Type t);
    }
}
