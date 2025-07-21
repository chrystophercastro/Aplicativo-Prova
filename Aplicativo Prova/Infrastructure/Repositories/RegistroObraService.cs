using Aplicativo_Prova.Data;
using Aplicativo_Prova.Domain.Entities;
using Aplicativo_Prova.Domain.Services;
using Aplicativo_Prova.Dtos;
namespace Aplicativo_Prova.Infrastructure.Repositories
{
    public class RegistroObraService : IRegistroObraService
    {
        private readonly ObraDbContext _context;
        private readonly IClimaService _climaService;

        public RegistroObraService(ObraDbContext context, IClimaService climaService)
        {
            _context = context;
            _climaService = climaService;
        }

        public async Task ProcessarAsync(RegistroObraRequest request)
        {
            var cidade = "Goiânia";

            var temperatura = await _climaService.ObterTemperaturaAtualAsync(cidade);
            var condicao = DeterminarCondicao(temperatura);

            var registro = new RegistroObra
            {
                Id = Guid.NewGuid(),
                ServicoExecutado = request.ServicoExecutado,
                Data = request.Data,
                Responsavel = request.Responsavel,
                Temperatura = temperatura,
                CondicaoClimatica = condicao
            };

            _context.RegistrosObra.Add(registro);
            await _context.SaveChangesAsync();
        }


        private string DeterminarCondicao(double temp)
        {
            if (temp >= 15 && temp <= 30) return "ótimas condições";
            if (temp >= 10 && temp <= 14) return "agradável";
            return "impraticável";
        }
    }
}
