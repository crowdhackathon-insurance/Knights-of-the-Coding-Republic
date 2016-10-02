using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace ilida.mobile
{
	public class SubmitAccidentViewModel : BaseViewModel
	{
		INavigationService _nav;
		IClientService _client;

		public SubmitAccidentViewModel(INavigationService nav, IClientService client)
		{
			_nav = nav;
			_client = client;

			_vehicles = new ObservableCollection<Vehicle>()
			{
				new Vehicle(){VehicleId=1, Parent=this}
			};
			AddVehicleCommand = new Command(() => AddVehicle());
			RemoveCommand = new Command<int>((id) => RemoveVehicle(id));
			SubmitCommand = new Command(async () => await Submit());
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

		private bool _seriouslyInjured = false;
		public bool SeriouslyInjured
		{
			get
			{
				return _seriouslyInjured;
			}
			set
			{
				_seriouslyInjured = value;
				OnPropertyChanged(nameof(SeriouslyInjured));
			}
		}

		private bool _inAccidentLocation = true;
		public bool InAccidentLocation
		{
			get
			{
				return _inAccidentLocation;
			}
			set
			{
				_inAccidentLocation = value;
				OnPropertyChanged(nameof(InAccidentLocation));
			}
		}

		private string _message;
		public string Message
		{
			get
			{
				return _message;
			}
			set
			{
				_message = value;
				OnPropertyChanged(nameof(Message));
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

		public async Task Submit()
		{
			try
			{
				var photos = new List<string>() { "http://www.caraccidentlawyerdc.com/wp-content/uploads/2013/11/Car-Accident.jpg", "http://i.telegraph.co.uk/multimedia/archive/01709/car-accident_1709879b.jpg" };
				await _client.CreateAccident(Vehicles, photos, SeriouslyInjured);
				Message = "Το ατύχημα καταχωρήθηκε.";
			}
			catch (Exception ex)
			{
				Message = "Πρόβλημα στην καταχώρηση ατυχήματος!";
			}
			//await _nav.PushAsync<AccidentListViewModel>();
		}
	}
}
