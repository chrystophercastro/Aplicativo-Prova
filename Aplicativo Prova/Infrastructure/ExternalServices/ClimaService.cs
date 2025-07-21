using Aplicativo_Prova.Domain.Services;
namespace Aplicativo_Prova.Infrastructure.ExternalServices
{
    public class ClimaService : IClimaService
    {
        private readonly HttpClient _httpClient;

        public ClimaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "ServiceControlApp/1.0 (seu-email@dominio.com)");
        }

        public async Task<double> ObterTemperaturaAtualAsync(string cidade)
        {
            // 1 - Obter latitude e longitude
            var geoUrl = $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(cidade)}";

            var geoResponse = await _httpClient.GetFromJsonAsync<dynamic>(geoUrl);
            if (geoResponse.results == null || geoResponse.results.Count == 0)
                throw new Exception("Cidade não encontrada");

            double lat = geoResponse.results[0].latitude;
            double lon = geoResponse.results[0].longitude;

            // 2 - Consultar met.no
            var metUrl = $"https://api.met.no/weatherapi/locationforecast/2.0/compact?lat={lat}&lon={lon}";

            var metResponse = await _httpClient.GetFromJsonAsync<dynamic>(metUrl);

            return (double)metResponse.properties.timeseries[0].data.instant.details.air_temperature;
        }
    }

}
