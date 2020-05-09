using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using BUYERDBENTITY.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using UserService.Controllers;
using UserService.Manager;

namespace UserServiceTesting
{
    [TestFixture]
    public class UserControllerTesting
    { 

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
                mockUserManageer.Setup(x => x.BuyerRegister(buyerRegister)).ReturnsAsync(true);
                var result = await userController.Buyer(buyerRegister) as OkResult;
                Assert.That(result, Is.Not.Null);
                Assert.That(result.StatusCode, Is.EqualTo(200));
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
        [TestCase("chandi", "abcdefg@")]
        [Description("Buyer Login")]
        public async Task BuyerLogin_Successfull(string userName, string password)
        {
            try
            {
                Login login = new Login() { userName = userName, userPassword = password };
                var result = await userController.BuyerLogin(login) as OkResult;
                Assert.That(result, Is.Not.Null);
                Assert.That(result.StatusCode, Is.EqualTo(200));
            }
            catch (Exception e)
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
                Assert.IsNull(result);
                Assert.IsNull(result,"Invalid User");
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
