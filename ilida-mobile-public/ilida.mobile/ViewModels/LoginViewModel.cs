using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ilida.mobile
{
	public class LoginViewModel : BaseViewModel
	{
		INavigationService _nav;
		IClientService _client;

		public LoginViewModel(INavigationService nav, IClientService client)
		{
			this._nav = nav;
			this._client = client;
			this.LoginCommand = new Command(() => Login());
		}

		private string _username;
		public string Username
		{
			get
			{
				return _username;
			}
			set
			{
				_username = value;
			}
		}

		public string Password { get; set; }

		private bool _rememberMe;
		public bool RememberMe
		{
			get
			{
				return _rememberMe;
			}
			set
			{
				_rememberMe = value;
				OnPropertyChanged(nameof(RememberMe));

			}
		}

		public ICommand LoginCommand { get; set; }

		private string _errorMessage;
		public string ErrorMessage
		{
			get
			{
				return _errorMessage;
			}
			set
			{
				_errorMessage = value;
				OnPropertyChanged(nameof(ErrorMessage));
			}
		}

		public async Task Login()
		{
			try
			{
				await _client.Login(Username, Password);
				ErrorMessage = "";
				await _nav.PushAsync<AccidentListViewModel>();
			}
			catch (Exception ex)
			{
				ErrorMessage = "Λάθος όνομα χρήστη ή κωδικός";
				return;
			}

		}
	}
}
