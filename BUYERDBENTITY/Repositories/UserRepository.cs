using BUYERDBENTITY.Entity;
using BUYERDBENTITY.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BUYERDBENTITY.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BuyerContext _context;
        public UserRepository(BuyerContext context)
        {
            _context = context;
        }

        public async Task<bool> BuyerRegister(BuyerRegister buyer)
        {
            Buyer buyer1 = new Buyer();
            if(buyer!=null)
            {
                buyer1.Bid = buyer.buyerId;
                buyer1.Username = buyer.userName;
                buyer1.Password = buyer.password;
                buyer1.Mobileno = buyer.mobileNo;
                buyer1.Email = buyer.emailId;
                buyer1.Datetime = buyer.dateTime;
            }
            _context.Buyer.Add(buyer1);
            var user = await _context.SaveChangesAsync();
            if (user > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Login> BuyerLogin(Login login)
        {
             Buyer buyer = await _context.Buyer.SingleOrDefaultAsync(e => e.Username ==login.userName && e.Password == login.userPassword);
            if (buyer!=null)
            {
                return login;
            }
            else
            {
                Console.WriteLine("Not valid");
                return null;
            }

        }
    }
}
