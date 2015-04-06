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
            //this.PopulateTransactionAccountLabels(account);
            //this.populateDepositAccountLabels(account);
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
            //this.PopulateTransactionAccountLabels(account);
            //this.populateDepositAccountLabels(account);
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
            TimePeriod depositPeriod = new TimePeriod();
            //TODO Should not we calculate the period from difference between startDate and endDate instead of entering it.
            depositPeriod.Period = Int32.Parse(txtDepositAccountPeriodAmount.Text);
            depositPeriod.Unit = (UnitOfTime)cmbDepositAccountPeriodUnit.SelectedItem;
            InterestRate interestRate = new InterestRate();
            interestRate.Percent = Decimal.Parse(txtDepositAccountInterestPercent.Text);
            interestRate.Unit = (UnitOfTime)cmbDepositAccountInterestUnit.SelectedItem;
            //TODO Where do we get from values for depositAccount.currency and depositAccount.TransactionAccount. Aren't we duplicating values for currency?
            DepositAccount depositAccount = new DepositAccount(txtAccountCurrency.Text,
                depositPeriod, interestRate, dtpDepositAccountStartDate.Value, dtpDepositAccountEndDate.Value,
                    _transactionAccount);
            return depositAccount;
        }

        /// <summary>
        /// Returns new instance of the DepositAccount class created from the values entered from the user.
        /// </summary>
        /// <returns></returns>
        private LoanAccount CreateLoanAccount()
        {
            TimePeriod depositPeriod = new TimePeriod();
            //TODO Should not we calculate the period from difference between startDate and endDate instead of entering it.
            depositPeriod.Period = Int32.Parse(txtDepositAccountPeriodAmount.Text);
            depositPeriod.Unit = (UnitOfTime)cmbDepositAccountPeriodUnit.SelectedItem;
            InterestRate interestRate = new InterestRate();
            interestRate.Percent = Decimal.Parse(txtDepositAccountInterestPercent.Text);
            interestRate.Unit = (UnitOfTime)cmbDepositAccountInterestUnit.SelectedItem;
            //TODO Where do we get from values for depositAccount.currency and depositAccount.TransactionAccount. Aren't we duplicating values for currency?
            LoanAccount loanAccount = new LoanAccount(txtAccountCurrency.Text,
                depositPeriod, interestRate, dtpDepositAccountStartDate.Value, dtpDepositAccountEndDate.Value,
                    _transactionAccount);
            return loanAccount;
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
            //ITransactionAccount transactionAccount = new TransactionAccount("MKD", 100000);
            //TimePeriod timePeriod = new TimePeriod();
            //timePeriod.Period = 1;
            //timePeriod.Unit = UnitOfTime.Year;
            //InterestRate interestRate = new InterestRate();
            //interestRate.Percent = 0.5M;
            //interestRate.Unit = UnitOfTime.Month;
            ILoanAccount loanAccount = CreateLoanAccount();
            IDepositAccount depositAccount = CreateDepositAccount();
            ITransactionProcessor transactionProcessor = new TransactionProcessor();
            CurrencyAmount currencyAmmount = new CurrencyAmount();
            currencyAmmount.Amount = 20000;
            currencyAmmount.Currency = "MKD";
            TransactionStatus transactionStatus = transactionProcessor.ProcessTransaction(TransactionType.Transfer, currencyAmmount, loanAccount, depositAccount);
            if (transactionStatus == TransactionStatus.Completed)
            {
                this.PopulateAccountLabels(loanAccount);
                this.PopulateAccount_ToLabels(depositAccount);
                this.populateDepositAccountLabels(depositAccount);
            }
            else
            {
                MessageBox.Show("Transaction was not completed because of transaction status = " + transactionStatus);
            }
        }
    }
}
