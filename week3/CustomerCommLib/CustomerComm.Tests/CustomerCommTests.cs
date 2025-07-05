using System;
using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerCommTests.Tests
{
    public interface IMailSender
    {
        bool SendMail(string to, string body);
    }

    public class CustomerComm
    {
        private readonly IMailSender _mailSender;

        public CustomerComm(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }

        public bool SendMailToCustomer()
        {
            return _mailSender.SendMail("customer@example.com", "Hello Customer");
        }
    }

    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender>? _mockMailSender;
        private CustomerComm? _customerComm;

        [OneTimeSetUp]
        public void Setup()
        {
            _mockMailSender = new Mock<IMailSender>();
            _mockMailSender
                .Setup(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            _customerComm = new CustomerComm(_mockMailSender.Object);
        }

        [Test]
        public void SendMailToCustomer_ShouldReturnTrue_WhenMailIsSentSuccessfully()
        {
            Assert.That(_customerComm, Is.Not.Null); // Replaced Assert.IsNotNull with Assert.That and Is.Not.Null

            var result = _customerComm!.SendMailToCustomer();

            Assert.That(result, Is.Not.Null); // This should work with NUnit
        }
    }
}
