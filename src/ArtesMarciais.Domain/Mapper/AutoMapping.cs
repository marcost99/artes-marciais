using ArtesMarciais.Core.DTO;
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
            CreateMap<LutadorDTO, Lutador>()
                .ReverseMap();
        }

        private void DtoToEntity()
        {
            CreateMap<LutadorRegistrarDTO, Lutador>();
        }
    }
}
