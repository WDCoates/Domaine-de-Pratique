using System;
using DBank;

namespace Mars
{

    using BankOfVenus;

    public class Banks
    {
        static void Main()
        {
            IAccount vGoldAccount = new GoldAccount();
            IAccount vSaverAccount = new SaverAccount();

            ITransferAccount vCurAccount = new CurrentAccount();
            
            vGoldAccount.Credit(10000);
            vSaverAccount.Credit(100);

            Console.WriteLine($"Gold Account Balance {vGoldAccount.Balance,6:C}");
            Console.WriteLine(vSaverAccount.ToString());

            vSaverAccount.Debit(1000);


            IAccount[] allAccounts = new IAccount[2];
            allAccounts[0] = vGoldAccount;
            allAccounts[1] = vSaverAccount;

            //Dividend...
            foreach (IAccount Acc in allAccounts)
            {
                Acc.Credit(10);
            }


            vCurAccount.Transfer(vSaverAccount, vCurAccount);

        }
    }

}

namespace DBank
{
    /// <summary>
    /// Base Interface
    /// </summary>
    public interface IAccount
    {
        bool Credit(decimal credit);
        bool Debit(decimal debit);
        decimal Balance { get; }

    }

    public interface ITransferAccount : IAccount
    {
        bool Transfer(IAccount sourceAccount, IAccount targetAccount);
    }
}

namespace BankOfVenus
{
    using DBank;

    public class CurrentAccount : ITransferAccount
    {
        private decimal balance;
        public decimal Balance => balance;

        public bool Credit(decimal credit)
        {
            balance += credit;
            return true;
        }

        public bool Debit(decimal debit)
        {
            balance =- debit;
            return true;
        }

        public bool Transfer(IAccount sourceAccount, IAccount targetAccount)
        {
            decimal TranAmount = sourceAccount.Balance;
            try
            {
                targetAccount.Credit(TranAmount);
                sourceAccount.Debit(TranAmount);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            
        }
    }

    public class GoldAccount : SaverAccount
    {
        public override bool Credit(decimal credit)
        {
            if (credit > 1000)
                balance += (credit + 10);
                    else
                balance += credit;

            return true;
        }
        public override string ToString()
        {
            return $"Bank Of Venus Gold: Balance = {balance,6:C}";
        }
    }

    /// <inheritdoc />
    public class SaverAccount : IAccount
    {
        protected decimal balance;
        public decimal Balance => balance;

        public virtual bool Credit(decimal credit)
        {
            balance += credit;
            return true;
        }

        public bool Debit(decimal debit)
        {
            if (balance >= debit)
            {
                balance -= debit;
                return true;
            }
            else
            {
                Console.WriteLine($"This is not OK, ammount £{debit} to high.");
                return false;
            }

        }

        public override string ToString()
        {
            return $"Bank Of Venus Saver: Balance = {balance,6:C}";
        }
    }
}
