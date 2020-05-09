using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using BUYERDBENTITY.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace UserServiceTesting
{
    [TestFixture]
    public class TestUserRepository
    {
        IUserRepository userRepository;
        [SetUp]
        public void SetUp()
        {
            userRepository = new UserRepository(new BuyerContext());
        }

        [TearDown]
        public void TearDown()
        {
            userRepository = null;
        }
        /// <summary>
        /// Testing register buyer
        /// </summary>
        [Test]
        [TestCase(4343, "chinari", "abcdefg2","9365756295","chinnari@gmail.com")]
        [TestCase(6466, "cutepie", "abcdefg2", "9462753495", "cutepie@gmail.com")]
        [Description("testing buyer Register")]
        public async Task RegisterBuyer_Successfull(int buyerId, string userName, string password, string mobileNo, string email)
        {
            try
            {
                DateTime datetime = System.DateTime.Now;
                var buyer = new BuyerRegister { buyerId = buyerId, userName = userName, password = password, mobileNo = mobileNo, emailId=email,dateTime = datetime };
                var mock = new Mock<IUserRepository>();
                mock.Setup(x => x.BuyerRegister(buyer)).ReturnsAsync(true);
                var result=await userRepository.BuyerRegister(buyer);
                Assert.NotNull(result);
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// Buyer Login success
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Test]
        [TestCase("chandinik","abcdefg@")]
        [Description("testing buyer login")]
        public async Task BuyerLogin_Successfull(string userName,string password)
        {
            try
            {
                var login = new Login { userName = userName, userPassword = password };
                var result = await userRepository.BuyerLogin(login);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test]
        [TestCase("chandin", "abcdefg@")]
        [Description("Test buyer login failure case")]
        public async Task BuyerLogin_UnSuccessfull(string userName,string password)
        {
            try
            {
                var login = new Login { userName = userName, userPassword = password };
                var result = await userRepository.BuyerLogin(login);
                Assert.IsNull(result,"Invalid");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }

}