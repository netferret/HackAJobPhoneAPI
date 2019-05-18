namespace HAJ.PhoneAPI.Domain
{
    public interface IPhoneBookUsersRespository
    {
        bool CreateUser(PhoneBookUser user);

        PhoneBookUser ReadUser(int id);

        bool UpdateUser(PhoneBookUser user, int uid);

        bool DeleteUser(int id);
    }
}