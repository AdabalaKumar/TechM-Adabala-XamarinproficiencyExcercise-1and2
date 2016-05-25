using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Serialization;
using System.IO;
using System.Net;

namespace Tech_Test
{
	public class ColorServices
	{
		public ColorServices ()
		{
		}
		public async Task<colorsList> GetColors()
		{
			try
			{
				var response = await Get();
				var colorList = new colorsList();
				if (!string.IsNullOrEmpty(response))
				{

					var serializer = new XmlSerializer(typeof(colorsList));

					colorList = (colorsList)serializer.Deserialize(new StringReader(response));

				}
				return colorList;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<string> Get()
		{
			string _result = string.Empty;

			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://www.colourlovers.com/api/colors/random");
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var resposne = await client.GetAsync(client.BaseAddress);
				if (resposne.StatusCode == HttpStatusCode.OK)
					_result = resposne.Content.ReadAsStringAsync().Result;
				else
					_result = "";

			}
			return _result;

		}
	}
}

