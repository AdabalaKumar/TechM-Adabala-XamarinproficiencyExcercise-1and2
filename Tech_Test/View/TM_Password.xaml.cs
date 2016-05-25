using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Tech_Test
{
	public partial class TM_Password : ContentPage
	{
		public TM_Password ()
		{
			InitializeComponent ();
			BindingContext =new PasswordViewModel();

		}
	}
}

