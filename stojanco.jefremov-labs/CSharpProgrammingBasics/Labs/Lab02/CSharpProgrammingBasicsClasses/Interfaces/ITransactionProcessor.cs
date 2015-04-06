using CSharpProgrammingBasics.Classes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProgrammingBasics.Classes.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITransactionProcessor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionType"></param>
        /// <param name="amount"></param>
        /// <param name="accountFrom"></param>
        /// <param name="accountTo"></param>
        /// <returns></returns>
        TransactionStatus ProcessTransaction(TransactionType transactionType, 
            CurrencyAmount amount, IAccount accountFrom, IAccount accountTo);
    }
}
