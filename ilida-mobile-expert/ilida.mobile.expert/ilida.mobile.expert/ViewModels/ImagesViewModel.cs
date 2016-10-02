using System;
using System.Collections.Generic;

namespace ilida.mobile.expert
{
	public class ImagesViewModel : BaseViewModel
	{
		INavigationService _nav;
		public ImagesViewModel(INavigationService nav)
		{
			_nav = nav;
		}

		public ICollection<string> Images { get; set; }
	}
}
