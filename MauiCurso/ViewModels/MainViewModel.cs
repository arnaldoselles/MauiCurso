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
        string numero1;

        [ObservableProperty]
        string numero2;

        [ObservableProperty]
        string resultado;

        [RelayCommand]
        void Sumar()
        {
            if (double.TryParse(Numero1, out double n1) &&
                double.TryParse(Numero2, out double n2))
            {
                Resultado = (n1 + n2).ToString();
            }
            else
            {
                Resultado = "Valores inválidos";
            }
        }









    }

}

