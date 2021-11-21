using MetroEventsMobile.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MetroEventsMobile.Views.Admin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DashboardView : ContentPage
	{
		public DashboardView ()
		{
			InitializeComponent();
			BindingContext = new DashboardViewModel();
		}
	}
}