using System;
using examenresuelve;
using CoreLocation;
using UIKit;
using examenresuelve.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(GeoiOS))]

namespace examenresuelve.iOS
{
	public class GeoiOS : IGeo
	{
		protected CLLocationManager locMgr;
		//public event EventHandler<GeoEventArgs> GeoUpdated = delegate { };
		public Action<Geo> LatLonUpd { get; set; }

		public GeoiOS()
		{
			this.locMgr = new CLLocationManager();
			this.locMgr.PausesLocationUpdatesAutomatically = false;

			if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
			{
				locMgr.RequestAlwaysAuthorization(); // works in background
													 //locMgr.RequestWhenInUseAuthorization (); // only in foreground
			}

			if (UIDevice.CurrentDevice.CheckSystemVersion(9, 0))
			{
				locMgr.AllowsBackgroundLocationUpdates = true;
			}
		}

		public void GetLatLon()
		{
			this.locMgr.LocationsUpdated += (sender, e) =>
			{
				Geo g = new Geo { latitude = (Decimal)e.Locations[0].Coordinate.Latitude, longitud = (Decimal)e.Locations[0].Coordinate.Longitude };
				LatLonUpd(g);
			};	
		}
	}

	/*public class GeoEventArgs : EventArgs
	{
		Geo geo;

		public GeoEventArgs(Geo g)
		{
			geo = g;
		}

		//public CLLocation Location
		//{
		//	get { return location; }
		//}
	}*/
}
