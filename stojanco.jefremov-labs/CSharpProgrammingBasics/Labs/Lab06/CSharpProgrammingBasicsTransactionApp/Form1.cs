using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpProgrammingBasics.Classes.Accounts;
using CSharpProgrammingBasics.Classes.Common;
using CSharpProgrammingBasics.Classes.Interfaces;
using CSharpProgrammingBasics.Classes.Processors;

namespace CSharpProgrammingBasicsTransactionApp
{
    public partial class frmMain : Form
    {
        private TransactionAccount _transactionAccount = null;
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnCreateTransactionAccount_Click(object sender, EventArgs e)
        {
            _transactionAccount = new TransactionAccount(txtAccountCurrency.Text, Decimal.Parse(txtAccountLimit.Text));
            this.PopulateTransactionAccountLabels(_transactionAccount);
            //this.PopulateTransactionAccountLabels(_transactionAccount);
        }
        /// <summary>
        /// Receives a parameter of type Account and populates the Account common labels.
        /// </summary>
        /// <param name="account"></param>
        private void PopulateAccountLabels(IAccount account)
        {
            lblAccountIdValue.Text = account.Id.ToString();
            lblAccountNumberValue.Text = account.Number;
            lblAccountCurrencyValue.Text = account.Currency;
            lblAccountBalanceValue.Text = account.Balance.Amount.ToString();
        }
        /// <summary>
        /// Receives a parameter of type Account and populates the Account_To common labels.
        /// </summary>
        /// <param name="account"></param>
        private void PopulateAccount_ToLabels(IAccount account)
        {
            lbl_ToAccountIdValue.Text = account.Id.ToString();
            lbl_ToAccountNumberValue.Text = account.Number;
            lbl_ToAccountCurrencyValue.Text = account.Currency;
            lbl_ToAccountBalanceValue.Text = account.Balance.Amount.ToString();
        }
        /// <summary>
        /// Checks if the account parameter is a TransactionAccount and if this is true will populate the TransactionAccount specific labels.
        /// Otherwise it will clear the TransactionAccount specific labels.
        /// </summary>
        /// <param name="account"></param>
        private void PopulateTransactionAccountLabels(IAccount account)
        {
            if (account.GetType() == typeof(TransactionAccount))
            {
                ITransactionAccount transactionAccount = (TransactionAccount)account;
                lblTransactionAccountLimitValue.Text = transactionAccount.Limit.Amount.ToString();
                lblTransactionAccountLimitCurrencyValue.Text = transactionAccount.Limit.Currency;
                this.PopulateAccountLabels(account);
            }
            else
            {
                lblTransactionAccountLimitValue.Text = "";
                lblTransactionAccountLimitCurrencyValue.Text = "";
            }            
        }

        private void btnCreateDepositAccount_Click(object sender, EventArgs e)
        {
            DepositAccount depositAccount = this.CreateDepositAccount();
            this.populateDepositAccountLabels(depositAccount);
        }
        /// <summary>
        /// Returns new instance of the DepositAccount class created from the values entered from the user.
        /// </summary>
        /// <returns></returns>
        private DepositAccount CreateDepositAccount()
        {
            DepositAccount depositAccount = this.CreateAccount<DepositAccount>(_transactionAccount);
            return depositAccount;
        }

