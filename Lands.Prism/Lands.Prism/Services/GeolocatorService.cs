using System;
using System.Threading.Tasks;
using Plugin.Geolocator;

namespace MyVet.Common.Services
{
    public class GeolocatorService : IGeolocatorService
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public async Task GetLocationAsync()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var location = await locator.GetPositionAsync();
                Latitude = 80;
                Longitude = 80;

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
