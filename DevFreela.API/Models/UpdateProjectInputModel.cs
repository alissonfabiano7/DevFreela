namespace DevFreela.API.Models
{
    public class UpdateProjectInputModel
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public decimal TotalCost { get; set; }
        public int IdUser { get; set; }
        public int IdFreelancer { get; set; }
    }
}
