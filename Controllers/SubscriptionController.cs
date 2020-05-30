using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newsletter.Infrastructure.API.Newsletter.Core.Application.Service;
using Newsletter.Infrastructure.API.Newsletter.Core.Domain.Model;
using Newsletter.Infrastructure.API.Newsletter.Infrastructure.DataAccess;

namespace Newsletter.Infrastructure.API.Controllers
{
    [Route("api/subscription")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly SubscriptionService _subscriptionService;
        http://localhost:63400/api/subscription/Subscribe

        public SubscriptionController(SubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpPost]
        public async Task<bool> Subscribe(Person person)
        {

            var verificationCode = new BaseEntity(new Guid());
            var subscription = new Subscription { Name = person.Name, Email = person.Email, VerificationCode = verificationCode.Id.ToString() };
            return await _subscriptionService.Subscribe(subscription);
        }

        [HttpPut]
        public async Task<bool> Verify(Verification verificationRequest)
        {
            var request = new Subscription { Email = verificationRequest.Email, VerificationCode  = verificationRequest.VerificationCode };
            return await _subscriptionService.Verify(request);
        }


        public async Task<Subscription> GetItems(Verification person)
        {
            var request = new Subscription { Email = person.Email };
            var repo = new SubscriptionRepository();
            return await repo.ReadByEmail(request.Email);
        }


    }
}