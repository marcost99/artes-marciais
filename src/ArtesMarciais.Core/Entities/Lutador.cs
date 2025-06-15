using ArtesMarciais.Core.Enum;
using ArtesMarciais.Core.Helpers.Attributes;

namespace ArtesMarciais.Core.Entities
{
    public class Lutador
    {
        [NeverReplaced]
        public int Id { get; set; }
        [NeverReplaced]
        public string Cpf { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public DateOnly DataNascimento { get; set; }
        public SexoEnum Sexo { get; set; }
        public decimal Altura { get; set; }
        public decimal Peso { get; set; }
        [NeverReplaced]
        public int IdPreparacaoLutaInicial { get; set; }
        public int IdPreparacaoLutaFinal { get; set; }
        
        [NeverReplaced]
        public virtual PreparacaoLuta PreparacaoLutaInicial { get; set; } = null!;
        public virtual PreparacaoLuta PreparacaoLutaFinal { get; set; } = null!;
    }
}
