using DevFreela.Application.Commands.UpdateProject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Validators
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome do projeto é obrigatório!");

            RuleFor(p => p.Title)
                .MaximumLength(30)
                .WithMessage("Tamanhp máximo de Nome é 30 caracteres!");

            RuleFor(p => p.Description)
                .MaximumLength(255)
                .WithMessage("Tamanhp máximo de Descrição é 255 caracteres!");
        }
    }
}
