using backend.DataAccess;
using backend.Models;
using System.Collections.Generic;
using System.Linq;

namespace backend.Services
{
    public class AccountService
    {
        private readonly List<Account> _accounts;

        public AccountService()
        {
            _accounts = new List<Account>(); 
        }

        // Create a new account
        public AccountResponse CreateAccount(CreateAccountDto accountDto)
        {
            var newAccount = new Account
            {
                UserID = accountDto.UserID,
                PaymentInformation = accountDto.PaymentInformation
            };

            _accounts.Add(newAccount);

            return MapAccountToAccountResponse(newAccount);
        }

        public IEnumerable<AccountResponse> GetAllAccounts()
        {
            return _accounts.Select(a => MapAccountToAccountResponse(a));
        }

        public AccountResponse GetAccountById(int accountId)
        {
            var account = _accounts.FirstOrDefault(a => a.AccountID == accountId);
            if (account == null)
                return null; 

            return MapAccountToAccountResponse(account);
        }

        // Update an account
        public AccountResponse UpdateAccount(int accountId, UpdateAccountDto accountDto)
        {
            var accountToUpdate = _accounts.FirstOrDefault(a => a.AccountID == accountId);
            if (accountToUpdate == null)
                return null; 

            accountToUpdate.PaymentInformation = accountDto.PaymentInformation;

            return MapAccountToAccountResponse(accountToUpdate);
        }

        // Delete an account
        public bool DeleteAccount(int accountId)
        {
            var accountToDelete = _accounts.FirstOrDefault(a => a.AccountID == accountId);
            if (accountToDelete == null)
                return false; 

            _accounts.Remove(accountToDelete); 
            return true;
        }

        private AccountResponse MapAccountToAccountResponse(Account account)
        {
            return new AccountResponse
            {
                AccountID = account.AccountID,
                UserID = account.UserID,
                PaymentInformation = account.PaymentInformation
            };
        }
    }
}


//Kaltrina test
// using backend.DataAccess;
//using backend.Entities;
//using backend.Models;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;

//namespace backend.Services
//{
   // public class AccountService
    //{
   //     private readonly ProjectDbContext _context;

      //  public AccountService(ProjectDbContext context)
        //{
          //  _context = context;
        //}

   //     public AccountResponse CreateAccount(CreateAccountDto accountDto)
     //   {
       //     var newAccount = new Account
         //   {
           //     UserID = accountDto.UserID,
             //   PaymentInformation = accountDto.PaymentInformation
            // };

            // _context.Accounts.Add(newAccount);
            // _context.SaveChanges();

//            return MapAccountToAccountResponse(newAccount);
   //      }

        

     //   private AccountResponse MapAccountToAccountResponse(Account account)
        //{
       //     return new AccountResponse
          //  {
            //    AccountID = account.AccountID,
              //  UserID = account.UserID,
                //PaymentInformation = account.PaymentInformation
            //};
        //}
  //  }
//}
