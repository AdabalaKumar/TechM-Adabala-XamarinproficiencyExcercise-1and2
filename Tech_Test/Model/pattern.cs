using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Tech_Test
{
	public class pattern
	{
		public pattern ()
		{
		}
		[XmlElement("title")]
		public string title { get; set; }
		[XmlElement("imageUrl")]
		public string imageUrl { get; set; }
	}
	[XmlRoot("patterns")]

	public class patternsList
	{
		[XmlElement("pattern")]
		public List<pattern> colors { get; set; }
	}
}


