namespace Aplicativo_Prova.Domain.Services
{
    public interface IClimaService
    {
        Task<double> ObterTemperaturaAtualAsync(string cidade);
    }
}
