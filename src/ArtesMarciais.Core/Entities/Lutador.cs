using ArtesMarciais.Core.Enum;

namespace ArtesMarciais.Core.Entities
{
    public class Lutador
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public DateOnly DataNascimento { get; set; }
        public SexoEnum Sexo { get; set; }
        public decimal Altura { get; set; }
        public decimal Peso { get; set; }
    }
}
