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
                Path = "default.png",
                RoleId = 3,
            };

            Context.Users.Add(user);
            Context.SaveChanges();

            try
            {
                var emailSubject = "Welcome to Gaming Store!";
                var emailBody = GenerateWelcomeEmail(user.FirstName);
                _emailService.SendEmailAsync(user.Email, emailSubject, emailBody).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email: {ex.Message}");
            }
        }
        private string GenerateWelcomeEmail(string firstName)
        {
            return $@"
                        <!DOCTYPE html>
                        <html lang='en'>
                        <head>
                            <meta charset='UTF-8'>
                            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                            <title>Welcome to Gaming Store!</title>
                            <style>
                                body {{ background-color: #f4f4f4; color: #333; font-family: Arial, sans-serif; padding: 20px; }}
                                .container {{ max-width: 600px; margin: 0 auto; background-color: #ffffff; padding: 20px; border-radius: 8px; box-shadow: 0 0 10px rgba(0,0,0,0.1); }}
                                .header {{ background-color: #e0e0e0; padding: 20px; border-radius: 8px 8px 0 0; text-align: center; }}
                                .header h1 {{ margin: 0; font-size: 24px; }}
                                .content {{ padding: 20px; text-align: center; }}
                                .content p {{ font-size: 16px; line-height: 1.5; }}
                                .footer {{ text-align: center; font-size: 12px; color: #888; margin-top: 20px; }}
                            </style>
                        </head>
                        <body>
                            <div class='container'>
                                <div class='header'>
                                    <h1>Welcome to Gaming Store!</h1>
                                </div>
                                <div class='content'>
                                    <p>Hi {firstName},</p>
                                    <p>Thank you for registering with us. We're excited to have you with us!</p>
                                    <p>Feel free to explore and let us know if you have any questions. We're here to help!</p>
                                    <p>Best regards,<br>Gaming Store Team</p>
                                </div>
                                <div class='footer'>
                                    <p>&copy; 2025 Gaming Store. All rights reserved.</p>
                                </div>
                            </div>
                        </body>
                        </html>";
        }
    }
}
