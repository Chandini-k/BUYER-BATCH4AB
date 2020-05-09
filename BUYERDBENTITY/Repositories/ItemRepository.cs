using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUYERDBENTITY.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly BuyerContext _context;
        public ItemRepository(BuyerContext context)
        {
            _context = context;
        }
        public async Task<bool> AddToCart(AddCart cart)
        {
            Cart cart1 = new Cart();
            if (cart!= null)
            {
                cart1.Id = cart.carId;
                cart1.Categoryid = cart.categoryId;
                cart1.Subcategoryid = cart.subCategoryId;
                cart1.Bid = cart.buyerId;
                cart1.Itemid = cart.itemId;
                cart1.Price = cart.price;
                cart1.Itemname = cart.itemName;
                cart1.Description = cart.description;
                cart1.Stockno = cart.stockno;
                cart1.Remarks = cart.remarks;
                cart1.Imagename = cart.imageName;
            }
            _context.Cart.Add(cart1);
            var buyercart=await _context.SaveChangesAsync();
            if(buyercart>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> BuyItem(PurchaseHistory purchase)
        {
            Purchasehistory purchasehistory = new Purchasehistory();
            if (purchase != null)
            {
                purchasehistory.Id = purchase.purchaseId;
                purchasehistory.Bid = purchase.buyerId;
                purchasehistory.Transactiontype = purchase.transactionType;
                purchasehistory.Itemid = purchase.itemId;
                purchasehistory.Noofitems = purchase.noOfItems;
                purchasehistory.Datetime = purchase.dateTime;
                purchasehistory.Remarks = purchase.remarks;
                purchasehistory.Transactionstatus = purchase.transactionStatus;
            }
            _context.Purchasehistory.Add(purchasehistory);
            var buyitem=await _context.SaveChangesAsync();
            if(buyitem>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> CheckCartItem(int buyerid, int itemid)
        {
            Cart cart = await _context.Cart.SingleOrDefaultAsync(e => e.Bid == buyerid && e.Itemid == itemid);
            if (cart != null)
            {
                return true;
            }
            else
                return false;
        }

        public async Task<bool> DeleteCart(int cartId)
        {
            Cart cart=await _context.Cart.FindAsync(cartId);
            _context.Cart.Remove(cart);
            var cartitem=await _context.SaveChangesAsync();
            if(cartitem==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<AddCart> GetCartItem(int cartid)
        {
            Cart cart = await _context.Cart.FindAsync(cartid);
            if (cart == null)
                return null;
            else
            {
                AddCart cart1 = new AddCart();
                cart1.carId = cart.Id;
                cart1.categoryId = cart.Categoryid;
                cart1.subCategoryId = cart.Subcategoryid;
                cart1.buyerId = cart.Bid;
                cart1.itemId = cart.Itemid;
                cart1.price = cart.Price;
                cart1.itemName = cart.Itemname;
                cart1.description = cart.Description;
                cart1.stockno = cart.Stockno;
                cart1.remarks = cart.Remarks;
                cart1.imageName = cart.Imagename;
                return cart1;
            }
        }

        public async Task<List<Cart>> GetCarts(int bid)
        {
            return await _context.Cart.Where(e => e.Bid == bid).ToListAsync();
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<int> GetCount(int bid)
        {
            var count=await _context.Cart.Where(e => e.Bid == bid).ToListAsync();
            int count1=count.Count();
            return count1;
        }
        public async Task<List<SubCategory>> GetSubCategories(ProductCategory productCategory)
        {
            if (productCategory == null)
            {
                return null;
            }
            else
            {
                return await _context.SubCategory.Where(e => e.Cname == productCategory.categoryName).ToListAsync();
            }
        }

        public async Task<List<Items>> Items(int price, int price1)
        {
            return await _context.Items.Where(e => e.Price >= price && e.Price <= price1).ToListAsync();
        }

        public async Task<List<Purchasehistory>> Purchase(PurchaseHistory purchaseHistory)
        {
            Buyer buyer = _context.Buyer.Find(purchaseHistory.buyerId);
            if(buyer==null)
            {
                return null;
            }
            else
            {
                return await _context.Purchasehistory.Where(e => e.Bid == buyer.Bid).ToListAsync();
            }
           
        }

        public async Task<List<Items>> Search(Product product)
        {
            if (product == null)
            {
                return null;
            }
            else
            {
                return await _context.Items.Where(e => e.Itemname == product.productName).ToListAsync();
            }
        }

        public async Task<List<Items>> SearchItemByCategory(ProductCategory productCategory)
        {
            if (productCategory == null)
            {
                return null;
            }
            else
            {
                return await _context.Items.Where(e => e.Categoryname == productCategory.categoryName).ToListAsync();
            }
        }

        public async Task<List<Items>> SearchItemBySubCategory(ProductSubCategory productSubCategory)
        {
            if (productSubCategory == null)
            {
                return null;
            }
            else
            {
                return await _context.Items.Where(e => e.Subcategoryname == productSubCategory.subCategoryName).ToListAsync();
            }
        }
    }

}
