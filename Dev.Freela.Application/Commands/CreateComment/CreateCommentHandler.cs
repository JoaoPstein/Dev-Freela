using Dev.Freela.Core.Entities;
using Dev.Freela.Core.Repositories;
using MediatR;

namespace Dev.Freela.Application.Commands.CreateComment
{
    internal class CreateCommentHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly IProjectCommentRepository _projectComment;
        public CreateCommentHandler(IProjectCommentRepository projectComment)
        {
            _projectComment = projectComment;
        }

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);

            await _projectComment.CreateComment(comment);

            return Unit.Value;
        }
    }
}
