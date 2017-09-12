﻿using System;

namespace GigHub.Core.DTOs
{
    public class GigDto
    {
        public int Id { get; set; }
        public bool isCanceled { get; set; }
        public UserDto Artist { get; set; }
        public DateTime DateTime { get; set; }
        public string Venue { get; set; }
        public GenreDto Genre { get; set; }
    }  
}