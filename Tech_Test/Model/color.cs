using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Tech_Test
{
	public class color
	{
		[XmlElement("title")]
		public string title { get; set; }
		[XmlElement("hex")]
		public string hex { get; set; }
	}

	[XmlRoot("colors")]

	public class colorsList
	{
		[XmlElement("color")]
		public List<color> colors { get; set; }
	}
}

