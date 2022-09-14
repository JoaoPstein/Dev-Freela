using System.Diagnostics.CodeAnalysis;

namespace Dev.Freela.Core.Entities
{
    [ExcludeFromCodeCoverage]
    public abstract class BaseEntity
    {
        protected BaseEntity() { }

        public int Id { get; set; }
        public DateTime CreatedAt { get; protected set; }
    }
}
