namespace Pes.Core
{
    public interface IUserSession
    {
        bool LoggedIn { get; set; }
        string Username { get; set; }
        Pes.Core.Account CurrentUser { get; set; }
    }
}