        /// <summary>
        /// Returns new instance of the LoanAccount class created from the values entered from the user.
        /// </summary>
        /// <returns></returns>
        private LoanAccount CreateLoanAccount()
        {
            LoanAccount loanAccount = this.CreateAccount<LoanAccount>(_transactionAccount);
            return loanAccount;
        }
        /// <summary>
        /// If the passed type is not DepositAccount or LoanAccount it will return the default value for that type.
        /// </summary>
        /// <typeparam name="AccountType"></typeparam>
        /// <param name="transactionAccount"></param>
        /// <returns></returns>
        private AccountType CreateAccount<AccountType>(TransactionAccount transactionAccount) where AccountType:DepositAccount
        {
            AccountType createdAccount = default(AccountType);
            TimePeriod depositPeriod = new TimePeriod();
            //TODO Should not we calculate the period from difference between startDate and endDate instead of entering it.
            depositPeriod.Period = Int32.Parse(txtDepositAccountPeriodAmount.Text);
            depositPeriod.Unit = (UnitOfTime)cmbDepositAccountPeriodUnit.SelectedItem;
            InterestRate interestRate = new InterestRate();
            interestRate.Percent = Decimal.Parse(txtDepositAccountInterestPercent.Text);
            interestRate.Unit = (UnitOfTime)cmbDepositAccountInterestUnit.SelectedItem;
            if (typeof(AccountType) == typeof(DepositAccount))
            {
                createdAccount = new DepositAccount(txtAccountCurrency.Text,
                depositPeriod, interestRate, dtpDepositAccountStartDate.Value, dtpDepositAccountEndDate.Value,
                    transactionAccount) as AccountType;
            }
            else if (typeof(AccountType) == typeof(LoanAccount))
            {
                createdAccount = new LoanAccount(txtAccountCurrency.Text,
                depositPeriod, interestRate, dtpDepositAccountStartDate.Value, dtpDepositAccountEndDate.Value,
                    transactionAccount) as AccountType;
            }
            createdAccount.OnBalanceChanged += this.PrintBalanceChanged;
            return createdAccount;
        }
        /// <summary>
        /// Checks if the account parameter is a DepositAccount and if this is true will populate the DepositAccount specific labels.
        /// Otherwise it will clear the DepositAccount specific labels.
        /// </summary>
        /// <param name="account"></param>
        private void populateDepositAccountLabels(IAccount account)
        {
            if (account.GetType() == typeof(DepositAccount))
            {
                IDepositAccount depositAccount = (DepositAccount)account;
                lblDepositAccountEndDateValue.Text = depositAccount.EndDate.ToShortDateString();
                lblDepositAccountInterestPercentValue.Text = depositAccount.Interest.Percent.ToString();
                lblDepositAccountInterestUnitValue.Text = depositAccount.Interest.Unit.ToString();
                lblDepositAccountPeriodAmountValue.Text = depositAccount.Period.Period.ToString();
                lblDepositAccountPeriodUnitValue.Text = depositAccount.Period.Unit.ToString();
                lblDepositAccountStartDateValue.Text = depositAccount.StartDate.ToShortDateString();
                this.PopulateAccountLabels(depositAccount);
            }
            else
            {
                lblDepositAccountEndDateValue.Text = "";
                lblDepositAccountInterestPercentValue.Text = "";
                lblDepositAccountInterestUnitValue.Text = "";
                lblDepositAccountPeriodAmountValue.Text = "";
                lblDepositAccountPeriodUnitValue.Text = "";
                lblDepositAccountStartDateValue.Text = "";
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            foreach (UnitOfTime unit in Enum.GetValues(typeof(UnitOfTime)))
            {
                cmbDepositAccountInterestUnit.Items.Add(unit);
                cmbDepositAccountInterestUnit.SelectedIndex = 0;
                cmbDepositAccountPeriodUnit.Items.Add(unit);
                cmbDepositAccountPeriodUnit.SelectedIndex = 0;
            }
        }

        private void btnMakeTransaction_Click(object sender, EventArgs e)
        {
            ILoanAccount loanAccount = CreateLoanAccount();
            IDepositAccount depositAccount = CreateDepositAccount();
            ITransactionProcessor transactionProcessor = TransactionProcessor.GetTransactionProcessor();
            CurrencyAmount currencyAmmount = new CurrencyAmount();
            currencyAmmount.Amount = 20000;
            currencyAmmount.Currency = "MKD";
            TransactionStatus transactionStatus = transactionProcessor.ProcessTransaction(TransactionType.Transfer, currencyAmmount, loanAccount, depositAccount);
            if (transactionStatus == TransactionStatus.Completed)
            {
                this.DisplayLastTransactionDetails();
                this.populateDepositAccountLabels(depositAccount);
            }
            else
            {
                MessageBox.Show("Transaction was not completed because of transaction status = " + transactionStatus);
            }
        }

        private void btnMakeGroupTransaction_Click(object sender, EventArgs e)
        {
            IAccount[] accounts = new IAccount[2];
            IDepositAccount depositAccount = this.CreateDepositAccount();
            ILoanAccount loanAccount = this.CreateLoanAccount();
            accounts[0] = depositAccount;
            accounts[1] = loanAccount;
            ITransactionProcessor transactionProcessor = TransactionProcessor.GetTransactionProcessor();
            //TODO Should not we take the amount values from the user???
            CurrencyAmount currencyAmount = new CurrencyAmount();
            currencyAmount.Amount = 100000;
            currencyAmount.Currency = "MKD";
            //Testing cases
            //accounts = null;
            //accounts = new IAccount[2];
            //accounts[0] = null;
            //accounts[1] = null;
            TransactionStatus transactionStatus = transactionProcessor.ProcessGroupTransaction(TransactionType.Debit, currencyAmount, accounts);
            if (transactionStatus == TransactionStatus.Completed)
            {
                this.DisplayLastTransactionDetails();
            }
            else if (transactionStatus == TransactionStatus.Failed)
            {
                MessageBox.Show("Group Transaction was not completed because of transaction status = " + transactionStatus);
            }
            else
            {
                MessageBox.Show("Group Transaction was not fully completed because of transaction status = " + transactionStatus);
            }
        }
        /// <summary>
        /// Gets the last TransactionLogEntry from the transaction processor using the LastTransaction property and 
        /// displays the details in the appropriate labels as well as the transaction count.
        /// </summary>
        private void DisplayLastTransactionDetails()
        {
            TransactionProcessor transactionProcessor = TransactionProcessor.GetTransactionProcessor();
            int count = transactionProcessor.TransactionCount;
            TransactionLogEntry transactionLogEntry = transactionProcessor[count - 1];           
            lblTotalTransactionCountValue.Text = count.ToString();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("transactionType = " + transactionLogEntry.TransactionType.ToString());
            stringBuilder.Append("\namountCurrency = " + transactionLogEntry.Amount.Currency);
            stringBuilder.Append("\namountValue = " + transactionLogEntry.Amount.Amount.ToString());
            stringBuilder.Append("\nstatus = " + transactionLogEntry.Status.ToString());
            stringBuilder.Append("\nAccounts:");
            foreach (IAccount account in transactionLogEntry.Accounts)
            {
                stringBuilder.Append("\nId = " + account.Id + " Number = " + account.Number + " Balance = " + account.Balance.Amount + " Currency = " + account.Currency);
            }
            lblTransactionLogEntryDetailsValue.Text = stringBuilder.ToString();
        }
        /// <summary>
        /// Handler for the OnBalanceChanged event that prints a message with the event arguments details to the console output.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void PrintBalanceChanged(Object sender, BalanceChangedEventArguments eventArgs)
        {
            StringBuilder outputMessage = new StringBuilder();
            outputMessage.Append("\n\nBalance changed:\n");
            outputMessage.Append("AccountId: " + eventArgs.Account.Id);
            outputMessage.Append("\nAccountNumber: " + eventArgs.Account.Number);
            outputMessage.Append("\nAccountCurrency: " + eventArgs.Account.Currency);
            outputMessage.Append("\nAccountBalance.Amount: " + eventArgs.Account.Balance.Amount);
            outputMessage.Append("\nChange.Amount: " + eventArgs.Change.Amount);
            outputMessage.Append("\nChange.Currency: " + eventArgs.Change.Currency + "\n");
            Console.WriteLine(outputMessage.ToString());
        }
    }
}
