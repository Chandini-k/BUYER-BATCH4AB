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
        Task<List<Product>> Search(Product product);
        Task<List<Product>> SearchItemByCategory(ProductCategory productCategory);
        Task<List<Product>> SearchItemBySubCategory(ProductSubCategory productSubCategory);
        Task<bool> BuyItem(PurchaseHistory purchase);
        Task<List<PurchaseHistory>> Purchase(PurchaseHistory purchaseHistory);
        Task<List<ProductCategory>> GetCategories();
        Task<List<ProductSubCategory>> GetSubCategories(ProductCategory productCategory);
        Task<bool> AddToCart(AddCart cart);
        Task<int> GetCount(int bid);
        Task<bool> CheckCartItem(int buyerid, int itemid);
        Task<List<AddCart>> GetCarts(int bid);
        Task<bool> DeleteCart(int cartId);
        Task<AddCart> GetCartItem(int cartid);
        Task<List<Product>> Items(int price, int price1);
       
    }
}
