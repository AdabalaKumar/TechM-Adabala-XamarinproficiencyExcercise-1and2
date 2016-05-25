using System;
using System.ComponentModel;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Tech_Test
{
	public class ImgViewModel:INotifyPropertyChanged
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

		}
		string _name;
		public string Name
		{
			protected set
			{
				if (_name != value)
				{
					_name = value;
					OnPropertyChanged("Name");
				}
			}
			get { return _name; }
		}
		ImageSource _imgsource;
		public ImageSource ImgSource
		{
			protected set
			{
				if (_imgsource != value)
				{
					_imgsource = value;
					OnPropertyChanged("ImgSource");
				}
			}
			get { return _imgsource; }
		}
		public async static Task<List<ImgViewModel>> UpdateImage()
		{
			List<ImgViewModel> newitem = new List<ImgViewModel> ();
			ImgServices cs = new ImgServices ();
			var item =await cs.GetImgs ();
			newitem.Add (new ImgViewModel{Name=item.colors[0].title,ImgSource =ImageSource.FromUri(new Uri(item.colors[0].imageUrl)) });
			return newitem;
		}
		public static List<ImgViewModel> All;
		static ImgViewModel ()
		{
			All = new List<ImgViewModel> ();
			All.Add (new ImgViewModel{Name="kumar",ImgSource=ImageSource.FromUri(new Uri("http://colourlovers.com.s3.amazonaws.com/images/patterns/1754/1754434.png"))});
			//
		}
	}
}

