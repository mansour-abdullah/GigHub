using GigHub.Core;
using GigHub.Core.DTOs;
using GigHub.Core.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebGrease.Css.Extensions;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private IUnitOfWork _unitOfWork;
        public NotificationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<NotificationDto> GetNewNotification()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _unitOfWork.Notification.GetNewNotificationsFor(userId);
                
          
            return notifications.Select(AutoMapper.Mapper.Map<Notification,NotificationDto>);
      
        }
        [HttpPost]
        public IHttpActionResult MarkAsRead() {
            var userId = User.Identity.GetUserId();
            var notifications = _unitOfWork.UserNotification.GetUserNotificationsFor(userId);
                 
            notifications.ForEach(n => n.Read());
            _unitOfWork.Complete();


            return Ok();
        }
    }
}
