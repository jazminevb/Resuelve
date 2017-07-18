using System;
using System.Threading.Tasks;
using Refit;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace examenresuelve
{
	public interface IAllBranch
	{
		/// <summary>
		/// Interface para la conexion POST al servicio con el metodo GetAllBranch
		/// </summary>
		/// <returns>Coleccion de sucursales</returns>
		/// <param name="countryId">Country identifier.</param>
		[Post("/getAllBranch")]
		Task<ObservableCollection<sucursal>> GetAllBranch(int countryId);
	}
}
