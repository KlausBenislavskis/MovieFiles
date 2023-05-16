namespace MovieFiles.Core.Interfaces
{
    public interface IUserRepository
    {
        Task ResolveUser(Guid userId, string username);

    }
}
