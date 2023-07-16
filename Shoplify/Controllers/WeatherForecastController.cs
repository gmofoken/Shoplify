using Google.Apis.Auth.AspNetCore3;
using Google.Apis.Drive.v3;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Minio;
using System.IO;
using System.Net;

namespace Shoplify.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        //[GoogleScopedAuthorize(DriveService.ScopeConstants.DriveReadonly)]

        public async Task<IEnumerable<WeatherForecast>> GetAsync()
        {
            //var client = new MinioClient();

            //client.WithCredentials("zG7afB41fhzHc763KjlW", "l0GjM0ADpcnN4Yth8dqLnWFU1iHQcdY4bfNshBbK");

            testc();

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


        private async void testc()
        {
            //var client = new MinioClient("127.0.0.1:9000", "zG7afB41fhzHc763KjlW",
            //                             "l0GjM0ADpcnN4Yth8dqLnWFU1iHQcdY4bfNshBbK");

            IWebProxy proxy = new WebProxy("127.0.0.1", 9000);
            MinioClient minioClient = new MinioClient()
                                          .WithEndpoint("127.0.0.1:9000")
                                          .WithCredentials("minio", "minio123")
                                          .WithSSL()
                                          .WithProxy(proxy)
                                          .Build();

            var list = await minioClient.ListBucketsAsync();
            //var buckets = await minioClient.ListBucketsAsync();
            //foreach  (var bucket in buckets)
            //{
            //    Console.Out.WriteLine(bucket.Name + " " + bucket.CreationDateDateTime);
            //}

        }
    }
}