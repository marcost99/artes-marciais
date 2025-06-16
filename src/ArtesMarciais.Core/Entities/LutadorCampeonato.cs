namespace ArtesMarciais.Core.Entities
{
    public class LutadorCampeonato
    {
        public int LutadorId { get; set; }
        public Lutador Lutador { get; set; } = null!;

        public int CampeonatoId { get; set; }
        public Campeonato Campeonato { get; set; } = null!;
    }
}
