using System;
using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Net.Http;
using Refit;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;
using Plugin.Connectivity;
using System.Threading;

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
        /// Sirve para conectarse al servicio REST, si hay conexion a internet, y llenar la lista de sucursales
        /// </summary>
        /// <returns>The carga.</returns>
        public async Task IniciaCarga()
        {
            Ocupado = true;
            RevisaCnx();
            if (CrossConnectivity.Current.IsConnected)
            {
                var api = RestService.For<IAllBranch>(apiendpoint);
                lstSucursales = await api.GetAllBranch(1);
            }
            else
                await UserDialogs.Instance.AlertAsync("No hay conexión a internet, revise su configuración WiFi o 3G", "Aviso", "OK");
            Ocupado = false;
        }

        /// <summary>
        /// Revisa si hay conexion a internet, si no manda msg, si la hay se reconecta a buscar la lista de sucursales
        /// </summary>
        private void RevisaCnx()
        {
            CancellationTokenSource ts = new CancellationTokenSource();
            CancellationToken ct = ts.Token;
            CrossConnectivity.Current.ConnectivityChanged += async (sender, args) =>
                {
                    if (!args.IsConnected)
                    {
                        try
                        {
                            await UserDialogs.Instance.AlertAsync("No hay conexión a internet, revise su configuración WiFi o 3G", "Aviso", "OK", ct);
                        }
                        catch (OperationCanceledException)
                        {
                            ts = new CancellationTokenSource();
                            ct = ts.Token;
                        }
                    }
                    else
                    {
                        ts.Cancel();
                        ts = new CancellationTokenSource();
                        ct = ts.Token;
                        await IniciaCarga();
                    }
                };
        }
    }
}
