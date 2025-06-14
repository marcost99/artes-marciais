using ArtesMarciais.Core.Enum;

namespace ArtesMarciais.Core.DTO.Registrar
{
    public class LutadorRegistrarDTO
    {
        public string Cpf { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public DateOnly DataNascimento { get; set; }
        public SexoEnum Sexo { get; set; }
        public decimal Altura { get; set; }
        public decimal Peso { get; set; }

        public virtual PreparacaoLutaRegistrarDTO PreparacaoLuta { get; set; } = null!;
    }
}
