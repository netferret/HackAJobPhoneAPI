using HAJ.PhoneAPI.Controllers;
using HAJ.PhoneAPI.Domain;
using HAJ.PhoneAPI.Services;
using Xunit;
using HAJ.PhoneAPI.Domain.Data;
using HAJ.PhoneAPI.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using System;

namespace HAJ.PhoneAPI.Tests
{
    public class RepositoryTests
    {

        private IUserService _userService;
        private IPhoneBookUsersRespository _phoneBookUsersRespository;
        private UserController _userController;
        private PhoneBookUser _phoneBookUser;

        public RepositoryTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PhoneContext>();
            optionsBuilder.UseSqlServer
              (@"Server=(localdb)\mssqllocaldb;Database=PhoneAPI;Trusted_Connection=True;ConnectRetryCount=0");

            var options = Options.Create<AppSettings>(new AppSettings
            {
                Secret = "ApplicationSecret1235"
            });

            _userService = new UserService(options);
            _phoneBookUsersRespository = new PhoneBookUsersRepository(new PhoneContext(optionsBuilder.Options));

            _userController = new UserController(_userService, _phoneBookUsersRespository);

            _phoneBookUser = new PhoneBookUser
            {
                FirstName = "Joe",
                Surname = "Bloggs",
                Number = "01821276323",
                HouseNameNumber = "124",
                Street = "Test Street",
                Postcode = "L12 1234"
            };
        }

        [Fact]
        public void CreateUser()
        {
            dynamic test = _userController.Create(_phoneBookUser);

            Assert.True(test.StatusCode == 200);
        }

        [Fact]
        public void DeleteUserScenario()
        {
            dynamic createResult = _userController.Create(_phoneBookUser);
            Assert.True(createResult.StatusCode == 200);
            Assert.NotNull(createResult.Value.Id);


            dynamic getUserResult = _userController.Get(createResult.Value.Id);
            Assert.True(getUserResult.Result.StatusCode == 200);
            Assert.NotNull(getUserResult.Result.Value.Id);

            var id = getUserResult.Result.Value.Id;
            dynamic deleteResult = _userController.Delete(((int)id));
            Assert.True(deleteResult.Result.StatusCode == 200);
        }
    }
}
