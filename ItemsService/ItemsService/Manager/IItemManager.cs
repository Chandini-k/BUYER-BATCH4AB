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
        Task<List<Items>> Search(Product product);
        Task<List<Items>> SearchItemByCategory(ProductCategory productCategory);
        Task<List<Items>> SearchItemBySubCategory(ProductSubCategory productSubCategory);
        Task<bool> BuyItem(PurchaseHistory purchase);
        Task<List<Purchasehistory>> Purchase(PurchaseHistory purchaseHistory);
        Task<List<Category>> GetCategories();
        Task<List<SubCategory>> GetSubCategories(ProductCategory productCategory);
        Task<bool> AddToCart(AddCart cart);
        Task<int> GetCount(int buyerid);
        Task<bool> CheckCartItem(int buyerid, int itemid);
        Task<List<Cart>> GetCarts(int buyerid);
        Task<bool> DeleteCart(int cartId);
        Task<AddCart> GetCartItem(int cartid);
        Task<List<Items>> Items(int price, int price1);
    }
}
