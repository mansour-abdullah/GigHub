using GigHub.Core;
using GigHub.Core.Repositories;
using GigHub.Persistence.Repositories;

namespace GigHub.Persistence
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IGigRepository Gigs { get; private set; }
        public IAttendanceRepository Attendance { get; private set; }
        public IFollowingRepository Following { get; private set; }
        public IGenreRepository Genres { get;private  set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public INotificationRepository Notification { get; private set; }
        public IUserNotificationRepository UserNotification { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Gigs = new GigRepository(_context);
            Attendance = new AttendanceRepository(_context);
            Following = new FollowingRepository(_context);
            Genres = new GenreRepository(_context);
            ApplicationUser = new ApplicationUserRespository(_context);
            Notification = new NotificationRepository(_context);
            UserNotification = new UserNotificationRepository(_context);

        }
        public void Complete() { _context.SaveChanges(); }
    }
}