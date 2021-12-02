using Microsoft.EntityFrameworkCore;
using Solid_S.Data;
using Solid_S.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Solid_S
{
    // Principios SOLID
    // SOLID tiene bastante relación con los patrones de diseño.


    // Single responsibility,       - responsabilidad única: establece que una clase, componente o microservicio debe ser responsable de una sola
    //                                cosa (el tan aclamado término “decoupled” en inglés). 
    // Open-closed                  
    // Liskov substitution
    // Interface segregation
    // Dependency inversion.

    // S: Single Responsibility Principle(SRP)
    // SRP says "Every software module should have only one reason to change".
    // This means that every class, or similar structure, in your code should have only one job to do.

    class Otro
    {

    }

    //--------------------------------------------------------------------------------------------------------
    // antes de usar principio 1
    public class UserServiceIni
    {
        SmtpClient _smtpClient;
        public void Register(string email, string password)
        {
            if (!ValidateEmail(email))
                throw new ValidationException("Email in not an email");


            var user = new User(email, password);
            //_dbContext.Users.Add(user);
            //_dbContext.SaveChanges();

            SendEmail(new MailMessage("algo@gm.com", email) { Subject = "Asunto" });
        }

        public virtual bool ValidateEmail(string email)
        {
            return email.Contains("@");
        }
        public bool SendEmail(MailMessage message)
        {
            _smtpClient.Send(message);
            return true;
        }
    }
    //--------------------------------------------------------------------------------------------------------




    //--------------------------------------------------------------------------------------------------------
    // Acá aplicamos el principio 1: Single Responsability
    public class UserService
    {
        EmailService _emailService;
        ApplicationDbContext _dbContext;

        public UserService(EmailService emailService, ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
            this._emailService = emailService;
        }

        public void Register(string email, string password)
        {
            if (!_emailService.ValidateEmail(email))
                throw new ValidationException("Email is not an email");

            var user = new User(email, password);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            _emailService.SendEmail(new MailMessage("correo@mail.com", email) { Subject = "Hola !!" });
        }

    }

    public class EmailService
    {
        SmtpClient _smtpClient;

        public EmailService(SmtpClient smtpClient)
        {
            this._smtpClient = smtpClient;
        }

        public virtual bool ValidateEmail(string email)
        {
            return email.Contains("@");
        }

        public bool SendEmail(MailMessage message)
        {
            _smtpClient.Send(message);

            return true;
        }
    }
    //--------------------------------------------------------------------------------------------------------
}
