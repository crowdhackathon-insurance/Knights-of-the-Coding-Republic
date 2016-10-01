using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using Xamarin.Forms;

namespace ilida.mobile
{
	public class SubmitAccidentViewModel : BaseViewModel
	{
		INavigationService _nav;

		public SubmitAccidentViewModel(INavigationService nav)
		{
			_nav = nav;
			_vehicles = new ObservableCollection<Vehicle>()
			{
				new Vehicle(){VehicleId=1, Parent=this}
			};
			AddVehicleCommand = new Command(() => AddVehicle());
			RemoveCommand = new Command<int>((id) => RemoveVehicle(id));
			SubmitCommand = new Command(() => Submit());
		}

		public ICommand AddVehicleCommand { get; set; }
		public ICommand RemoveCommand { get; set; }
		public ICommand SubmitCommand { get; set; }

		private ObservableCollection<Vehicle> _vehicles;
		public ObservableCollection<Vehicle> Vehicles
		{
			get
			{
				return _vehicles;
			}
			set
			{
				_vehicles = value;
				OnPropertyChanged(nameof(Vehicles));
			}
		}

		public void AddVehicle()
		{
			var last = _vehicles.LastOrDefault();
			int id = 1;
			if (last != null)
			{
				id = last.VehicleId + 1;
			}

			var vehicle = new Vehicle()
			{
				VehicleId = id,
				Parent = this
			};
			_vehicles.Add(vehicle);
		}

		public void RemoveVehicle(int id)
		{
			var vehicle = _vehicles.Where(v => v.VehicleId == id).FirstOrDefault();
			if (vehicle != null)
			{
				_vehicles.Remove(vehicle);
			}

		}

		public void Submit()
		{

		}
	}
}
