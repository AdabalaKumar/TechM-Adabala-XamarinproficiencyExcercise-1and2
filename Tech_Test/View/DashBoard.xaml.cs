using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Tech_Test
{
	public partial class DashBoard : ContentPage
	{
		public DashBoard ()
		{
			InitializeComponent ();
			btncv.Clicked+= (object sender, EventArgs e) => {
				Navigation.PushAsync(new TM_ColorView());

			};
			btniv.Clicked+= (object sender, EventArgs e) => {
				Navigation.PushAsync(new TM_ImageView());

			};
			btnpw.Clicked+= (object sender, EventArgs e) => {
				Navigation.PushAsync(new TM_Password());

			};
		}
	}
}

