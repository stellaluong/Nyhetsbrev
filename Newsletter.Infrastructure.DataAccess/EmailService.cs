using System.Threading.Tasks;
using Newsletter.Infrastructure.API.Newsletter.Core.Domain.Model;
using Newsletter.Infrastructure.API.Newsletter.Core.Domain.Service;

namespace Newsletter.Infrastructure.API.Newsletter.Infrastructure.DataAccess
{
    public class EmailService : IEmailService
    {
        public Task<bool> Send(Email email)
        {
            
            return Task.FromResult(true);
        }
    }
}
