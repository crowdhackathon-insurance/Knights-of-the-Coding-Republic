using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ilida.Api.Client;
using Ilida.Api.Dtos;
using System.Linq;

namespace ilida.mobile.expert
{
	public class ClientService : IClientService
	{
		private IIlidaApi _api;
		private INavigationService _nav;

		private UserDto _currentUser;

		public ClientService(IIlidaApi api, INavigationService nav)
		{
			_api = api;
			_nav = nav;
		}

		public async Task Login(string username, string password)
		{
			var user = await _api.LoginAsync(new LoginRequest() { Username = username, Password = password });
			_currentUser = user;
		}

		public async Task<ICollection<AccidentViewModel>> GetAccidents()
		{
			var accidents = await _api.GetAccidentsAsync(_currentUser.Id);
			return accidents.Select(a => new AccidentViewModel(_nav,this)
			{
				AccidentId = a.Id,
				Date = a.OccuredOn.ToString(),
				Status = a.WorkflowStatus.Description,
				Address = "Πειραιώς 100",
				HeavilyInjured = a.HasInjuries ? "Ναι" : "Όχι",
				Photos = a.AccidentPhotos.Select(p => p.Url).ToList(),
				Drivers = new List<string>() { "Νικολάου Νικόλαος", "Αθανασίου Αθανάσιος" },
				InsuredPeople = new List<string>() { "Νικολάου Νικόλαος", "Αθανασίου Αθανάσιος" },
				InsuranceCompanies = a.AccidentCompanies.Select(i => i.Name).ToList(),
				Vehicles = a.AccidentCars.Select(c => c.CarPlate).ToList()

			}).ToList();
		}

		public async Task Accept(long accidentId)
		{
			var accreq = new AcceptAccidentRequest()
			{
				AccidentId = accidentId,
				UserId = _currentUser.Id
			};
			await _api.AcceptAccidentAsync(accreq);
		}

		//public async Task CreateAccident(ICollection<Vehicle> vehicles, ICollection<string> photos, bool HeavilyInjured)
		//{
		//	var request = new CreateAccidentRequest()
		//	{
		//		UserId = _currentUser.Id,
		//		AccidentPhotos = photos,
		//		AccidentParticipants = vehicles.Select(v => new AccidentParticipantDto()
		//		{
		//			IdCard = v.PersonNumber,
		//			AccidentCar = new AccidentCarDto() { CarPlate = v.VehicleNumber }
		//		}),
		//		OccuredOn = DateTime.Now
		//	};
		//	await _api.CreateAccidentAsync(request);
		//}
	}
}
