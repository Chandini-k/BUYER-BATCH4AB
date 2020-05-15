using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuyerDB.Entity;
using ItemService.Manager;
using ItemService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItemService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IManager _iitemManager;
        public ItemController(IManager iitemManager)
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
        public async Task<IActionResult> AddToCart(Addcart cart)
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
        public async Task<IActionResult> BuyItem(purchasehistory purchasehistory)
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
            bool check = await _iitemManager.CheckCartItem(buyerId, itemId);
            if (check == true) { return Ok(); }
            else { return NoContent(); }
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
            bool b = await _iitemManager.DeleteCart(cartid);
            if (b==true) { return Ok(); }
            else { return NotFound(); }
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
            Addcart cart1 = await _iitemManager.GetCartItem(cartid);
            if (cart1 != null)
            {
                return Ok(cart1);
            }
            else
            {
                return NoContent();
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
            var check = await _iitemManager.GetCarts(buyerId);
            if (check == null) { return NoContent(); }
            else { return Ok(check); }
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
            var check = await _iitemManager.Purchase(buyerId);
            if (check != null) { return Ok(); }
            else { return NoContent(); }
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
            var check = await _iitemManager.Search(itemName);
            if (check != null) { return Ok(); }
            else { return NotFound(); }
        }
    }
}
    
