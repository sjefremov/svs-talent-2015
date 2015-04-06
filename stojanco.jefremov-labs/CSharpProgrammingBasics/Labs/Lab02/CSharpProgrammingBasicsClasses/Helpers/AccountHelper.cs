using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpProgrammingBasics.Classes.Accounts;

namespace CSharpProgrammingBasics.Classes.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class AccountHelper
    {
        private static int s_accountId;
        /// <summary>
        /// Increase the private static s_AccountId variable and returns the new value.
        /// </summary>
        /// <returns></returns>
        public static int GenerateAccountId()
        {
            return ++s_accountId;
        }
        /// <summary>
        /// 
        /// </summary>
        static AccountHelper()
        {
            s_accountId = 0;
        }
        /// <summary>
        /// Checks what is the type provided in the parameter and according to the type generates an account number in the following format:
        /// - When type = TransactionAccount, TR0000AccountId
        /// - When type = DepositAccount, DP0000AccountId
        /// - When type = LoanAccount, LN0000AccountId.
        /// </summary>
        /// <param name="accountType"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public static string GenerateAccountNumber(Type accountType, long accountId)
        {
            string accountNumber = null;
            if (accountType == typeof(TransactionAccount))
            {
                accountNumber = "TR0000" + accountId;
            }
            else if (accountType == typeof(DepositAccount))
            {
                accountNumber = "DP0000" + accountId;
            }
            else if (accountType == typeof(LoanAccount))
            {
                accountNumber = "LN0000" + accountId;
            }
            return accountNumber;
        }
    }
}
