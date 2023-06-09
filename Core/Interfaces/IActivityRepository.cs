﻿using MovieFiles.Core.Models;

namespace MovieFiles.Core.Interfaces
{
    public interface IActivityRepository
    {
        public Task AddActivity(BaseActivity baseActivity);
        public Task<List<BaseActivity>> GetActivities(Guid userId, int page = 1, int pageSize = 25);
    }
}
