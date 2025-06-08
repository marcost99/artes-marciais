using ArtesMarciais.Core.DTO;
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

        public async Task<LutadorDTO> Registrar(LutadorRegistrarDTO request)
        {
            var entidade = _mapper.Map<Lutador>(request);

            await _lutadorRepository.Registrar(entidade);

            var dto = _mapper.Map<LutadorDTO>(entidade);

            return dto;
        }

        public async Task<IEnumerable<LutadorDTO>?> Listar()
        {
            var entidades = await _lutadorRepository.Listar();

            var dto = _mapper.Map<IEnumerable<LutadorDTO>?>(entidades);

            return dto;
        }
    }
}
