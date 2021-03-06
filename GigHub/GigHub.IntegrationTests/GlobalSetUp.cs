﻿using NUnit.Framework;
using GigHub;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using GigHub.Persistence;
using GigHub.Core.Models;

namespace GigHub.IntegrationTests
{
    [SetUpFixture]
    class GlobalSetUp
    {
      [OneTimeSetUp]
        public void SetUp()
        {
            MigrateDbToLatestVersion();
            Seed();
        }
        public static void MigrateDbToLatestVersion()
        {
            var configuration = new GigHub.Migrations.Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();
        }
        public void Seed()
        {
            var context = new ApplicationDbContext();
            if (context.Users.Any())
                return;
            
            context.Users.Add(new ApplicationUser { UserName = "user1", Name = "user1", Email = "-", PasswordHash = "-" });
            context.Users.Add(new ApplicationUser { UserName = "user2", Name = "user2", Email = "-", PasswordHash = "-" });
            context.SaveChanges();
        }
    }
}
