using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiCurso.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
            private int count;

        [RelayCommand]
        public void Sumar() 
        {
            Count++;
        }
        
        

        
        
        

        
        
    }

}

