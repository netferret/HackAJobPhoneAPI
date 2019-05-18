using HAJ.PhoneAPI.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HAJ.PhoneAPI.Domain
{
    public class PhoneBookUsersRepository : IPhoneBookUsersRespository
    {

        private readonly PhoneContext _context;

        public void CreateUser(PhoneBookUser user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(PhoneBookUser user)
        {
            throw new NotImplementedException();
        }

        public void ReadUser(int id)
        {
            throw new NotImplementedException();
        }

        public void Test() {

            _context.PhoneBookUsers
        }

        public void UpdateUser(PhoneBookUser user)
        {
            throw new NotImplementedException();
        }
    }
}
