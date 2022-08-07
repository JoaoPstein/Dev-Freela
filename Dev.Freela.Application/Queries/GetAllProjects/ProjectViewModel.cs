namespace Dev.Freela.Application.Queries.GetAllProjects
{
    public class ProjectViewModel
    {
        public ProjectViewModel(int id, string title, DateTime createdAt)
        {
            Id = id;
            Title = title;
            CreatedAt = createdAt;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
