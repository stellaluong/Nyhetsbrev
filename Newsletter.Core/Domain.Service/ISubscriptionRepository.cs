using System.Threading.Tasks;
using Newsletter.Infrastructure.API.Newsletter.Core.Domain.Model;

namespace Newsletter.Infrastructure.API.Newsletter.Core.Domain.Service
{
    public interface ISubscriptionRepository
    {
        Task<bool> Create(Subscription subscription);
        Task<Subscription> ReadByEmail(string email);
        Task<bool> Update(Subscription subscription);
    }
}
