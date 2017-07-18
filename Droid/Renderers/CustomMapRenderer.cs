﻿using System;
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

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace examenresuelve.Droid
{
	public class CustomMapRenderer : MapRenderer
	{
        CustomMap formsMap;
        bool isDrawn;

		protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Map> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				formsMap = (CustomMap)e.NewElement;
				Control.GetMapAsync(this);
			}
		}

		public void OnMapReady(GoogleMap googleMap)
		{
			NativeMap = googleMap;
			NativeMap.UiSettings.ZoomControlsEnabled = Map.HasZoomEnabled;
			NativeMap.UiSettings.ZoomGesturesEnabled = Map.HasZoomEnabled;
			NativeMap.UiSettings.ScrollGesturesEnabled = Map.HasScrollEnabled;
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName.Equals("VisibleRegion") && !isDrawn)
			{
				NativeMap.Clear();
                foreach (var pin in formsMap.Pins)
				{
					var marker = new MarkerOptions();
					marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
					marker.SetTitle(pin.Label);
					marker.SetSnippet(pin.Address);
                    if (pin.Label == "Ud esta aqui")
                        marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.pinaqui));
                    else
                        marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.pinresuelve));
					NativeMap.AddMarker(marker);
				}
				isDrawn = true;
			}
		}

		protected override void OnLayout(bool changed, int l, int t, int r, int b)
		{
			base.OnLayout(changed, l, t, r, b);
			if (changed)
			{
				isDrawn = false;
			}
		}

		/*void OnInfoWindowClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
		{
			var customPin = GetCustomPin(e.Marker);
			if (customPin == null)
			{
				throw new Exception("Custom pin not found");
			}

			if (!string.IsNullOrWhiteSpace(customPin.Url))
			{
				var url = Android.Net.Uri.Parse(customPin.Url);
				var intent = new Intent(Intent.ActionView, url);
				intent.AddFlags(ActivityFlags.NewTask);
				Android.App.Application.Context.StartActivity(intent);
			}
		}*/

		/*public Android.Views.View GetInfoContents(Marker marker)
		{
			var inflater = Android.App.Application.Context.GetSystemService(Context.LayoutInflaterService) as Android.Views.LayoutInflater;
			if (inflater != null)
			{
				Android.Views.View view;

				var customPin = GetCustomPin(marker);
				if (customPin == null)
				{
					throw new Exception("Custom pin not found");
				}

				if (customPin.Id == "Xamarin")
				{
					view = inflater.Inflate(Resource.Layout.XamarinMapInfoWindow, null);
				}
				else
				{
					view = inflater.Inflate(Resource.Layout.MapInfoWindow, null);
				}

				var infoTitle = view.FindViewById<TextView>(Resource.Id.InfoWindowTitle);
				var infoSubtitle = view.FindViewById<TextView>(Resource.Id.InfoWindowSubtitle);

				if (infoTitle != null)
				{
					infoTitle.Text = marker.Title;
				}
				if (infoSubtitle != null)
				{
					infoSubtitle.Text = marker.Snippet;
				}

				return view;
			}
			return null;
		}*/

		/*public Android.Views.View GetInfoWindow(Marker marker)
		{
			return null;
		}*/

		/*CustomPin GetCustomPin(Marker annotation)
		{
			var position = new Position(annotation.Position.Latitude, annotation.Position.Longitude);
			foreach (var pin in customPins)
			{
				if (pin.Pin.Position == position)
				{
					return pin;
				}
			}
			return null;
		}*/
	}
}