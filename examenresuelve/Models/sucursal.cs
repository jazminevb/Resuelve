using System;
namespace examenresuelve
{
	public class sucursal
	{
		public string PAIS { get; set; }
		public string SUC_NAME { get; set; }
		public string SUC_ADRESS { get; set; }
		public string ESTADO { get; set; }
		public string CP { get; set; }
		public string PHONE { get; set; }
		public string LAT { get; set; }
		public string LON { get; set; }
		public int ID_COUNTRY { get; set; }

		public override string ToString()
		{
			return string.Format("[sucursal: PAIS={0}, SUC_NAME={1}, SUC_ADRESS={2}, ESTADO={3}, CP={4}, PHONE={5}, LAT={6}, LON={7}, ID_COUNTRY={8}]", PAIS, SUC_NAME, SUC_ADRESS, ESTADO, CP, PHONE, LAT, LON, ID_COUNTRY);
		}
	}
}
