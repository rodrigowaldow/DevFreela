using DevFreela.Application.Commands.CreateComment;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateCommentComandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentComandValidator()
        {
            RuleFor(p => p.Content)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo de Texto de Comentário é de 255 caracteres.");
        }
    }
}
