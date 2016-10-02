using Xamarin.Forms;

namespace ilida.mobile.expert
{
	public partial class App : Application
	{

		INavigationService _navigationService;
		NavigationPage _navigationPage;
		IClientService _client;
		Page _root;

		public App()
		{
			InitializeComponent();
			_root = new LoginView();
			_navigationPage = new NavPage(_root);
			_navigationService = new NavigationService(_navigationPage.Navigation);

			_client = new ClientService(new Ilida.Api.Client.IlidaApiClient(), _navigationService);

			_navigationService.Register(new LoginViewModel(_navigationService, _client), _root);
			_navigationService.Register(new AccidentListViewModel(_navigationService, _client), new AccidentListView());
			_navigationService.Register(new ImagesViewModel(_navigationService), new ImagesView());

			//MainPage = _navigationService.GetView<LoginViewModel>();
			MainPage = _navigationPage;
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
