using ArtesMarciais.Core.Enum;

namespace ArtesMarciais.Core.Entities
{
    public class Lutador
    {
        public int Id { get; set; }
        public string Cpf { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public DateOnly DataNascimento { get; set; }
        public SexoEnum Sexo { get; set; }
        public decimal Altura { get; set; }
        public decimal Peso { get; set; }
        public int IdPreparacaoLutaInicial { get; set; }
        public int IdPreparacaoLutaFinal { get; set; }
        public virtual PreparacaoLuta PreparacaoLutaInicial { get; set; } = null!;
        public virtual PreparacaoLuta PreparacaoLutaFinal { get; set; } = null!;
    }
}
