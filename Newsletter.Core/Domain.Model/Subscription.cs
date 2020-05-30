using System;

namespace Newsletter.Infrastructure.API.Newsletter.Core.Domain.Model
{
    public class Subscription : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string VerificationCode { get; set; }

        public Subscription(string name, string email, string verificationCode = null) : base()
        {
            Name = name;
            Email = email;
            VerificationCode = verificationCode ?? Guid.NewGuid().ToString();;
        }
    }
}