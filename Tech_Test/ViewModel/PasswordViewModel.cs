using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Tech_Test
{
	public class PasswordViewModel:INotifyPropertyChanged
	{
		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{

			PropertyChangedEventHandler eventHandler = this.PropertyChanged;
			if (eventHandler != null)
			{
				eventHandler(this, new PropertyChangedEventArgs(propertyName));
			}
			if (propertyName == "Password") {

				Regex sampleRegex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).*$");
				bool isStrongPassword= sampleRegex.IsMatch(Password);
				if (isStrongPassword) {
					Status = "Good";
					Colorstatus = Color.Green;
				} else {
					Status = "Not Good";
					Colorstatus = Color.Red;
				}
			}

		}
		string _password;
		public string Password
		{
			set
			{

					_password = value;
					OnPropertyChanged();

			}
			get { return _password; }
		}
		//Binding
		Color _colorstatus;
		public Color Colorstatus
		{
			protected set
			{
				if (_colorstatus != value)
				{
					_colorstatus = value;
					OnPropertyChanged();
				}
			}
			get { return _colorstatus; }
		}
		string _status;
		public string Status
		{
			protected set
			{
				if (_status != value)
				{
					_status = value;
					OnPropertyChanged();
				}
			}
			get { return _status; }
		}
		public PasswordViewModel ()
		{
			Status="kumar";
		}

	}
}

