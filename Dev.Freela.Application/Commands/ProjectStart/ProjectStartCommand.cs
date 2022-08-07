using MediatR;

namespace Dev.Freela.Application.Commands.ProjectStart
{
    public class ProjectStartCommand : IRequest<Unit>
    {
        public int Id { get; private set; }

        public ProjectStartCommand(int id)
        {
            Id = id;
        }
    }
}
