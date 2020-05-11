using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using ItemsService.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItemsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemManager _iitemManager;
        public ItemsController(IItemManager iitemManager)
        {
            _iitemManager = iitemManager;
        }
        /// <summary>
        /// Add to cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddtoCart")]
        public async Task<IActionResult> AddToCart(AddCart cart)
        {
            bool cart1 = await _iitemManager.AddToCart(cart);
            if (cart1)
                return Ok();
            else
                return Ok("Item not added");
        }
        /// <summary>
        /// Buying item
        /// </summary>
        /// <param name="purchasehistory"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("BuyItem")]
        public async Task<IActionResult> BuyItem(PurchaseHistory purchasehistory)
        {
            return Ok(await _iitemManager.BuyItem(purchasehistory));
        }
        /// <summary>
        /// Check cart item
        /// </summary>
        /// <param name="buyerId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("CheckCartItem/{buyerId}/{itemId}")]
        public async Task<IActionResult> CheckCartItem(int buyerId, int itemId)
        {
            return Ok(await _iitemManager.CheckCartItem(buyerId, itemId));
        }
        /// <summary>
        /// Delete Cart Item
        /// </summary>
        /// <param name="cartid"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteCart/{cartid}")]
        public async Task<IActionResult> DeleteCart(int cartid)
        {
            return Ok(await _iitemManager.DeleteCart(cartid));
        }
        /// <summary>
        /// Get Cart Item
        /// </summary>
        /// <param name="cartid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCartItem/{cartid}")]
        public async Task<IActionResult> GetCartItem(int cartid)
        {
            AddCart cart1 = await _iitemManager.GetCartItem(cartid);
            if (cart1 != null)
            {
                return Ok(cart1);
            }
            else
            {
                return Ok("Cart is Null");
            }
        }
        /// <summary>
        /// Get Cart Itm
        /// </summary>
        /// <param name="buyerId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCart/{buerId}")]
        public async Task<IActionResult> GetCart(int buyerId)
        {
            return Ok(await _iitemManager.GetCarts(buyerId));
        }
        /// <summary>
        /// GetCategory of items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCategory")]
        public async Task<IActionResult> GetCategory()
        {
            return Ok(await _iitemManager.GetCategories());
        }
        /// <summary>
        /// Get cart count
        /// </summary>
        /// <param name="buyerId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCount/{buyerId}")]
        public async Task<IActionResult> GetCount(int buyerId)
        {
            return Ok(await _iitemManager.GetCount(buyerId));
        }
        /// <summary>
        /// Get SubCategory
        /// </summary>
        /// <param name="productCategory"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSubCategory/{categoryName}")]
        public async Task<IActionResult> SubCategory(string categoryName)
        {
            if(categoryName is null)
            {
                return BadRequest();
            }
            return Ok(await _iitemManager.GetSubCategories(categoryName));
        }
        /// <summary>
        /// Items Prices in sorted order
        /// </summary>
        /// <param name="price"></param>
        /// <param name="price1"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("SortItem/{price}/{price1}")]
        public async Task<IActionResult> Sort(int price, int price1)
        {

            return Ok(await _iitemManager.Items(price, price1));

        }
        /// <summary>
        /// Purchase history
        /// </summary>
        /// <param name="purchaseHistory"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("PurchaseHistory/{buyerId}")]
        public async Task<IActionResult> Purchase(int buyerId)
        {
            return Ok(await _iitemManager.Purchase(buyerId));
        }
        /// <summary>
        /// Search items
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("SearchItems/{itemName}")]
        public async Task<IActionResult> SearchItem(string itemName)
        {

            return Ok(await _iitemManager.Search(itemName));
        }
        /// <summary>
        /// search items using category
        /// </summary>
        /// <param name="productCategory"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("SearchItemByCategory/{categoryName}")]
        public async Task<IActionResult> SearchItemByCategory(string categoryName)
        {
                return Ok(await _iitemManager.SearchItemByCategory(categoryName));
        }
        /// <summary>
        /// Search items using Subcategory
        /// </summary>
        /// <param name="productSubCategory"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("SearchItemBySubCategory/{subCategoryName}")]
        public async Task<IActionResult> SearchItemBySubCategory(string subCategoryName)
        {
            
            return Ok(await _iitemManager.SearchItemBySubCategory(subCategoryName));
            
        }
    }
}