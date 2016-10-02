using System;
namespace ilida.mobile
{
	public class Notification
	{
		public Notification()
		{
		}
		public int NotificationId { get; set; }
		public string Action { get; set; }
		public string From { get; set; }
		public string Date { get; set; }
		public string Comments { get; set; }
	}
}
