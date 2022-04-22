namespace SamuraiApp.API.DTO
{
    public class SamuraiGetDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<KatanaSamuraiDTO> KatanaSamuraiDTOs { get; set; } = new List<KatanaSamuraiDTO>();//tanpa elemen
        public List<KatanaElemenDTO> KatanaElemenDTOs { get; set; } = new List<KatanaElemenDTO>();//dengan elemen
    }
}
