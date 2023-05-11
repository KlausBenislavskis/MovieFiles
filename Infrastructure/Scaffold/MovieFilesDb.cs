// ---------------------------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by LinqToDB scaffolding tool (https://github.com/linq2db/linq2db).
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
// ---------------------------------------------------------------------------------------------------

using LinqToDB;
using LinqToDB.Data;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable 1573, 1591
#nullable enable

namespace MovieFiles.Infrastructure.Scaffold
{
	public partial class MovieFilesDb : DataConnection
	{
		public MovieFilesDb()
		{
			InitDataContext();
		}

		public MovieFilesDb(string configuration)
			: base(configuration)
		{
			InitDataContext();
		}

		public MovieFilesDb(DataOptions<MovieFilesDb> options)
			: base(options.Options)
		{
			InitDataContext();
		}

		partial void InitDataContext();

		public ITable<Comment>   Comments   => this.GetTable<Comment>();
		public ITable<Follower>  Followers  => this.GetTable<Follower>();
		public ITable<MovieList> MovieLists => this.GetTable<MovieList>();
		public ITable<Rating>    Ratings    => this.GetTable<Rating>();
	}

	public static partial class ExtensionMethods
	{
		#region Table Extensions
		public static Comment? Find(this ITable<Comment> table, int commentId)
		{
			return table.FirstOrDefault(e => e.CommentId == commentId);
		}

		public static Task<Comment?> FindAsync(this ITable<Comment> table, int commentId, CancellationToken cancellationToken = default)
		{
			return table.FirstOrDefaultAsync(e => e.CommentId == commentId, cancellationToken);
		}

		public static Follower? Find(this ITable<Follower> table, Guid userId, Guid followsUserId)
		{
			return table.FirstOrDefault(e => e.UserId == userId && e.FollowsUserId == followsUserId);
		}

		public static Task<Follower?> FindAsync(this ITable<Follower> table, Guid userId, Guid followsUserId, CancellationToken cancellationToken = default)
		{
			return table.FirstOrDefaultAsync(e => e.UserId == userId && e.FollowsUserId == followsUserId, cancellationToken);
		}

		public static MovieList? Find(this ITable<MovieList> table, int listId)
		{
			return table.FirstOrDefault(e => e.ListId == listId);
		}

		public static Task<MovieList?> FindAsync(this ITable<MovieList> table, int listId, CancellationToken cancellationToken = default)
		{
			return table.FirstOrDefaultAsync(e => e.ListId == listId, cancellationToken);
		}

		public static Rating? Find(this ITable<Rating> table, Guid userId, Guid movieId)
		{
			return table.FirstOrDefault(e => e.UserId == userId && e.MovieId == movieId);
		}

		public static Task<Rating?> FindAsync(this ITable<Rating> table, Guid userId, Guid movieId, CancellationToken cancellationToken = default)
		{
			return table.FirstOrDefaultAsync(e => e.UserId == userId && e.MovieId == movieId, cancellationToken);
		}
		#endregion
	}
}