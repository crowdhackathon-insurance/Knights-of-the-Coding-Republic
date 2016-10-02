using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ilida.mobile
{
	public partial class NavPage : NavigationPage
	{
		INavigationService _nav;

		public NavPage(Page root, INavigationService nav) : base(root)
		{
			InitializeComponent();
			_nav = nav;
		}

	}
}
