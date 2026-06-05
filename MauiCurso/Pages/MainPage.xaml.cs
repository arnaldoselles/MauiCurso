using MauiCurso.ViewModels;

namespace MauiCurso
{
    public partial class MainPage : ContentPage
    {
       
        
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
        
       
    }
}
