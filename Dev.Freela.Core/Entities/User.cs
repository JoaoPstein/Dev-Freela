namespace Dev.Freela.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string email, DateTime birthdate, string password, string role)
        {
            Name = name;
            Email = email;
            Birthdate = birthdate;
            Password = password;
            Role = role;
            CreatedAt = DateTime.Now;
            Active = true;

            Skills = new List<Skill>();
            OwnedProjects = new List<Project>();
            FreelanceProjects = new List<Project>();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime Birthdate { get; private set; }
        public bool Active { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public List<Skill> Skills { get; private set; }
        public List<Project> OwnedProjects { get; private set; }
        public List<Project> FreelanceProjects { get; private set; }
        public List<ProjectComment> Comments { get; private set; }
    }
}
