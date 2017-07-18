using Xamarin.Forms;

namespace examenresuelve
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			NavigationPage np = new NavigationPage(new ListaSucursales());
			np.Style = Resources["NavigationPage"] as Style;
			MainPage = np;
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
