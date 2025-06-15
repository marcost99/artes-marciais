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
            var entidade = await _lutadorRepository.ListarPorCpf(request.Cpf);

            if (entidade == null)
            {
                entidade = _mapper.Map<Lutador>(request);

                // atribui o objeto preparacao luta inicial para o final para que ambos tenham os mesmos valores e identificador no registro. Obs.: se no Automapper configurar o mapeamento automatico para PreparacaoLutaFinal, mesmo este tendo os mesmos dados do objeto PreparacaoLutaInicial, os objetos serao diferentes e com isso será gerado um novo registro de PreparacaoLuta
                entidade.PreparacaoLutaFinal = entidade.PreparacaoLutaInicial;

                await _lutadorRepository.Adicionar(entidade);
            }
            else
            {
                // se a preparacao luta inicial for a mesma da final
                if (entidade.IdPreparacaoLutaInicial == entidade.IdPreparacaoLutaFinal)
                {
                    // cria novo objeto para preparacao final
                    var entidadePreparacaoLutaFinal = _mapper.Map<PreparacaoLuta>(request.PreparacaoLuta);

                    // seta objeto da preparacao final na entidade (deve gerar novo registro de preparacao final)
                    entidade.PreparacaoLutaFinal = entidadePreparacaoLutaFinal;
                }
                else
                {
                    // mapeia campos que devem ser atualizados da request para a entidade (mantêm registro de preparacao final mas atualiza os dados)
                    Core.Helpers.Mapper.MapProperties(request.PreparacaoLuta, entidade.PreparacaoLutaFinal);
                }

                // mapeia campos que devem ser atualizados da request para a entidade. Obs.: Nao foi utilizado o AutoMapper para nao utilizar a logica de mapeamento do registrar (esta que substitui campos que no atualizar nao devem ser substituidos)
                Core.Helpers.Mapper.MapProperties(request, entidade);

                _lutadorRepository.Atualizar(entidade);
            }

            await _lutadorRepository.SaveChangesAsync();

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
