using System;
namespace examenresuelve
{

	public class Geo { 
		public Double latitude { get; set; }
		public Double longitud { get; set; }
	}

	public interface IGeo
	{
		void GetLatLon(); 

		Action<Geo> LatLonUpd { get; set; }
	}
}
