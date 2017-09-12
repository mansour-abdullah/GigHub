using GigHub.Core;
using GigHub.Core.DTOs;
using GigHub.Core.Models;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace GigHub.Controllers.Api
{

    [Authorize]
    public class AttendancesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public AttendancesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            var attendance = _unitOfWork.Attendance.GetAttendance(dto.GigId, userId);
             

            if (attendance != null)
                return BadRequest("The attendace already exists.");

             attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };

            _unitOfWork.Attendance.Add(attendance);
            _unitOfWork.Complete();
            return Ok();

        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var userId = User.Identity.GetUserId();
            var attendance = _unitOfWork.Attendance.GetAttendance(id, userId);
            if (attendance == null)
                return NotFound();
            _unitOfWork.Attendance.Remove(attendance);
            _unitOfWork.Complete();
            return Ok(id);

        }
    }
}
