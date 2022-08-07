namespace Dev.Freela.Core.Entities
{
    public class Skill : BaseEntity
    {
        public Skill(string description)
        {
            Description = description;
            CreatedAt = DateTime.Now;
        }

        public string Description { get; set; }
        public int IdSkill { get; set; }
    }
}
