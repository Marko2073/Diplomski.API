
using Diplomski.Application.Dto.Creates;
using Diplomski.Application.UseCases.Commands.Pictures;
using Diplomski.DataAccess;
using Diplomski.Domain;
using Diplomski.Implementation.UseCases;
using Diplomski.Implementation.Validators;
using FluentValidation;

public class EfCreatePictureCommand : EfUseCase, ICreatePictureCommand
{
    private readonly CreatePictureDtoValidator _validator;
    public EfCreatePictureCommand(DatabaseContext context, CreatePictureDtoValidator validator) : base(context)
    {
        _validator = validator;
    }

    public int Id => 38;

    public string Name => "Upload picture";

    public string Description => "Picture upload";

    public void Execute(CreatePictureDto request)
    {
        _validator.ValidateAndThrow(request);

        if (request.PicturePath != null)
        {
            var extension = Path.GetExtension(request.PicturePath.FileName);
            var filename = Guid.NewGuid().ToString() + extension;
            var savepath = Path.Combine("wwwroot", "images", filename);

            Directory.CreateDirectory(Path.GetDirectoryName(savepath));

            using (var fs = new FileStream(savepath, FileMode.Create))
            {
                request.PicturePath.CopyTo(fs);
            }


            var picture = new Picture
            {
                Path = filename,
                ModelVersionId = request.ModelVersionId
            };

            Context.Pictures.Add(picture);
            Context.SaveChanges();


            
        }
    }

    
}

