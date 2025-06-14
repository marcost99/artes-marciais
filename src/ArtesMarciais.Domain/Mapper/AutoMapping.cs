using ArtesMarciais.Core.DTO.Listar;
using ArtesMarciais.Core.DTO.Registrar;
using ArtesMarciais.Core.Entities;
using AutoMapper;

namespace ArtesMarciais.Domain.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            EntityToDTO();
            DtoToEntity();
        }
        private void EntityToDTO()
        {
            CreateMap<Lutador, LutadorListarDTO>()
                .ReverseMap();
            CreateMap<PreparacaoLuta, PreparacaoLutaListarDTO>()
                .ReverseMap();
        }

        private void DtoToEntity()
        {
            CreateMap<LutadorRegistrarDTO, Lutador>();
            CreateMap<PreparacaoLutaRegistrarDTO, PreparacaoLuta>();
        }
    }
}
