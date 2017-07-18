using System;
using Acr.UserDialogs;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace examenresuelve
{
    public class DetallePosicionVM : ResuelveVM
    {
		private Pin mPosicion;
		public Pin Posicion
		{
			get { return (mPosicion); }
			set
			{
				if (value != mPosicion)
				{
					mPosicion = value;
					OnPropertyChanged("Posicion");
				}
			}
		}

		private Pin mSucursal;
		public Pin Sucursal
		{
			get { return (mSucursal); }
			set
			{
				if (value != mSucursal)
				{
					mSucursal = value;
					OnPropertyChanged("Sucursal");
				}
			}
		}

		/// <summary>
		/// Sucursal seleccionada desde la listview, genera el pin a mostrar en el mapa
		/// </summary>
        private sucursal mSucursalSel;
        public sucursal SucursalSel
		{
			get { return (mSucursalSel); }
			set
			{
				if (value != mSucursalSel)
				{
					Title = value.SUC_NAME;
					Pin pin = new Pin
					{
						Type = PinType.Place,
                        Position = new Position(double.Parse(value.LAT), double.Parse(value.LON)),
                        Label = value.SUC_NAME,
					};
                    Sucursal = pin;
					mSucursalSel = value;
                    OnPropertyChanged("SucursalSel");
				}
			}
		}

		/// <summary>
		/// ViewModel para manejar las actualizaciones de ubicacion por GPS y mostrar en mapa
		/// </summary>
		/// <param name="diag">UserDialogs</param>
        public DetallePosicionVM(IUserDialogs diag) : base(diag)
        {
            Title = "Detalle";
            var plataforma = DependencyService.Get<IGeo>();
			if (plataforma != null)
			{
				Geo g = new Geo();
				//Cuando se actualize la posicion se genera un nuevo pin
				plataforma.LatLonUpd = delegate (Geo gtmp)
				{
					g = gtmp;
					Pin pin = new Pin
					{
						Type = PinType.Place,
                        Position = new Position(g.latitude, g.longitud),
						Label = "Ud esta aqui",
					};
                    Posicion = pin;
                    Ocupado = false;
				};
				Ocupado = true;
				plataforma.GetLatLon();
			}
        }
    }
}
