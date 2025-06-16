namespace ArtesMarciais.Core.Entities
{
    public class Campeonato
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Localidade { get; set; } = null!;
        public DateTime DataRealizacao { get; set; }

        public virtual IEnumerable<LutadorCampeonato> LutadorCampeonato { get; set; } = null!;
    }
}
