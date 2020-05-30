using System.Threading.Tasks;
using Newsletter.Infrastructure.API.Newsletter.Core.Domain.Model;

namespace Newsletter.Infrastructure.API.Newsletter.Core.Domain.Service
{
    public interface IEmailService
    {
        Task<bool> Send(Email email);
    }
}
