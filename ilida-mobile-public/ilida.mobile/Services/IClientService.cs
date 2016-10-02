using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ilida.mobile
{
	public interface IClientService
	{
		Task Login(string username, string password);
		Task<ICollection<Accident>> GetAccidents();
	}
}
