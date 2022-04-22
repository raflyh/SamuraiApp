using SamuraiApp.Domain;

namespace SamuraiApp.API.DTO
{
    public class SamuraiKatanaDTO
    {
        public SamuraiCreateDTO SamuraiCreateDTOs { get; set; }
        public List<KatanaSamuraiDTO> KatanaSamuraiDTOs { get; set; } = new List<KatanaSamuraiDTO>();
    }
}
