using HAJ.PhoneAPI.Entities;

namespace HAJ.PhoneAPI.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}