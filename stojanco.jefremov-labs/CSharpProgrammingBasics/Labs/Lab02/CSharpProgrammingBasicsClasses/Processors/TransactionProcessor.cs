using CSharpProgrammingBasics.Classes.Common;
using CSharpProgrammingBasics.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProgrammingBasics.Classes.Processors
{
    /// <summary>
    /// 
    /// </summary>
    public class TransactionProcessor:ITransactionProcessor
    {
        /// <summary>
        ///For Transfer type of transaction the DebitAmount method is called on the account passed in the accountFrom parameter and the CreditAmount method is called on the account passed in the accountTo parameter.
        ///For Debit type of transaction the DebitAmount method is called on the account passed in the AccountFrom parameter.
        ///For Credit type of transaction the CreditAmount method is called on the account passed in the AccountFrom parameter.
        /// </summary>
        /// <param name="transactionType"></param>
        /// <param name="amount"></param>
        /// <param name="accountFrom"></param>
        /// <param name="accountTo"></param>
        /// <returns></returns>
        public TransactionStatus ProcessTransaction(TransactionType transactionType, 
            CurrencyAmount amount, IAccount accountFrom, IAccount accountTo)
        {
            TransactionStatus transactionStatus = TransactionStatus.InProcess;
            switch (transactionType)
            {
                //TODO Should not we check the return value of DebitAmount and CreditAmount methods???
                case TransactionType.Transfer:
                    transactionStatus = accountFrom.DebitAmount(amount);
                    if (transactionStatus == TransactionStatus.Completed)
                    {
                        transactionStatus = accountTo.CreditAmount(amount);
                    }
                    else
                    {
                        break;
                    }
                    break;
                case TransactionType.Debit:
                    transactionStatus = accountFrom.DebitAmount(amount);
                    break;
                case TransactionType.Credit:
                    transactionStatus = accountFrom.CreditAmount(amount);
                    break;
                default:
                    transactionStatus = TransactionStatus.Failed;
                    break;
            }
            return transactionStatus;
        }
    }
}
