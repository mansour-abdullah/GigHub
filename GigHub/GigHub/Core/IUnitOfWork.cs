using GigHub.Core.Repositories;

namespace GigHub.Core
{
    public interface IUnitOfWork
    {
        IGigRepository Gigs { get; }
        IAttendanceRepository Attendance { get; }
        IFollowingRepository Following { get; }
        IGenreRepository Genres { get; }
        IApplicationUserRepository ApplicationUser { get; }
        INotificationRepository Notification { get; }
        IUserNotificationRepository UserNotification { get; }
        void Complete();
    }
}
