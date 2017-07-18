using System;
using System.Threading.Tasks;
using Refit;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace examenresuelve
{
	public interface IAllBranch
	{
		[Post("/getAllBranch")]
		Task<ObservableCollection<sucursal>> GetAllBranch(int countryId);
	}
}
