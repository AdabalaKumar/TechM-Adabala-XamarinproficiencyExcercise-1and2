using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Tech_Test
{
	public partial class TM_ImageView : CarouselPage
	{
		public TM_ImageView ()
		{
			InitializeComponent ();

			var item = ImgViewModel.All;

			StackLayout sl = new StackLayout ();

			Label lblName = new Label ();
			lblName.Text = item [0].Name;

			Image btn = new Image ();
			btn.HorizontalOptions = LayoutOptions.FillAndExpand;
			btn.VerticalOptions = LayoutOptions.FillAndExpand;
			btn.Source = item[0].ImgSource;
			btn.GestureRecognizers.Add (new TapGestureRecognizer{Command=new Command(async (obj) => {
				lblName.Text ="Please wait image Loading...";
				IsBusy=true;
				var newitem =await ImgViewModel.UpdateImage();
				lblName.Text = newitem [0].Name;
				btn.Source = newitem[0].ImgSource;
				IsBusy=false;

			}) });	
			sl.Children.Add (lblName);
			sl.Children.Add (btn);

			ContentPage cp = new ContentPage ();
			cp.Content = sl;
			Children.Add (cp);
		}
	}
}

