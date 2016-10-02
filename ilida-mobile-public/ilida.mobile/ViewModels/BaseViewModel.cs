using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ilida.mobile
{
	public abstract class BaseViewModel : INotifyPropertyChanged
	{
		public BaseViewModel()
		{
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this,
					new PropertyChangedEventArgs(propertyName));
		}

		public virtual void Activated()
		{
			
		}

	}
}
