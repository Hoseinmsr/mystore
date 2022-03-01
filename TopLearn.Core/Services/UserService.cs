using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopLearn.Core.Convertors;
using TopLearn.Core.DTOs;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayer.Context;
using TopLearn.DataLayer.Entities.User;
using TopLearn.DataLayer.Entities.Wallet;

namespace TopLearn.Core.Services
{
    public class UserService : IUserService
    {
        TopLearnContext _context;
        public UserService(TopLearnContext context)
        {
            _context = context;
        }

        public int BalanceUserWallet(string username)
        {
            var userid = _context.Users.SingleOrDefault(x => x.UserName == username).UserId;

            var Enter = _context.Wallets
                .Where(w => w.UserId == userid && w.TypeId == 1 && w.IsPay)
                .Select(w => w.Amount)
                .ToList();
            var Exit = _context.Wallets
                .Where(w => w.UserId == userid && w.TypeId == 2)
                .Select(w => w.Amount)
                .ToList();

            return (Enter.Sum() - Exit.Sum());
        }

        public void changepassword(string username, string newpassword)
        {
            var user = _context.Users.SingleOrDefault(x => x.UserName == username);
           
            user.Password = newpassword;
            _context.Update(user);
            _context.SaveChanges();
        }

        public int ChargeWallet(string username, int amount, string description, bool ispay = false)
        {
            var user = _context.Users.SingleOrDefault(x => x.UserName == username);
            var userid = user.UserId;
            Wallet wallet = new Wallet()
            {
                Amount = amount,
                Description = description,
                CreatDate = DateTime.Now,
                IsPay = ispay,
                TypeId = 1,
                UserId = userid,

            };
            _context.Wallets.Add(wallet);
            _context.SaveChanges();
            return wallet.WalletId;
        }

        public bool compareoldnewpass(string oldpassword, string username)
        {
            return _context.Users.Any(x => x.UserName == username && x.Password == oldpassword);
        }

        public void EditProfile(string username,EditProfileViewModel editProfileViewModel)
        {
            var user = _context.Users.SingleOrDefault(x => x.UserName == username);
            user.UserName = editProfileViewModel.UserName;
            user.Email = editProfileViewModel.Email;
            _context.Update(user);
            _context.SaveChanges();
        }

        public EditProfileViewModel Getinformforedit(string username)
        {
            return _context.Users.Where(x => x.UserName == username).Select(u => new EditProfileViewModel()
            {
                Email = u.Email,
                UserName=u.UserName
            }).Single();
        }

        public User getpassbyemail(string email)
        {
            return _context.Users.SingleOrDefault(x => x.Email == email);
        }

        public UserPanelViewModel GetUserInformation(string username)
        {
            var user = _context.Users.SingleOrDefault(x => x.UserName == username);
            UserPanelViewModel userPanel = new UserPanelViewModel()
            {
                Email=user.Email,
                UserName=user.UserName,
                RegisterDate=user.RegisterDate,
                Wallet=BalanceUserWallet(username)
            };
            return (userPanel);
        }

        public Wallet getwalletbywalletid(int walletid)
        {
            return _context.Wallets.Find(walletid);
        }

        public List<WalletViewModel> GetWalletUser(string username)
        {
            var user = _context.Users.SingleOrDefault(x => x.UserName == username);

           var userid = user.UserId;

           return _context.Wallets.Where(x => x.UserId == userid)
               .Select(x => new WalletViewModel()
               {
                   Amount = x.Amount,
                   DateTime = x.CreatDate,
                   Description = x.Description,
                   Type = x.TypeId
               }).ToList();
        }

        public bool IsExistEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool IsExistUserName(string username)
        {
            return _context.Users.Any(u => u.UserName == username);
        }

        public User LogInUser(LogInViewModel login)
        {
            string password=login.Password;
            string email = Fixetext.fixemail(login.Email);
            return _context.Users.SingleOrDefault(x=>x.Email==email && x.Password==password);
        }

        public void updatewallet(Wallet wallet)
        {
            _context.Wallets.Update(wallet);
            _context.SaveChanges();
        }
    }
}
