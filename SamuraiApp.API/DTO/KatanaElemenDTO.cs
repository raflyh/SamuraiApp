namespace SamuraiApp.API.DTO
{
    public class KatanaElemenDTO
    {
        public string Name { get; set; }
        public string ForgedDate { get; set; }
        public string Weight { get; set; }
        public List<ElemenDTO> ElemenDTOs { get; set; } = new List<ElemenDTO>();
    }
}
