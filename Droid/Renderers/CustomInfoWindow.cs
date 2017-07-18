using System;
using System.Collections.Generic;
using System.ComponentModel;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using examenresuelve;
using examenresuelve.Droid;
using Android.Views;

namespace examenresuelve.Droid
{
	public class CustomInfoWindow : Java.Lang.Object, GoogleMap.IInfoWindowAdapter
	{
		private LayoutInflater _layoutInflater = null;
		public IntPtr IJHandle { get { return IntPtr.Zero; } }

		public CustomInfoWindow(LayoutInflater inflater)
		{
			_layoutInflater = inflater;
		}

		public Android.Views.View GetInfoContents(Marker marker)
		{
			//var inflater = Android.App.Application.Context.GetSystemService(Context.LayoutInflaterService) as Android.Views.LayoutInflater;
			//if (inflater != null)
			//{
				Android.Views.View view;
				view = _layoutInflater.Inflate(Resource.Layout.infowindow, null);
				var lblSucursal = view.FindViewById<TextView>(Resource.Id.lblSucursal);
				var lblDireccion = view.FindViewById<TextView>(Resource.Id.lblDireccion);
				lblSucursal.Text = marker.Title;
				lblDireccion.Text = marker.Snippet;
				return view;
			//}
			//return null;
		}

		public Android.Views.View GetInfoWindow(Marker marker)
		{
			return null;
		}

	}
}
