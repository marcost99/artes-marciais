namespace ArtesMarciais.Core.DTO.Registrar
{
    public class PreparacaoLutaRegistrarDTO
    {
        public string Descricao { get; set; } = null!;
        public decimal PesoLimiteInicial { get; set; }
        public decimal PesoLimiteFinal { get; set; }
    }
}
