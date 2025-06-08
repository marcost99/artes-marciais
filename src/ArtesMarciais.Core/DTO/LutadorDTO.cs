using ArtesMarciais.Core.Enum;

namespace ArtesMarciais.Core.DTO
{
    public class LutadorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public DateOnly DataNascimento { get; set; }
        public SexoEnum Sexo { get; set; }
        public decimal Altura { get; set; }
        public decimal Peso { get; set; }
        public CategoriaPesoEnum CategoriaPeso => CalculaCategoriaPeso(this.Peso);

        public CategoriaPesoEnum CalculaCategoriaPeso(decimal peso) => CategoriaPesoEnum.Palha;
    }
}
