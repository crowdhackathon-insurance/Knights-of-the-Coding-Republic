using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ilida.mobile
{
	public class NavigationService : INavigationService
	{
		private INavigation _navigation;

		private Dictionary<Page, BaseViewModel> _viewsToVms;
		private Dictionary<BaseViewModel, Page> _vMsToViews;

		public NavigationService(INavigation navigation)
		{
			_navigation = navigation;
			_viewsToVms = new Dictionary<Page, BaseViewModel>();
			_vMsToViews = new Dictionary<BaseViewModel, Page>();
		}

		public Page GetView(BaseViewModel viewModel)
		{
			return _vMsToViews[viewModel];
		}

		public Page GetView<T>() where T : BaseViewModel
		{
			foreach (var vm in _vMsToViews.Keys)
			{
				var cvm = vm as T;
				if (cvm != null)
				{
					var view = this._vMsToViews[cvm];
					return view;
				}
			}
			return null;
		}

		public BaseViewModel GetViewModel(Page view)
		{
			return _viewsToVms[view];
		}

		public Task PopAsync()
		{
			throw new NotImplementedException();
		}

		public Task PopModalAsync()
		{
			throw new NotImplementedException();
		}

		public Task PopToRootAsync(bool animate)
		{
			throw new NotImplementedException();
		}

		public async Task PushAsync(BaseViewModel viewModel)
		{
			foreach (var vm in _vMsToViews.Keys)
			{
				if (viewModel.GetType() == vm.GetType())
				{
					var view = this._vMsToViews[vm];
					view.BindingContext = viewModel;
					await this._navigation.PushAsync(view);
					return;
				}
			}
		}

		public async Task PushAsync<T>(Action<T> initialize = null) where T : BaseViewModel
		{
			foreach (var vm in _vMsToViews.Keys)
			{
				var cvm = vm as T;
				if (cvm != null)
				{
					var view = this._vMsToViews[cvm];
					await this._navigation.PushAsync(view);
					return;
				}
			}
		}

		public Task PushModalAsync(BaseViewModel viewModel)
		{
			throw new NotImplementedException();
		}

		public Task PushModalAsync<T>(Action<T> initialize = null) where T : BaseViewModel
		{
			throw new NotImplementedException();
		}

		public void Register(BaseViewModel viewModel, Page view)
		{
			view.BindingContext = viewModel;
			_viewsToVms[view] = viewModel;
			_vMsToViews[viewModel] = view;
		}

		public void SwitchDetailPage(BaseViewModel viewModel)
		{
			throw new NotImplementedException();
		}

		public void SwitchDetailPage<T>(Action<T> initialize = null) where T : BaseViewModel
		{
			throw new NotImplementedException();
		}
	}
}
