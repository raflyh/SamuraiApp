

namespace SamuraiApp.API.DTO
{
    public class ElemenKatanaDTO
    {
        public KatanaInsertDTO KatanaInsertDTO { get; set; }
        public List<ElemenDTO> ElemenDTOs { get; set; } = new List<ElemenDTO>();
    }
}
