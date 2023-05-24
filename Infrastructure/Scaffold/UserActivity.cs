// ---------------------------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by LinqToDB scaffolding tool (https://github.com/linq2db/linq2db).
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
// ---------------------------------------------------------------------------------------------------

using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591
#nullable enable

namespace MovieFiles.Infrastructure.Scaffold
{
	[Table("user_activities", IsView = true)]
	public class UserActivity
	{
		[Column("user_name"    , SkipOnInsert = true, SkipOnUpdate = true)] public string?   UserName     { get; set; } // character varying(255)
		[Column("user_id"      , SkipOnInsert = true, SkipOnUpdate = true)] public Guid?     UserId       { get; set; } // uuid
		[Column("activity_type", SkipOnInsert = true, SkipOnUpdate = true)] public string?   ActivityType { get; set; } // character varying(255)
		[Column("movie_id"     , SkipOnInsert = true, SkipOnUpdate = true)] public int?      MovieId      { get; set; } // integer
		[Column("rating_value" , SkipOnInsert = true, SkipOnUpdate = true)] public int?      RatingValue  { get; set; } // integer
		[Column("comment_text" , SkipOnInsert = true, SkipOnUpdate = true)] public string?   CommentText  { get; set; } // text
		[Column("timestamp"    , SkipOnInsert = true, SkipOnUpdate = true)] public DateTime? Timestamp    { get; set; } // timestamp (6) without time zone
	}
}
