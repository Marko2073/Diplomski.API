using Diplomski.Application.Dto.Creates;
using Diplomski.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.Validators
{
    public class CreateModelVersionSpecificationDtoValidator : AbstractValidator<CreateModelVersionSpecificationDto>
    {
        public CreateModelVersionSpecificationDtoValidator(DatabaseContext context)
        {
            RuleFor(x => x.ModelVersionId)
                .NotEmpty()
                .Must(x => context.ModelVersions.Any(mv => mv.Id == x))
                .WithMessage("Model version with an id of {PropertyValue} doesn't exist.");

            RuleFor(x => x.SpecificationId)
                .NotEmpty()
                .Must(x => context.Specifications.Any(s => s.Id == x))
                .WithMessage("Specification with an id of {PropertyValue} doesn't exist.");

            RuleFor(x => new { x.ModelVersionId, x.SpecificationId })
                .Must(x => !context.ModelVersionSpecifications.Any(mvs => mvs.ModelVersionId == x.ModelVersionId && mvs.SpecificationId == x.SpecificationId))
                .WithMessage("Model version specification already exists.");


            RuleFor(x => new { x.ModelVersionId, x.SpecificationId })
                .Must(x =>
                {
                    // Dohvatamo ModelVersion i njegov Model
                    var modelVersion = context.ModelVersions
                        .Where(mv => mv.Id == x.ModelVersionId)
                        .Select(mv => new { mv.Id, Model = mv.Model })
                        .FirstOrDefault();

                    if (modelVersion == null || modelVersion.Model == null)
                    {
                        return false; // Ako ModelVersion ili Model ne postoje, validacija ne prolazi
                    }

                    // Dohvatamo CategoryId za model
                    var categoryId = modelVersion.Model.CategoryId;

                    // Proveravamo da li je specifikacija "child" neke parent specifikacije u CategorySpecifications
                    var isChildOfAllowedParent = context.CategorySpecifications
                        .Where(cs => cs.CategoryId == categoryId)
                        .Select(cs => cs.SpecificationId) // Dohvatamo sve parent specifikacije dozvoljene za kategoriju
                        .Any(parentId => context.Specifications.Any(s => s.Id == x.SpecificationId && s.ParentId == parentId));

                    return isChildOfAllowedParent;
                })
                .WithMessage("The specification is not a child of any allowed parent specification for the given category.");


        }
    }
}
