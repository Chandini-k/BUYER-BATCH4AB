using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemsService.Manager
{
    public interface IItemManager
    {
        Task<List<Items>> Search(string itemName);
        Task<List<Items>> SearchItemByCategory(int categoryId);
        Task<List<Items>> SearchItemBySubCategory(int subCategoryId);
        Task<bool> BuyItem(Purchasehistory purchase);
        Task<List<Purchasehistory>> Purchase(int buyerId);
        Task<List<Category>> GetCategories();
        Task<List<SubCategory>> GetSubCategories(int categoryId);
        Task<List<Items>> GetItems();
        Task<bool> AddToCart(Cart cart);
        Task<int> GetCount(int buyerId);
        Task<bool> CheckCartItem(int buyerId, int itemId);
        Task<List<Cart>> GetCarts(int buyerId);
        Task<bool> DeleteCart(int cartId);
        Task<Cart> GetCartItem(int cartId);
        Task<List<Items>> Items(int price, int price1);
    }
}
