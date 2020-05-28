using System;
using System.Net.Mail;
using System.Threading.Tasks;
using Moq;
using Newsletter.Core.Application.Service;
using Newsletter.Core.Domain.Model;
using Newsletter.Core.Domain.Service;
using NUnit.Framework;

namespace Newsletter.UnitTest
{
    public class Tests
    {

        [Test]
        public async Task Test1()
        {
            var emailServiceMock = new Mock<IEmailService>();
            var subscriptionRepoMock = new Mock<ISubscriptionRepository>();
            var service = new SubscriptionService(emailServiceMock.Object, subscriptionRepoMock.Object);
            emailServiceMock.Setup(es => es.Send(It.IsAny<Email>()))
                             .ReturnsAsync(true);
            subscriptionRepoMock.Setup(sr => sr.Create(It.IsAny<Subscription>()))
                             .ReturnsAsync(true);

            var subscription = new Subscription("Stella", "stella@rosajente.com");
            await service.Subscribe(subscription);

            emailServiceMock.Verify(es => es.Send(It.Is<Email>
                                   (e => e.To == "stella@rosajente.com")));
            subscriptionRepoMock.Verify(sr => sr.Create(It.Is<Subscription>
                                       (s => s.Email == "stella@rosajente.com")));
        }

        [Test]
        public async Task TestVerifyOk()
        {

            var code = "985e8221 - ce7c - 4899 - 89c8 - 2e6427496203";
            var email = "stella@rosajente.com";
            var verificationRequest = new Subscription(null, email, code);
            var subscriptionFromDb = new Subscription(null, null, code);

            var subscriptionRepoMock = new Mock<ISubscriptionRepository>();
            subscriptionRepoMock.Setup(sr => sr.ReadByEmail(email))
                .ReturnsAsync(subscriptionFromDb);
            subscriptionRepoMock.Setup(sr => sr.Update(It.IsAny<Subscription>()))
                .ReturnsAsync(true);

            var service = new SubscriptionService(null, subscriptionRepoMock.Object);
            var isSuccess = await service.Verify(verificationRequest);
            Assert.IsTrue(isSuccess);

            subscriptionRepoMock.Verify(sr => sr.Update(It.IsAny<Subscription>()));
        }

        [Test]
        public async Task TestVerifyInvalidCode()
        {

            var code1 = "985e8221 - ce7c - 4899 - 89c8 - 2e6427496203";
            var code2 = "985e8221 - ce7c - 4899 - 89c8 - 2e6427496204";
            var email = "stella@rosajente.com";
            var verificationRequest = new Subscription(null, email, code1);
            var subscriptionFromDb = new Subscription(null, null, code2);

            var subscriptionRepoMock = new Mock<ISubscriptionRepository>();
            subscriptionRepoMock.Setup(sr => sr.ReadByEmail(email))
                .ReturnsAsync(subscriptionFromDb);

            var service = new SubscriptionService(null, subscriptionRepoMock.Object);
            var isSuccess = await service.Verify(verificationRequest);
            Assert.IsFalse(isSuccess);
            subscriptionRepoMock.Verify(sr => sr.ReadByEmail(email));
            subscriptionRepoMock.VerifyNoOtherCalls();

        }
    }
}
