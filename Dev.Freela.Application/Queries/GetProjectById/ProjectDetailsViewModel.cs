namespace Dev.Freela.Application.Queries.GetProjectById
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(int id, string title, string description,
            decimal totalCost, DateTime? startedAt, DateTime? finishedAt,
            string clientName, string freelancerName)
        {
            Id = id;
            Title = title;
            Description = description;
            ClientName = clientName;
            FreelancerName = freelancerName;
            TotalCost = totalCost;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ClientName { get; set; }
        public string FreelancerName { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }

    }
}
