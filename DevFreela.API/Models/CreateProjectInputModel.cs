namespace DevFreela.API.Models
{
    public class CreateProjectInputModel
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ClientId { get; set; }
        public int FreelancerId { get; set; }
    }
}
