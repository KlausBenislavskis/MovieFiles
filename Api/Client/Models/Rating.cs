﻿namespace MovieFiles.Api.Client.Models
{
    public class Rating
    {
        public Guid UserId { get; set; }
        public Guid MovieId { get; set; }
        public int RatingValue { get; set; }
    }
}
