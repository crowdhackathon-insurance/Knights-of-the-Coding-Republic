using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ilida.Api.Client;
using Ilida.Api.Dtos;
using System.Linq;

namespace ilida.mobile
{
	public class ClientService : IClientService
	{
		private IIlidaApi _api;

		private UserDto _currentUser;

		public ClientService(IIlidaApi api)
		{
			_api = api;
		}

		public async Task Login(string username, string password)
		{
			var user = await _api.LoginAsync(new LoginRequest() { Username = username, Password = password });
			_currentUser = user;
		}

		public async Task<ICollection<Accident>> GetAccidents()
		{
			var accidents = await _api.GetAccidentsAsync(_currentUser.Id);
			return accidents.Select(a => new Accident()
			{
				AccidentId = a.Id.ToString(),
				Date = a.OccuredOn.ToString(),
				Status = a.WorkflowStatus.Description
			}).ToList();
		}

		public async Task CreateAccident(ICollection<Vehicle> vehicles, ICollection<string> photos, bool HeavilyInjured)
		{
			var request = new CreateAccidentRequest()
			{
				UserId = _currentUser.Id,
				AccidentPhotos = photos,
				AccidentParticipants = vehicles.Select(v => new AccidentParticipantDto()
				{
					IdCard = v.PersonNumber,
					AccidentCar = new AccidentCarDto() { CarPlate = v.VehicleNumber }
				}),
				OccuredOn = DateTime.Now
			};
			await _api.CreateAccidentAsync(request);
		}
	}
}
