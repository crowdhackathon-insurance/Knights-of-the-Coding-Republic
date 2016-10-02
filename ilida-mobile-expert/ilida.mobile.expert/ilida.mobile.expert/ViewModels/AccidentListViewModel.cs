using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ilida.mobile.expert
{
	public class AccidentListViewModel : BaseViewModel
	{
		INavigationService _nav;

		public AccidentListViewModel(INavigationService nav)
		{
			_nav = nav;
			_accidents = new List<AccidentViewModel>()
			{
				new AccidentViewModel(_nav){
					AccidentId="891291",
					Date="11/09/2016 14:30",
					Status="Προς Ανάληψη από Εμπειρογνώμονα",
					Address="Πειραιώς 100, Αθήνα",
					Drivers=new List<string>(){"Νικολάου Νικόλαος","Γεωργίου Γεώργιος"},
					HeavilyInjured="ΝΑΙ",
					InsuredPeople=new List<string>(){"Νικολάου Νικόλαος","Γεωργίου Γεώργιος"},
					InsuranceCompanies=new List<string>(){"Άλφα Ασφαλιστική","Ωμέγα Ασφαλιστική"},
					Vehicles=new List<string>(){"ZMI1543","KIA1231"},
					Photos=new List<string>(){"http://www.caraccidentlawyerdc.com/wp-content/uploads/2013/11/Car-Accident.jpg","http://i.telegraph.co.uk/multimedia/archive/01709/car-accident_1709879b.jpg"}
				},
				new AccidentViewModel(_nav){
					AccidentId="732291",
					Date="12/03/2015 11:00",
					Status="Ολοκληρώθηκε",
					Address="Πειραιώς 100, Αθήνα",
					Drivers=new List<string>(){"Νικολάου Νικόλαος","Γεωργίου Γεώργιος"},
					HeavilyInjured="ΝΑΙ",
					InsuredPeople=new List<string>(){"Νικολάου Νικόλαος","Γεωργίου Γεώργιος"},
					InsuranceCompanies=new List<string>(){"Άλφα Ασφαλιστική","Ωμέγα Ασφαλιστική"},
					Vehicles=new List<string>(){"ZMI1543","KIA1231"},
					Photos=new List<string>(){"http://www.caraccidentlawyerdc.com/wp-content/uploads/2013/11/Car-Accident.jpg","http://i.telegraph.co.uk/multimedia/archive/01709/car-accident_1709879b.jpg"}
				}
			};
			SubmitCommand = new Command(async () => await Submit());
			SelectCommand = new Command<AccidentViewModel>(async (a) => await Select(a));
		}

		public ICommand SubmitCommand { get; set; }
		public ICommand SelectCommand { get; set; }

		private ICollection<AccidentViewModel> _accidents;
		public ICollection<AccidentViewModel> Accidents
		{
			get
			{
				return _accidents;
			}
			set
			{
				_accidents = value;
				OnPropertyChanged(nameof(Accidents));
			}
		}

		private AccidentViewModel _selectedItem;
		public AccidentViewModel SelectedItem
		{
			get
			{
				return _selectedItem;
			}
			set
			{
				_selectedItem = value;
				if (_selectedItem == null)
				{
					return;
				}
				SelectCommand.Execute(_selectedItem);
				_selectedItem = null;
				OnPropertyChanged(nameof(SelectedItem));
			}
		}

		public async Task Submit()
		{
			//await _nav.PushAsync<SubmitAccidentViewModel>();
		}

		public async Task Select(AccidentViewModel a)
		{
			//var avm = new AccidentViewModel(_nav)
			//{
			//	AccidentId = a.AccidentId,
			//	Status = a.Status
			//};
			//await _nav.PushAsync(avm);
		}

	}
}
