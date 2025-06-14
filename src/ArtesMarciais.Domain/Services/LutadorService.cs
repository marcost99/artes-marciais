using ArtesMarciais.Core.DTO.Listar;
using ArtesMarciais.Core.DTO.Registrar;
using ArtesMarciais.Core.Entities;
using ArtesMarciais.Domain.Services.Interfaces;
using ArtesMarciais.Infra.Repositories.Interfaces;
using AutoMapper;

namespace ArtesMarciais.Domain.Services
{
    public class LutadorService : ILutadorService
    {
        private readonly IMapper _mapper;
        private readonly ILutadorRepository _lutadorRepository;

        public LutadorService(IMapper mapper, ILutadorRepository lutadorRepository)
        {
            _mapper = mapper;
            _lutadorRepository = lutadorRepository;
        }

        public async Task<LutadorListarDTO> Registrar(LutadorRegistrarDTO request)
        {
            var entidade = await _lutadorRepository.BuscarPorCpf(request.Cpf);

            if (entidade == null)
            {
                entidade = _mapper.Map<Lutador>(request);

                var entidadePreparacaoLutaInicial = _mapper.Map<PreparacaoLuta>(request.PreparacaoLuta);

                entidade.PreparacaoLutaInicial = entidadePreparacaoLutaInicial;

                await _lutadorRepository.Registrar(entidade);
            }
            else
            {
                var entidadePreparacaoLutaFinal = _mapper.Map<PreparacaoLuta>(request.PreparacaoLuta);
                entidadePreparacaoLutaFinal.Id = entidade.PreparacaoLutaFinal.Id;

                // fazer isso de uma outra
                entidade.Nome = request.Nome;
                entidade.DataNascimento = request.DataNascimento;
                entidade.Sexo = request.Sexo;
                entidade.Altura = request.Altura;
                entidade.Peso = request.Peso;

                entidade.PreparacaoLutaFinal = entidadePreparacaoLutaFinal;

                await _lutadorRepository.Atualizar(entidade);
            }

            var dto = _mapper.Map<LutadorListarDTO>(entidade);

            return dto;
        }

        public async Task<IEnumerable<LutadorListarDTO>?> Listar()
        {
            var entidades = await _lutadorRepository.Listar();

            var dto = _mapper.Map<IEnumerable<LutadorListarDTO>?>(entidades);

            return dto;
        }
    }
}
