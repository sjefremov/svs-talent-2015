using CSharpProgrammingBasics.Classes.Common;
using CSharpProgrammingBasics.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProgrammingBasics.Classes.Accounts
{
    /// <summary>
    /// 
    /// </summary>
    public class TransactionAccount:Account, ITransactionAccount
    {
        private CurrencyAmount _limit;
        /// <summary>
        /// 
        /// </summary>
        public CurrencyAmount Limit
        {
            get { return _limit; }
            private set { _limit = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="limitAmount"></param>
        public TransactionAccount(string currency, decimal limitAmount):base(currency)
        {
            CurrencyAmount tempAmount = this.Limit;
            tempAmount.Amount = limitAmount;
            tempAmount.Currency = currency;
            this.Limit = tempAmount;
        }
    }
}
