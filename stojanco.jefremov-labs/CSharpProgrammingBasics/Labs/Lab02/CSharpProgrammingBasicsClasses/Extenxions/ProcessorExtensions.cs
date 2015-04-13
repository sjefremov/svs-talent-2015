using CSharpProgrammingBasics.Classes.Common;
using CSharpProgrammingBasics.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProgrammingBasics.Classes.Extenxions
{
    public static class ProcessorExtensions
    {
        public static TransactionStatus ChargeProcessingFee(ITransactionProcessor processor,
            CurrencyAmount amount, IEnumerable<IAccount> accounts)
        {
            IAccount[] accountsArray = new IAccount[accounts.Count<IAccount>()];
            //TODO Here we have problems...
            //return processor.ProcessGroupTransaction(TransactionType.Debit, amount, accounts as Array);
            return TransactionStatus.Failed;
        }
    }
}
