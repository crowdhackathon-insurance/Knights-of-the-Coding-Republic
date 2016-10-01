using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ilida.mobile
{
	public interface INavigationService
	{
		void Register(BaseViewModel viewModel, Page view);
		Page GetView(BaseViewModel viewModel);
		Page GetView<T>() where T : BaseViewModel;
		BaseViewModel GetViewModel(Page view);

		Task PopAsync();
		Task PopModalAsync();
		Task PushAsync(BaseViewModel viewModel);
		Task PushAsync<T>(Action<T> initialize = null) where T : BaseViewModel;
		Task PushModalAsync<T>(Action<T> initialize = null) where T : BaseViewModel;
		Task PushModalAsync(BaseViewModel viewModel);
		Task PopToRootAsync(bool animate);
		void SwitchDetailPage<T>(Action<T> initialize = null) where T : BaseViewModel;
		void SwitchDetailPage(BaseViewModel viewModel);
	}
}
