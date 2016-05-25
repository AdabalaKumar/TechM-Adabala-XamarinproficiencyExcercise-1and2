using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Tech_Test
{
	public partial class TM_ColorView : CarouselPage
	{
		public TM_ColorView ()
		{
			InitializeComponent ();
			var item = ColorViewModel.All;
			StackLayout sl = new StackLayout ();

			Label lblName = new Label ();
			lblName.Text = item [0].Name;

			Button btn = new Button ();
			btn.HorizontalOptions = LayoutOptions.FillAndExpand;
			btn.VerticalOptions = LayoutOptions.FillAndExpand;
			btn.BackgroundColor = Color.FromHex(item [0].ColorCode);
			btn.Clicked+= async (object sender, EventArgs e) => {				
				lblName.Text ="Please wait Loading...";
				IsBusy=true;
				var newitem =await ColorViewModel.Updatecolor();
				lblName.Text = newitem [0].Name;
				btn.BackgroundColor = Color.FromHex(newitem [0].ColorCode);
				IsBusy=false;
			};
			sl.Children.Add (lblName);
			sl.Children.Add (btn);

			ContentPage cp = new ContentPage ();
			cp.Content = sl;
			Children.Add (cp);

		}
	}
}

