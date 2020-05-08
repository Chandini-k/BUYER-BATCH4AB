using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using BUYERDBENTITY.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using System.Web.Http.Results;
using UserService.Controllers;
using UserService.Manager;

namespace UserServiceTesting
{
    [TestFixture]
    public class UserControllerTesting
    {
        //UserController userController;
        //[SetUp]
        //public void SetUp()
        //{
        //    userController = new UserController(new UserManager(new UserRepository(new BuyerContext())));
        //}
        //[Test]
        //[TestCase(1452,"milky","abcdefg2","9636737838","milky@gmail.com")]
        //public async Task Persons_Add(int buyerId, string userName, string password, string mobileNo, string email)
        //{
        //    DateTime datetime = System.DateTime.Now;
        //    var buyer = new BuyerRegister { buyerId = buyerId, userName = userName, password = password, mobileNo = mobileNo, emailId = email, dateTime = datetime };
        //    var mock = new Mock<IUserManager>();
        //    mock.Setup(x => x.BuyerRegister(buyer)).ReturnsAsync(true);
        //    UserController userController1 = new UserController(mock.Object);
        //    var result = await userController1.Buyer(buyer);
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(true, result);
        //}

        private UserController userController;
        private Mock<IUserManager> mockUserManageer;
        private Mock<ILogger<UserController>> logger;
        [SetUp]
        public void Setup()
        {
            mockUserManageer = new Mock<IUserManager>();
            logger = new Mock<ILogger<UserController>>();
            userController = new UserController(logger.Object,mockUserManageer.Object);
            
        }
        [Test]
        [TestCase(6499, "oreo", "abcdefg2", "9462753495", "oreo@gmail.com")]
        [Description("Register Buyer")]
        public async Task RegisterBuyer_Successfull(int buyerId, string userName, string password, string mobileNo, string email)
        {
            try
            {
                DateTime dateTime = System.DateTime.Now;
                BuyerRegister buyerRegister = new BuyerRegister() { buyerId = buyerId, userName = userName, password = password, mobileNo = mobileNo, emailId = email, dateTime = dateTime };
                mockUserManageer.Setup(d => d.BuyerRegister(buyerRegister)).ReturnsAsync(true);
                IActionResult result = await userController.Buyer(buyerRegister);
                Assert.IsNotNull(result);
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Buyer Login
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Test]
        [TestCase("chandinik", "abcdefg@")]
        [Description("Buyer Login")]
        public async Task BuyerLogin_Successfull(string userName, string password)
        {
            try
            {
                Login login = new Login() { userName = userName, userPassword = password };
                mockUserManageer.Setup(d => d.BuyerLogin(login)).ReturnsAsync(login);
                IActionResult result = await userController.BuyerLogin(login);
                var contentResult = result as OkNegotiatedContentResult<Login>;
                Assert.IsNotNull(contentResult);
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Buyer Login
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Test]
        [TestCase("chandinik", "abcdefg@")]
        [Description("Buyer Login")]
        public async Task BuyerLogin_UnSuccessfull(string userName, string password)
        {
            try
            {
                Login login = new Login() { userName = userName, userPassword = password };
                mockUserManageer.Setup(d => d.BuyerLogin(login)).ReturnsAsync(login);
                IActionResult result = await userController.BuyerLogin(login);
                var contentResult = result as OkNegotiatedContentResult<Login>;
                Assert.IsNull(result);
                Assert.IsNull(contentResult,"Invalid User");
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
