using Microsoft.Extensions.Configuration;
using System.IO;

namespace AeropuertoTest.Context
{
    public class AeropuertoDb
    {
        private static IConfiguration Configuration { get; set; }
        public string GetConnectionString()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            return Configuration.GetConnectionString("AeropuertoDb");
        }
    }
}
