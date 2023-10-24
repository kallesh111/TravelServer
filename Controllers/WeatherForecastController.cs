using FireSharp.Config;
using FireSharp.Interfaces;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Microsoft.AspNetCore.Mvc;
using TravelServer.Models;

namespace TravelServer.Controllers
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
        public async Task<Dictionary<string, Users>> Get()
        {
            var dbPath = "https://kallesh-default-rtdb.firebaseio.com/";
            var dataBase = "kallesh-default-rtdb";
            var seacreat = "5oHPaD1B9XkyuYlovZPF7fbWiR7kOpuve7ceYjAQ";


            IFirebaseClient client;
            IFirebaseConfig config = new FirebaseConfig()
            {
                AuthSecret = seacreat,
                BasePath = dbPath,
            };
            client = new FireSharp.FirebaseClient(config);
            var user = new Users()
            {
                Id = 1,
                Name = "user",
                Email = "User@gmail.com"
            };
            // var result = await client.PushAsync<Users>("Users/" ,user);
            var result = await client.GetAsync("Users/");
            var ds = result.ResultAs<Dictionary<string ,Users>>();
            return ds;
        }
    }
}