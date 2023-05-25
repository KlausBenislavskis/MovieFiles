namespace MovieFiles.Api.Client.Mappers
{
    internal class UiToClient
    {
        internal static Rating Map(Core.Models.Rating rating)
        {
            return new()
            {
                MovieId = rating.MovieId,
                UserId = rating.UserId,
                RatingValue = rating.RatingValue
            };
        }

        internal static Comment Map(Core.Models.Comment comment)
        {
            return new()
            {
                Author = comment.Author,
                Text = comment.Text,
            };
        }

        internal static MovieListType2 Map2(Core.Models.MyMovieListItem.ListType listType){
            int type = (int)listType;
            return (MovieListType2)type;
        }
        internal static MovieListType Map(Core.Models.MyMovieListItem.ListType listType){
            int type = (int)listType;
            return (MovieListType)type;
        }
        internal static MovieListType3 Map3(Core.Models.MyMovieListItem.ListType listType){
            int type = (int)listType;
            return (MovieListType3)type;
        }
    }
}
