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
	[Table("movie_lists")]
	public class MovieList
	{
		[Column("user_id"                                                                                     )] public Guid   UserId   { get; set; } // uuid
		[Column("list_id"  , IsPrimaryKey = true , IsIdentity = true, SkipOnInsert = true, SkipOnUpdate = true)] public int    ListId   { get; set; } // integer
		[Column("list_name", CanBeNull    = false                                                             )] public string ListName { get; set; } = null!; // character varying(255)
		[Column("movie_id"                                                                                    )] public int    MovieId  { get; set; } // integer
	}
}
