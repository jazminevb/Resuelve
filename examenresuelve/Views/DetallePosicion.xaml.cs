using System;
using System.Collections.Generic;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace examenresuelve
{
	public partial class DetallePosicion : ContentPage
	{
        DetallePosicionVM vm = new DetallePosicionVM(UserDialogs.Instance);

        public DetallePosicion(sucursal seleccion)
        {
            InitializeComponent();
            BindingContext = vm;
            vm.SucursalSel = seleccion;
        }
	}
}
