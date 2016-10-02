using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ilida.mobile.expert
{
	public interface IClientService
	{
		Task Login(string username, string password);
		Task<ICollection<AccidentViewModel>> GetAccidents();
		Task Accept(long accidentId);

		//Task CreateAccident(ICollection<Vehicle> vehicles, ICollection<string> photos, bool HeavilyInjured);
	}
}
