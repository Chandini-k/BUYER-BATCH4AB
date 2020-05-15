using BUYERDBENTITY.Models;
using ItemsService.Controllers;
using ItemsService.Manager;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItemServiceTesting
{
    [TestFixture]
    public class ItemControllerTesting
    {ItemController itemsController;
        private Mock<IManager> mockItemManager;

        [SetUp]
        public void SetUp()
        {

            mockItemManager = new Mock<IManager>();
            itemsController = new ItemController(mockItemManager.Object);
        }
        [TearDown]
        public void TearDown()
        {
            itemsController = null;
        }
        /// <summary>
        /// Add to cart
        /// </summary>
        /// <returns></returns>
        [Test]
        [TestCase(123, 123455, 662, 500, "atta", "flour", "342", "good", "atta.img")]
        [Description("Add to cart testing")]
        public async Task AddToCart_Successfull(int cartId, int buyerId, int itemid, int price, string itemName, string description, int stockno, string remarks, string imageName)
        {
            try
            {
                var cart = new Addcart { cartId = cartId, buyerId = buyerId, itemId = itemid, price = price, itemName = itemName, description = description, stockno = stockno, remarks = remarks, imageName = imageName };
                mockItemManager.Setup(x => x.AddToCart(cart)).ReturnsAsync(true);
                var result = await itemsController.AddToCart(cart);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// buy item
        /// </summary>
        /// <returns></returns>
        [Test]
        [TestCase(2341, 1234, 662, "debit", 2, "good quality", "paid")]
        [Description("Buy item sucessfull")]
        public async Task BuyItem_Sucessfull(int purchaseId, int buyerId, int itemId, string transactionType, int noofitems, string remarks, string transactionStatus)
        {
            try
            {
                DateTime dateTime = System.DateTime.Now;
                var purchaseHistory = new purchasehistory { purchaseId = purchaseId, buyerId = buyerId, itemId = itemId, transactionType = transactionType, noOfItems = noofitems, remarks = remarks, transactionStatus = transactionStatus, dateTime = dateTime };
                mockItemManager.Setup(x => x.BuyItem(purchaseHistory)).ReturnsAsync(true);
                var result = await itemsController.BuyItem(purchaseHistory);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// check cart item
        /// </summary>
        /// <param name="buyerid"></param>
        /// <param name="itemid"></param>
        /// <returns></returns>
        [Test]
        [TestCase(1235, 662)]
        [Description("check cart")]
        public async Task CheckCartItem_Sucessfull(int buyerid, int itemid)
        {
            try
            {
                var result = await itemsController.CheckCartItem(buyerid, itemid) as OkObjectResult;
                Assert.AreEqual(200,result.StatusCode);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test]
        [TestCase(1232, 532)]
        [Description("Check cart by cart buyerid")]
        public async Task CheckCartItem_UnSucessfull(int buyerid, int itemid)
        {
            try
            {
                var result = await itemsController.CheckCartItem(buyerid, itemid) as NoContentResult;
                Assert.AreEqual(204,result.StatusCode);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// delete cart
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        [Test]
        [TestCase(122)]
        [Description("Delete cart Successful")]
        public async Task DeleteCart_Sucessfull(int cartId)
        {
            try
            {
                var result = await itemsController.DeleteCart(cartId) as OkObjectResult;
                Assert.AreEqual(200,result.StatusCode);
            }
            catch (Exception e)
            {
                Assert.Fail(e.InnerException.Message);
            }
        }
        [Test]
        [TestCase(131)]
        [Description("Delete cart Unsucessful")]
        public async Task DeleteCart_UnSucessfull(int cartId)
        {
            try
            {
                var result = await itemsController.DeleteCart(cartId) as NotFoundResult;
                Assert.AreEqual(404,result.StatusCode);
            }
            catch (Exception e)
            {
                Assert.Fail(e.InnerException.Message);
            }
        }
        /// <summary>
        /// get cart
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        [Test]
        [TestCase(1235)]
        [Description("testing cart item")]
        public async Task GetCart_Successfull(int cartId)
        {
            try
            {
                var result = await itemsController.GetCartItem(cartId) as OkObjectResult;
                Assert.IsNotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test]
        [TestCase(124)]
        [Description("testing cart item")]
        public async Task GetCart_UnSuccessfull(int cartId)
        {
            try
            {
                var result = await itemsController.GetCartItem(cartId) as NoContentResult;
                Assert.AreEqual(204,result.StatusCode);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// get buyer cart
        /// </summary>
        /// <param name="buyerId"></param>
        /// <returns></returns>
        [Test]
        [TestCase(1235)]
        [Description("testing buyer cart item")]
        public async Task GetBuyerCart_Successfull(int buyerId)
        {
            try
            {
                 var result = await itemsController.GetCart(buyerId) as OkObjectResult;
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test]
        [TestCase(12)]
        [Description("testing buyer cart item")]
        public async Task GetBuyerCart_UnSuccessfull(int buyerId)
        {
            try
            {
                var result = await itemsController.GetCart(buyerId) as NotFoundResult;
                Assert.AreEqual(404,result.StatusCode);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// get buyer cart count
        /// </summary>
        /// <param name="buyerId"></param>
        /// <returns></returns>
        [Test]
        [TestCase(1235)]
        [Description("testing buyer cart item")]
        public async Task GetCartCount_Successfull(int buyerId)
        {
            try
            {
                var result = await itemsController.GetCount(buyerId) as OkObjectResult;
                Assert.AreEqual(200,result.StatusCode);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test]
        [TestCase(1453)]
        [Description("testing buyer cart item")]
        public async Task GetCartCount_UnSuccessfull(int buyerId)
        {
            try
            {
                var result = await itemsController.GetCount(buyerId) as NoContentResult;
                Assert.IsNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// sort items by price
        /// </summary>
        /// <param name="price"></param>
        /// <param name="price1"></param>
        /// <returns></returns>
        [Test]
        [TestCase(30, 100)]
        [Description("testing items in range ")]
        public async Task GetItems_Successfull(int price, int price1)
        {
            try
            {
                var result = await itemsController.Sort(price, price1);
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// purchase history
        /// </summary>
        /// <param name="buyerId"></param>
        /// <returns></returns>
        [Test]
        [TestCase(1235)]
        [Description("testing purchase history")]
        public async Task PurchaseHistory_Successfull(int buyerId)
        {
            try
            {
                var result = await itemsController.Purchase(buyerId) as OkObjectResult;
                Assert.IsNotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test]
        [TestCase(1234)]
        [Description("testing purchasehistory")]
        public async Task PurchaseHistory_UnSuccessfull(int buyerId)
        {
            try
            {
                var result = await itemsController.Purchase(buyerId) as NoContentResult;
                Assert.AreEqual(204,result.StatusCode);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        /// <summary>
        /// search items
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        [Test]
        [TestCase("milk")]
        [Description("testing search items")]
        public async Task SearchItems_Successfull(string itemName)
        {
            try
            {
                var result = await itemsController.SearchItem(itemName) as OkObjectResult;
                Assert.NotNull(result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test]
        [TestCase("choco")]
        [Description("testing search items")]
        public async Task SearchItems_UnSuccessfull(string itemName)
        {
            try
            {
                var result = await itemsController.SearchItem(itemName) as NotFoundResult;
                Assert.AreEqual(404,result.StatusCode);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
