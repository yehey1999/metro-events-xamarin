using MetroEventsMobile.ViewModels.Organizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MetroEventsMobile.Views.Organizer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateEventView : ContentPage
    {
        public CreateEventView()
        {
            InitializeComponent();
            BindingContext = new CreateEventViewModel();
        }
    }
}