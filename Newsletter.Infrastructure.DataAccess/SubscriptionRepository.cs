using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newsletter.Core.Domain.Model;
using Newsletter.Core.Domain.Service;

namespace Newsletter.Infrastructure.DataAccess
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        public Task<bool> Create(Subscription subscription)
        {
            return Task.FromResult(true);
        }

        public Task<Subscription> ReadByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Subscription subscription)
        {
            throw new NotImplementedException();
        }
    }
}
