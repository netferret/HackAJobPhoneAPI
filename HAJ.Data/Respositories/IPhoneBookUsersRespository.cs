namespace HAJ.PhoneAPI.Domain
{
    public interface IPhoneBookUsersRespository
    {
        PhoneBookUser CreateUser(PhoneBookUser user);

        PhoneBookUser ReadUser(int id);

        bool UpdateUser(int uid, PhoneBookUser user);

        bool DeleteUser(int id);
    }
}