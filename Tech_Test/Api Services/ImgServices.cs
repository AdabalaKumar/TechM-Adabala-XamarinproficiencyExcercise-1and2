using System;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;

namespace Tech_Test
{
	public class ImgServices
	{
		public ImgServices ()
		{
		}
		public async Task<patternsList> GetImgs()
		{
			try
			{
				var response = await Get();
				var imgList = new patternsList();
				if (!string.IsNullOrEmpty(response))
				{

					var serializer = new XmlSerializer(typeof(patternsList));

					imgList = (patternsList)serializer.Deserialize(new StringReader(response));

				}
				return imgList;
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
				client.BaseAddress = new Uri("http://www.colourlovers.com/api/patterns/random");
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

