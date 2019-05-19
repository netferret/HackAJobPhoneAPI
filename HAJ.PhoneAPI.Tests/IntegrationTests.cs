using HAJ.PhoneAPI.Controllers;
using HAJ.PhoneAPI.Domain;
using HAJ.PhoneAPI.Services;
using Xunit;
using HAJ.PhoneAPI.Domain.Data;
using HAJ.PhoneAPI.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace HAJ.PhoneAPI.Tests
{
    public class RepositoryTests
    {

        private IUserService _userService;
        private IPhoneBookUsersRespository _phoneBookUsersRespository;

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
        }

        [Fact]
        public void CreateUser()
        {
            var newUser = new PhoneBookUser
            {
                FirstName = "Joe",
                Surname = "Bloggs",
                Number = "01821276323",
                HouseNameNumber = "124",
                Street = "Test Street",
                Postcode = "L12 1234"
            };

            var controller = new UserController(_userService, _phoneBookUsersRespository);

            dynamic test = controller.Create(newUser);

            Assert.NotNull(test.StatusCode == 200);
        }
    }
}
