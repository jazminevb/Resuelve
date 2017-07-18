using System;
using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Net.Http;
using Refit;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace examenresuelve
{
	public class ListaSucursalesVM : ResuelveVM
	{
		private const string apiendpoint = "https://mbgu2q4kj1.execute-api.us-east-1.amazonaws.com/dev/Portal";
        private INavigation navigation;

        private sucursal mSelectedSucursal;
		public sucursal SelectedSucursal
		{
			get { return (mSelectedSucursal); }
			set
			{
				if (value != mSelectedSucursal && value != null)
				{
					mSelectedSucursal = value;
					OnPropertyChanged("SelectedSucursal");
                    navigation.PushAsync(new DetallePosicion(mSelectedSucursal));
				}
			}
		}

        private ObservableCollection<sucursal> mlstSucursales;
		public ObservableCollection<sucursal> lstSucursales
		{
			get { return (mlstSucursales); }
			set
			{
				if (value != mlstSucursales)
				{
					mlstSucursales = value;
					OnPropertyChanged("lstSucursales");
				}
			}
		}

        public ListaSucursalesVM(IUserDialogs diag, INavigation nav) : base(diag)
		{
			Title = "Sucursales Resuelve";
            navigation = nav;
		}

		/// <summary>
		/// Sirve para conectarse al servicio REST y llenar la lista de sucursales
		/// </summary>
		/// <returns>The carga.</returns>
		public async Task IniciaCarga()
		{
			Ocupado = true;
			var api = RestService.For<IAllBranch>(apiendpoint);
			lstSucursales = await api.GetAllBranch(1);
			Ocupado = false;
		}
	}
}
