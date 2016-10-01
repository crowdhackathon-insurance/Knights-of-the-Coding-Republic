using System;
using System.Collections.ObjectModel;

namespace ilida.mobile
{
	public class AccidentViewModel : BaseViewModel
	{
		INavigationService _nav;

		public AccidentViewModel(INavigationService nav)
		{
			_nav = nav;
			Notifications = new ObservableCollection<Notification>() {
				new Notification(){
					NotificationId=2,
					Action="Επεξεργασία Περιστατικού",
					From="Χρήστης Ασφαλιστικής Άλφα",
					Date=new DateTime().ToString(),
					Comments="Εδώ μπαίνουν σχόλια"
				},
				new Notification(){
					NotificationId=1,
					Action="Υποβολή Περιστατικού",
					From="Νικολάου Νικόλαος",
					Date=new DateTime().ToString(),
					Comments="Εδώ μπαίνουν σχόλια"
				}
			};
		}

		public string AccidentId { get; set; }

		private string _status;
		public string Status
		{
			get
			{
				return _status;
			}
			set
			{
				_status = value;
				OnPropertyChanged(nameof(Status));
			}
		}

		private ObservableCollection<Notification> _notifications;
		public ObservableCollection<Notification> Notifications
		{
			get
			{
				return _notifications;
			}
			set
			{
				_notifications = value;
				OnPropertyChanged(nameof(Notifications));
			}
		}
	}
}
