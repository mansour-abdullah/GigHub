using FluentAssertions;
using GigHub.Core.Models;
using GigHub.Persistence;
using GigHub.Persistence.Repositories;
using GigHub.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using System.Linq;

namespace GigHub.Tests.Presistence.Repositories
{
    [TestClass]
    public class NotificationRepsitoryTests
    {
        private NotificationRepository _repository;
        private Mock<DbSet<UserNotification>> _mockNotification;
      
        [TestInitialize]
        public void TestInitialize()
        {
            _mockNotification = new Mock<DbSet<UserNotification>>();
       
            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.SetupGet(c => c.UserNotifications).Returns(_mockNotification.Object);
            _repository = new NotificationRepository(mockContext.Object);
        }

        [TestMethod]
        public void GetNewNotificationsFor_NotificationForADifferentUser_ShouldNotBeReturned()
        {
            var notification = Notification.GigCanceled(new Gig());
            var user = new ApplicationUser() { };
            var userNotification = new UserNotification(user, notification);
            _mockNotification.SetSource(new[] { userNotification });
            //var notifications = _repository.GetNewNotificationsFor(User.getUserid);
            notifications.Should().HaveCount(1);
            notifications.First().Should().Be(notification);
        }
    }
}
