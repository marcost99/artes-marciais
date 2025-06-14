namespace ArtesMarciais.Core.Entities
{
    public class PreparacaoLuta
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = null!;
        public decimal PesoLimiteInicial { get; set; }
        public decimal PesoLimiteFinal { get; set; }
    }
}
