using MetroEventsMobile.Models;
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
    public partial class EventReviewsView : ContentPage
    {
        public EventReviewsView(Event _event)
        {
            InitializeComponent();
            BindingContext = new EventReviewsViewModel(_event);
        }
    }
}