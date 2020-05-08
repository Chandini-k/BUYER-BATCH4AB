using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BUYERDBENTITY.Entity;
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
        [HttpGet]
        [Route("GetItems")]
        public async Task<IActionResult> GetItems()
        {
            List<Items> items = await _iitemManager.GetItems();
            if (items != null)
            {
                return Ok(items);
            }
            else
                return Ok("No Items Found");
        }
        [HttpPost]
        [Route("AddtoCart")]
        public async Task<IActionResult> AddToCart(Cart cart)
        {
            bool cart1 = await _iitemManager.AddToCart(cart);
            if (cart1)
                return Ok();
            else
                return Ok("Item not added");
        }
        [HttpPost]
        [Route("BuyItem")]
        public async Task<IActionResult> BuyItem(Purchasehistory purchasehistory)
        {
            return Ok(await _iitemManager.BuyItem(purchasehistory));
        }
        [HttpGet]
        [Route("CheckCartItem/{buyerId}/{itemId}")]
        public async Task<IActionResult> CheckCartItem(int buyerId, int itemId)
        {
            return Ok(await _iitemManager.CheckCartItem(buyerId, itemId));
        }
        [HttpDelete]
        [Route("DeleteCart/{cartid}")]
        public async Task<IActionResult> DeleteCart(int cartid)
        {
            return Ok(await _iitemManager.DeleteCart(cartid));
        }
        [HttpGet]
        [Route("GetCartItem/{cid}")]
        public async Task<IActionResult> GetCartItem(int cartId)
        {
            Cart cart = await _iitemManager.GetCartItem(cartId);
            if (cart != null)
            {
                return Ok(cart);
            }
            else
            {
                return Ok("Cart is Null");
            }
        }
        [HttpGet]
        [Route("GetCart/{buerId}")]
        public async Task<IActionResult> GetCart(int buyerId)
        {
            return Ok(await _iitemManager.GetCarts(buyerId));
        }
        [HttpGet]
        [Route("GetCategory")]
        public async Task<IActionResult> GetCategory()
        {
            return Ok(await _iitemManager.GetCategories());
        }
        [HttpGet]
        [Route("GetCount/{buyerId}")]
        public async Task<IActionResult> GetCount(int buyerId)
        {
            return Ok(await _iitemManager.GetCount(buyerId));
        }
        [HttpGet]
        [Route("GetSubCategory/{categoryId}")]
        public async Task<IActionResult> SubCategory(int categoryId)
        {
            return Ok(await _iitemManager.GetSubCategories(categoryId));
        }
        [HttpGet]
        [Route("SortItem/{price}/{price1}")]
        public async Task<IActionResult> Sort(int price, int price1)
        {

            return Ok(await _iitemManager.Items(price, price1));

        }
        [HttpGet]
        [Route("PurchaseHistory/{buyerId}")]
        public async Task<IActionResult> Purchase(int buyerId)
        {
            return Ok(await _iitemManager.Purchase(buyerId));
        }
        [HttpGet]
        [Route("SearchItems/{itemName}")]
        public async Task<IActionResult> SearchItem(string itemName)
        {

            return Ok(await _iitemManager.Search(itemName));
        }
        [HttpGet]
        [Route("SearchItemByCategory/{categoryId}")]
        public async Task<IActionResult> SearchItemByCategory(int categoryId)
        {
                return Ok(await _iitemManager.SearchItemByCategory(categoryId));
        }
        [HttpGet]
        [Route("SearchItemBySubCategory/{subCategoryId}")]
        public async Task<IActionResult> SearchItemBySubCategory(int subCategoryId)
        {
            
            return Ok(await _iitemManager.SearchItemBySubCategory(subCategoryId));
            
        }
    }
}