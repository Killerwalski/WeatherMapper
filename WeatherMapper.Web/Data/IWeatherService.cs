using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherMapper.Web.Data
{
    public interface IWeatherService
    {
        public Task<WeatherItem> GetWeatherItemAsync(double lat, double lng);
    }
}
