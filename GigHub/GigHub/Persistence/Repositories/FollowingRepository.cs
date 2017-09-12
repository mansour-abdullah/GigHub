﻿using GigHub.Core.Models;
using GigHub.Core.Repositories;
using System.Linq;

namespace GigHub.Persistence.Repositories
{

    public class FollowingRepository : IFollowingRepository
    {
        private readonly ApplicationDbContext _context;
        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Following GetFollowing(string FollowerId, string FolloweeId)
        {
            return _context.Followings.SingleOrDefault(f => f.FolloweeId == FolloweeId && f.FollowerId == FollowerId);
        }
        public void Add(Following following)
        {
            _context.Followings.Add(following);
        }

        public void Remove(Following following)
        {
            _context.Followings.Remove(following);
        }
    
    }
}