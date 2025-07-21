namespace Aplicativo_Prova.Domain.Entities
{
    public class RegistroObra
    {
        public Guid Id { get; set; }
        public string ServicoExecutado { get; set; }
        public DateTime Data { get; set; }
        public string Responsavel { get; set; }
        public double Temperatura { get; set; }
        public string CondicaoClimatica { get; set; }
    }
}
