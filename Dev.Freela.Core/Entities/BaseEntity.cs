namespace Dev.Freela.Core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity() { }

        public int Id { get; set; }
        public DateTime CreatedAt { get; protected set; }
    }
}
