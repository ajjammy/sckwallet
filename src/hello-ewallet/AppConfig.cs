using System.IO;
using Microsoft.Extensions.Configuration;

namespace hello_ewallet
{
	public static class AppConfig
	{
		public static IConfigurationRoot Config = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();
	}
}