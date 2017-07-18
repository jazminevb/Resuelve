using System;
using System.Collections.Generic;
using Acr.UserDialogs;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace examenresuelve
{
	public partial class ListaSucursales : ContentPage
	{
		public ListaSucursales()
		{
			InitializeComponent();
			this.BindingContext = new ListaSucursalesVM(UserDialogs.Instance, Navigation);

            lstSucursales.ItemSelected += (s, e) =>
            {
                lstSucursales.SelectedItem = null;
            };
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
            await (BindingContext as ListaSucursalesVM).IniciaCarga();
		}

	}
}
