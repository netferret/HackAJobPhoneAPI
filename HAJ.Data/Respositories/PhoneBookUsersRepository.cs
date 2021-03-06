﻿using HAJ.PhoneAPI.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HAJ.PhoneAPI.Domain
{
    public class PhoneBookUsersRepository : IPhoneBookUsersRespository
    {
        private readonly PhoneContext _context;

        public PhoneBookUsersRepository(PhoneContext context)
        {
            _context = context;
        }

        public PhoneBookUser CreateUser(PhoneBookUser user)
        {
            var result = _context.Add(user);
            _context.SaveChanges();
            
            if (result != null)
            {
                return user;
            }

            return null;
        }

        public bool DeleteUser(int id)
        {
            var phoneBookUser = _context.PhoneBookUsers.Where(x => x.Id == id).FirstOrDefault();

            if (phoneBookUser != null)
            {
                _context.Remove(phoneBookUser);
                _context.SaveChanges();
                return true;
            }

            return false;
        }


        public PhoneBookUser ReadUser(int id) => _context.PhoneBookUsers.Where(x => x.Id == id).FirstOrDefault();

        public bool UpdateUser(int id, PhoneBookUser user)
        {
            var existingPhoneBookUser = _context.PhoneBookUsers.Where(x => x.Id == id).FirstOrDefault();

            if (existingPhoneBookUser != null)
            {
                existingPhoneBookUser = user;

                _context.PhoneBookUsers.Update(existingPhoneBookUser);
                _context.SaveChanges();

                return true;
            }

            return false;
        }

    }
}
