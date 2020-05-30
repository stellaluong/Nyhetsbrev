using System.Threading.Tasks;
using Newsletter.Infrastructure.API.Newsletter.Core.Domain.Model;
using Newsletter.Infrastructure.API.Newsletter.Core.Domain.Service;

namespace Newsletter.Infrastructure.API.Newsletter.Core.Application.Service
{
    public class SubscriptionService
    {
        private readonly IEmailService _emailService;
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionService(IEmailService emailService,
            ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _emailService = emailService;
        }


        public async Task<bool> Subscribe(Subscription request)
        {
           
            var subscription = new Subscription(request.Name, request.Email, request.VerificationCode);
            var isCreated = await _subscriptionRepository.Create(subscription);

            var text =
                $"<a href=\"http://localhost:63400/subscribe?email={request.Email}&code={subscription.VerificationCode}\"> Klikk på her for å bekrefte</a>";
            var email = new Email(
                request.Email,
                "Newsletter@stelli.com",
                "Bekreft abonnoment på nyhetsbrev",
                text
            );
            var isSent = await _emailService.Send(email);
            if (!isSent) return false;
            return true;
        }

        public async Task<bool> Verify(Subscription verificationRequest)
        {
            var subscription = await _subscriptionRepository.ReadByEmail(verificationRequest.Email);
            if (verificationRequest.VerificationCode != subscription.VerificationCode)
            {
                return false;
            }
            var hasUpdated = await _subscriptionRepository.Update(subscription);
            if (!hasUpdated)
                return false;
            return true;
        }

    }
}