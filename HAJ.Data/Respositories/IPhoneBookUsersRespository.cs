namespace HAJ.PhoneAPI.Domain
{
    public interface IPhoneBookUsersRespository
    {
        void CreateUser(PhoneBookUser user);

        void ReadUser(int id);

        void UpdateUser(PhoneBookUser user);

        void DeleteUser(PhoneBookUser user);
    }
}