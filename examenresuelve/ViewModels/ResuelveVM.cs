using System;
using MvvmHelpers;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace examenresuelve
{
	public class ResuelveVM : BaseViewModel
	{
		private IUserDialogs Diag;

		private bool mocupado;
		public bool Ocupado
		{
			get { return mocupado; }
			set
			{
				if (mocupado != value)
				{
					if (value)
						Diag.ShowLoading("Cargando...");
					else
						Diag.HideLoading();
                    mocupado = value;
					OnPropertyChanged("Ocupado");
				}
			}
		}

		public ResuelveVM(IUserDialogs diag)
		{
			Diag = diag;
		}
	}
}
