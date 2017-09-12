﻿using GigHub.Core.Models;
using System.Data.Entity;

namespace GigHub.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Gig> Gigs { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Attendance> Attendances { get; set; }
        DbSet<Following> Followings { get; set; }
        DbSet<Notification> Notification { get; set; }
        DbSet<UserNotification> UserNotifications { get; set; }
        IDbSet<ApplicationUser> Users { get; set; }
    }
}
