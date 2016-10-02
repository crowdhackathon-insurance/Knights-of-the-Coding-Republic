using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ilida.mobile.expert
{
	public class Accident : BaseViewModel
	{
		INavigationService _nav;
		public Accident(INavigationService nav)
		{
			_nav = nav;
			ShowImagesCommand = new Command(async () => await ShowImages());
		}

		public ICommand ShowImagesCommand { get; set; }

		public string AccidentId { get; set; }
		public string Date { get; set; }
		public string Status { get; set; }
		public string Address { get; set; }

		public string HeavilyInjured { get; set; }

		public ICollection<string> Vehicles { get; set; }
		public string VehiclesString
		{
			get
			{
				return string.Join(",\n", Vehicles);
			}
		}
		public ICollection<string> Drivers { get; set; }
		public string DriversString
		{
			get
			{
				return string.Join(",\n", Drivers);
			}
		}
		public ICollection<string> InsuredPeople { get; set; }
		public string InsuredPeopleString
		{
			get
			{
				return string.Join(",\n", InsuredPeople);
			}
		}

		public ICollection<string> InsuranceCompanies { get; set; }
		public string InsuranceCompaniesString
		{
			get
			{
				return string.Join(",\n", InsuranceCompanies);
			}
		}
		public ICollection<string> Photos { get; set; }


		public async Task ShowImages()
		{
			var ivm = new ImagesViewModel(_nav) { Images = this.Photos };
			await _nav.PushAsync(ivm);
		}
	}
}
