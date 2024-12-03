using Diplomski.Application.Dto.Creates;
using Diplomski.Application.Mail;
using Diplomski.Application.UseCases.Commands.User;
using Diplomski.DataAccess;
using Diplomski.Domain;
using Diplomski.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Diplomski.Implementation.UseCases.Commands.User
{
    public class EfCreateUserCommand : EfUseCase, ICreateUserCommand
    {
        private readonly RegisterUserDtoValidator _validator;
        private readonly IEmailService _emailService;

        public EfCreateUserCommand(DatabaseContext context, RegisterUserDtoValidator validator, IEmailService emailService) : base(context)
        {
            _validator = validator;
            _emailService = emailService;
        }

        public int Id => 28;

        public string Name => "Register User";

        public string Description => "Register User";

        public void Execute(RegisterUserDto data)
        {
            _validator.ValidateAndThrow(data);


            var user = new Diplomski.Domain.User
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(data.Password),
                Phone = data.Phone,
                Address = data.Address,
                City = data.City,
                Path = "default.jpg",

                RoleId = 3,
                Carts = new List<Cart>()
                {
                    new Cart()
                },
                
            };

            Context.Users.Add(user);
            Context.SaveChanges();

            try
            {
                var emailSubject = "Welcome to Gaming Store!";
                var emailBody = $"Dear {user.FirstName},\n\nThank you for registering with us.\n\nBest regards,\nGaming Store Team";
                _emailService.SendEmailAsync(user.Email, emailSubject, emailBody).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email: {ex.Message}");
            }



        }
    }
}
