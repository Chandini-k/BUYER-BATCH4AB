using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using BUYERDBENTITY.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItemServiceTesting
{
    [TestFixture]
    public class ItemRepositoryTesting
    {
        IItemRepository iitemRepository;

        [SetUp]
        public void SetUp()
        {
            iitemRepository = new ItemRepository(new BuyerContext());
        }
        [TearDown]
        public void TearDown()
        {
            iitemRepository = null;
        }
        [Test]
        [TestCase(123, 856, 401, 1235, 50, "atta", "flour", "342", "good", "atta.img")]
        public async Task AddToCart_Successfull(int cartId, int categoryId, int subCategoryId, int buyerId, int price, string itemName, string description, int stockno, string remarks, string imageName)
        {
            try
            {
                var cart = new AddCart { carId = cartId, categoryId = categoryId, subCategoryId = subCategoryId, buyerId = buyerId, price = price, itemName = itemName, description = description, stockno = stockno, remarks = remarks, imageName = imageName };
                var mock = new Mock<IItemRepository>();
                mock.Setup(x => x.AddToCart(cart)).ReturnsAsync(true);
                var result = await iitemRepository.AddToCart(cart);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

    }
}
