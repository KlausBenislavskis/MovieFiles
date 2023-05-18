using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieFiles.Core.Models
{
    public class WatchLaterMovie
    {
        public static readonly string WATCH_LATER_LIST_NAME = "WATCH_LATER";
        public Guid UserId {get;set;}
        public int MovieId {get;set;}
        public int ListId {get;set;}
        public readonly string ListName = WatchLaterMovie.WATCH_LATER_LIST_NAME;
    }
}