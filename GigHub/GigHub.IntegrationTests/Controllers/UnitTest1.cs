using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using GigHub.Controllers;
using GigHub.Persistence;
using GigHub.IntegrationTests.Extensions;
using System.Linq;
using GigHub.Core.Models;
using System.Collections.Generic;
using FluentAssertions;

namespace GigHub.IntegrationTests.Controllers
{
    [TestFixture]
    public class GigsControllerTests
    {
        private GigsController _controller;
        private ApplicationDbContext _context = new ApplicationDbContext();

        


        [SetUp]
        public void SetUp()
        {
            _controller = new GigsController(new UnitOfWork(_context));
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test, Isolated]
        public void Mine_WhenCalled_ShouldReturnUpcomingGigs()
        {
            //arrange
            var user = _context.Users.First();
            _controller.MockCurrentUser(user.Id , user.UserName);

            var genre = _context.Genres.First();
            var gig = new Gig { Artist = user, DateTime = DateTime.Now.AddDays(1), Genre = genre, Venue = "-" };
            _context.Gigs.Add(gig);
            _context.SaveChanges();
 
            //act
            var result = _controller.Mine();

            //asserion
            (result.ViewData.Model as IEnumerable<Gig>).Should().HaveCount(1);
        }

        [Test, Isolated]
        public void Update_WhenCalled_ShouldUpdateTheGivenGig()
        {
            //arrange
            var user = _context.Users.First();
            _controller.MockCurrentUser(user.Id, user.UserName);

            var genre = _context.Genres.Single(g=>g.Id ==1);
            var gig = new Gig { Artist = user, DateTime = DateTime.Now.AddDays(1), Genre = genre, Venue = "-" };
            _context.Gigs.Add(gig);
            _context.SaveChanges();

            //act
            var result = _controller.Update(new Core.ViewModels.GigFormViewModel
            {
                Id=gig.Id,
                Date = DateTime.Today.AddMonths(1).ToString("d MMM yyy") ,
                Time ="20:00",
                Venue ="Venue",
                Genre = 2 
            });
            
            //asserion
           
            _context.Entry(gig).Reload();
            gig.DateTime.Should().Be(DateTime.Today.AddMonths(1).AddHours(20));
            gig.Venue.Should().Be("Venue");
            gig.GenreId.Should().Be(2);
        }
        [Test, Isolated]
        public void Cancel_WhenCalled_ShouldCancelTheGivenGig()
        {
            //arrange
            var user = _context.Users.First();
            _controller.MockCurrentUser(user.Id, user.UserName);

            var genre = _context.Genres.Single(g => g.Id == 1);
            var gig = new Gig { Artist = user, DateTime = DateTime.Now.AddDays(1), Genre = genre, Venue = "-"};
            _context.Gigs.Add(gig);
            _context.SaveChanges();

            //act

            gig.Cancel();

            //asserion
             
            gig.isCanceled.Should().Be(true);
        }
    }
}
