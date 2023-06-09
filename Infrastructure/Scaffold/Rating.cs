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
	[Table("ratings")]
	public class Rating
	{
		[Column("user_id" , IsPrimaryKey = true, PrimaryKeyOrder = 0)] public Guid UserId  { get; set; } // uuid
		[Column("movie_id", IsPrimaryKey = true, PrimaryKeyOrder = 1)] public int  MovieId { get; set; } // integer
		[Column("rating"                                            )] public int  Rating1 { get; set; } // integer

		#region Associations
		/// <summary>
		/// ratings_user_id_fkey
		/// </summary>
		[Association(CanBeNull = false, ThisKey = nameof(UserId), OtherKey = nameof(User.UserId))]
		public User Useridfkey { get; set; } = null!;
		#endregion
	}
}
