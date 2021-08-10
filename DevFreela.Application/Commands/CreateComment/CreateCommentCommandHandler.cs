using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        //refactoring for pattern Repository
        private readonly IProjectRepository _projectRepository;
        public CreateCommentCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(request.Content, request.IdUser, request.IdProject);

            await _projectRepository.AddCommentAsync(comment);

            return Unit.Value;
        }
    }
}
