using MetroEventsMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MetroEventsMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAccountView : ContentPage
    {
        public CreateAccountView()
        {
            InitializeComponent();
            BindingContext = new CreateAccountViewModel();
        }
    }
}