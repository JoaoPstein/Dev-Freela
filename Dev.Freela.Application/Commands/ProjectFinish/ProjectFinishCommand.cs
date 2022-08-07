using MediatR;

namespace Dev.Freela.Application.Commands.ProjectFinish
{
    public class ProjectFinishCommand : IRequest<Unit>
    {
        public int Id { get; private set; }

        public ProjectFinishCommand(int id)
        {
            Id = id;
        }
    }
}
