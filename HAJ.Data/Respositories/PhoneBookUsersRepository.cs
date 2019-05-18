using HAJ.PhoneAPI.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HAJ.PhoneAPI.Domain
{
    public class PhoneBookUsersRepository : IPhoneBookUsersRespository
    {

        private readonly PhoneContext _context;

        public bool CreateUser(PhoneBookUser user)
        {
            var result = _context.Add(user);
            _context.SaveChangesAsync();

            if (result != null) {
                return true;
            }

            return false;
        }


        public bool DeleteUser(int id) => _context.PhoneBookUsers.Where(x => x.Id == id).FirstOrDefault() != null;

        public bool DeleteUser(PhoneBookUser user)
        {
            throw new NotImplementedException();
        }

        public PhoneBookUser ReadUser(int id) => _context.PhoneBookUsers.Where(x => x.Id == id).FirstOrDefault();

        public bool UpdateUser(PhoneBookUser user, int id)
        {
            var existingPhoneBookUser = _context.PhoneBookUsers.Where(x => x.Id == id).FirstOrDefault();

            if (existingPhoneBookUser != null)
            {
                existingPhoneBookUser = user;

                _context.PhoneBookUsers.Update(existingPhoneBookUser);
                _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

    }
}
