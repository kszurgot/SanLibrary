using Microsoft.AspNetCore.Mvc;
using SanLibrary.Application.Services;

namespace SanLibrary.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BorrowingBookController : ControllerBase
    {
        private readonly IBorrowingBookService _borrowingBookService;

        public BorrowingBookController(IBorrowingBookService borrowingBookService)
        {
            _borrowingBookService = borrowingBookService;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    //{
        //    //    Date = DateTime.Now.AddDays(index),
        //    //    TemperatureC = Random.Shared.Next(-20, 55),
        //    //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    //})
        //    //.ToArray();
        //}
    }
}