using ArtesMarciais.Core.Enum;

namespace ArtesMarciais.Core.DTO
{
    public class LutadorRegistrarDTO
    {
        public string Nome { get; set; } = null!;
        public DateOnly DataNascimento { get; set; }
        public SexoEnum Sexo { get; set; }
        public decimal Altura { get; set; }
        public decimal Peso { get; set; }
    }
}
