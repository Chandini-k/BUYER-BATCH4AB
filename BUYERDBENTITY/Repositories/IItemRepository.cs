using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BUYERDBENTITY.Repositories
{
    public interface IItemRepository
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
        Task<int> GetCount(int bid);
        Task<bool> CheckCartItem(int buyerid, int itemid);
        Task<List<Cart>> GetCarts(int bid);
        Task<bool> DeleteCart(int cartId);
        Task<Cart> GetCartItem(int cartid);
        Task<List<Items>> Items(int price, int price1);
    }
}
