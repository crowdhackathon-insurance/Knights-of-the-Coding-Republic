using System;
using System.Threading.Tasks;

namespace ilida.client
{
	public interface IlidaClient
	{
		Task<string> Login(string username, string password);
	}
}
