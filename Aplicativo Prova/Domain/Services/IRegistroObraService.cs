using Aplicativo_Prova.Dtos;
namespace Aplicativo_Prova.Domain.Services
{
    public interface IRegistroObraService
    {
        Task ProcessarAsync(RegistroObraRequest request);
    }
}
