using GGigHub.Core.DTOs;
using GigHub.Core;
using GigHub.Core.Models;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private IUnitOfWork _unitOfWork;
        public FollowingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
     
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto) {
            var userId = User.Identity.GetUserId();
            var following = _unitOfWork.Following.GetFollowing(userId, dto.FolloweeId);
            if (following != null)
                return BadRequest("Follwing already Exists");

             following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };
            _unitOfWork.Following.Add(following);
            _unitOfWork.Complete();
            return Ok();

        }

        [HttpDelete]
        public IHttpActionResult unFollow(string id)
        {
            var userId = User.Identity.GetUserId();
            var follower = _unitOfWork.Following.GetFollowing(User.Identity.GetUserId(), id);
               // _context.Followings.Single(f =>  f.FollowerId == userId && f.FolloweeId == id);
            if (follower == null)
                return NotFound();
            _unitOfWork.Following.Remove(follower);
            _unitOfWork.Complete();
            return Ok(id);


        }
    }
}
