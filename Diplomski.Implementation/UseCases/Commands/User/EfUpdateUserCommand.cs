using AspProjekat2024.Implementation.Validators;
using Diplomski.Application.Dto.Updates;
using Diplomski.Application.Exceptions;
using Diplomski.Application.UseCases.Commands.User;
using Diplomski.DataAccess;
using Diplomski.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.Implementation.UseCases.Commands.User
{
    public class EfUpdateUserCommand : EfUseCase, IUpdateUserCommand
    {
        private readonly UpdateUserDtoValidator _validator;

        public EfUpdateUserCommand(DatabaseContext context, UpdateUserDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 29;

        public string Name => "Update User";

        public string Description => "Update User";

        public void Execute(UpdateUserDto request)
        {
            _validator.ValidateAndThrow(request);

            var user = Context.Users.Find(request.Id);
            if (user == null)
            {
                throw new EntityNotFoundException(nameof(Domain.User), request.Id);
            }

            if (request.Path != null)
            {
                var extension = Path.GetExtension(request.Path.FileName);
                var filename = Guid.NewGuid().ToString() + extension;
                var savepath = Path.Combine("wwwroot", "images", filename);

                Directory.CreateDirectory(Path.GetDirectoryName(savepath));

                using (var fs = new FileStream(savepath, FileMode.Create))
                {
                    request.Path.CopyTo(fs);
                }

                

                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.Email = request.Email;
                user.Phone = request.Phone;
                user.Address = request.Address;
                user.City = request.City;
                user.Path =  filename;
                user.RoleId = request.RoleId;
            }
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Phone = request.Phone;
            user.Address = request.Address;
            user.City = request.City;
            user.RoleId = request.RoleId;


            Context.SaveChanges();

        }
    }
}
