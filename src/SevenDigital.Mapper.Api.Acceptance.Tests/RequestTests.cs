using System;
using System.IO;
using System.Net;
using NUnit.Framework;

namespace SevenDigital.Mapper.Api.Acceptance.Tests
{
	[TestFixture]
	public class RequestTests
	{

		[Test]
		public void Should_map_from_json_for_musicbrainz()
		{
			var request = (HttpWebRequest)WebRequest.Create("http://localhost/mapper/track");
			request.ContentType = "application/json";
			request.Method = "POST";
			using (var streamWriter = new StreamWriter(request.GetRequestStream()))
			{
				string json = @"{""MusicBrainz"": ""002a3183-697f-4cd7-a1f1-ec82b7d7ffcf"" }";

				streamWriter.Write(json);
			}
			var response = (HttpWebResponse)request.GetResponse();
			using (var streamReader = new StreamReader(response.GetResponseStream()))
			{
				Console.WriteLine(streamReader.ReadToEnd());
			}
		}

		[Test]
		public void Should_map_from_json_for_sevendigital()
		{
			var request = (HttpWebRequest)WebRequest.Create("http://localhost/mapper/track");
			request.ContentType = "application/json";
			request.Method = "POST";
			using (var streamWriter = new StreamWriter(request.GetRequestStream()))
			{
				string json = @"{""SevenDigital"": ""5216449"" }";

				streamWriter.Write(json);
			}
			var response = (HttpWebResponse)request.GetResponse();
			using (var streamReader = new StreamReader(response.GetResponseStream()))
			{
				Console.WriteLine(streamReader.ReadToEnd());
			}
		}
	}
}
