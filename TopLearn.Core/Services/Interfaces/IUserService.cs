using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopLearn.Core.DTOs;
using TopLearn.DataLayer.Entities.User;
using TopLearn.DataLayer.Entities.Wallet;

namespace TopLearn.Core.Services.Interfaces
{
    public interface IUserService
    {
        bool IsExistUserName(string username);
        bool IsExistEmail(string email);
        User LogInUser(LogInViewModel login);
        User getpassbyemail(string email);


        UserPanelViewModel GetUserInformation(string username);

        EditProfileViewModel Getinformforedit(string username);

        void EditProfile(string username,EditProfileViewModel editProfileViewModel);

        bool compareoldnewpass(string oldpassword ,string username);

        void changepassword(string username, string newpassword);

        int BalanceUserWallet(string username);

        List<WalletViewModel> GetWalletUser(string username);

        int ChargeWallet(string username,int amount,string description,bool ispay=false);

        Wallet getwalletbywalletid(int walletid);

        void updatewallet(Wallet wallet);

    }
}
