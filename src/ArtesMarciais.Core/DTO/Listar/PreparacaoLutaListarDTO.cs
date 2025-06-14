namespace ArtesMarciais.Core.DTO.Listar
{
    public class PreparacaoLutaListarDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = null!;
        public decimal PesoLimiteInicial { get; set; }
        public decimal PesoLimiteFinal { get; set; }
    }
}
