using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFiles.Core.Models
{
    public class WatchLaterMovie
    {
        public Guid UserId {get;set;}
        public int MovieId {get;set;}
        public int ListId {get;set;}
        public string ListName = "WATCH_LATER";
    }
}