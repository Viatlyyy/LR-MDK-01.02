namespace DemoLib.Models
{
    public interface IAuthorization
    {
        User Authorize(string login);
    }
}
