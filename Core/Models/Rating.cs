﻿namespace MovieFiles.Core.Models
{
    public class Rating
    {
        public Guid UserId { get; set; }
        public int MovieId { get; set; }
        public int RatingValue { get; set; }
    }
}
