using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newsletter.Core.Domain.Model;
using Newsletter.Core.Domain.Service;

namespace Newsletter.Infrastructure.DataAccess
{
   public class EmailService : IEmailService
    {
        public Task<bool> Send(Email email)
        {
            return Task.FromResult(true);
        }
    }
}
