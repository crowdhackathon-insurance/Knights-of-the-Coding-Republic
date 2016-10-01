using System;
namespace ilida.mobile
{
	public class Vehicle
	{
		public Vehicle()
		{
		}

		public SubmitAccidentViewModel Parent { get; set; }

		public int VehicleId { get; set; }
		public string VehicleNumber { get; set; }
		public string PersonNumber { get; set; }
	}
}
