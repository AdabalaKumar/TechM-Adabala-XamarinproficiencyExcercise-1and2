using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Tech_Test
{
	public class ColorViewModel:INotifyPropertyChanged
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
		public async static Task<List<ColorViewModel>> Updatecolor()
		{
			List<ColorViewModel> newitem = new List<ColorViewModel> ();
			ColorServices cs = new ColorServices ();
			var item =await cs.GetColors ();
			newitem.Add (new ColorViewModel{Name=item.colors[0].title,ColorCode="#"+item.colors[0].hex });
			return newitem;
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
		string _colorcode;
		public string ColorCode
		{
			protected set
			{
				if (_colorcode != value)
				{
					_colorcode = value;
					OnPropertyChanged("ColorCode");
				}
			}
			get { return _colorcode; }
		}
		public static List<ColorViewModel> All;
		static ColorViewModel ()
		{
			All = new List<ColorViewModel> ();
			All.Add (new ColorViewModel{Name="kumar",ColorCode="#FF0000" });
			
		}
	}
}

