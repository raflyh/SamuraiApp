using AutoMapper;
using SamuraiApp.API.DTO;
using SamuraiApp.Domain;

namespace SamuraiApp.API.Profiles
{
    public class SamuraisProfile : Profile
    {
        public SamuraisProfile()
        {
            CreateMap<Samurai, SamuraiDTO>();
            CreateMap<Samurai, SamuraiGetDTO>()
                  .ForMember(x => x.KatanaSamuraiDTOs, b => b.MapFrom(k => k.Katanas));
            CreateMap<Samurai, SamuraiGetDTO>()
                .ForMember(x => x.KatanaElemenDTOs, b => b.MapFrom(k => k.Katanas));
            CreateMap<Katana, KatanaElemenDTO>()
                .ForMember(c => c.ElemenDTOs, m => m.MapFrom(g => g.Elemens));

            CreateMap<SamuraiUpdateDTO, Samurai>();
            CreateMap<SamuraiCreateDTO, Samurai>();
            CreateMap<SamuraiKatanaDTO, Samurai>();

            CreateMap<Katana, KatanaDTO>();
            CreateMap<Katana, KatanaSamuraiDTO>();

            CreateMap<KatanaInsertDTO, Katana>();
            CreateMap<KatanaSamuraiDTO, Katana>();

            CreateMap<Elemen, ElemenDTO>();
            CreateMap<ElemenDTO, Elemen>();
            
        }
    }
}
