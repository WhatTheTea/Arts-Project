using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arts_Project
{
    public class Balance
    {
        private int have;
        private string currency;
        private bool negative;
        public string Currency
        {
            get
            {
                return currency;
            }
            set
            {
                currency = value;
                BalanceChanged.Invoke(Currency, new EventArgs());
            }
        }

        public int Have
        {
            get
            {
                return have;
            }
            set
            {
                have = value;
                BalanceChanged.Invoke(Have, new EventArgs());
            }
        }
        public bool Negative
        {
            get
            {
                return negative;
            }
            set
            {
                negative = value;
            }
        }

        public bool IsBalanceZero => have < 1;

        public event EventHandler BalanceChanged;

        public Balance() {
            have = 0;
            currency = "";
        }
        public Balance(int startingBalance)
        {
            have = startingBalance;
            currency = "";
        }
        public Balance(int startingBalance, string startingCurrency)
        {
            have = startingBalance;
            currency = startingCurrency;
        }
        public string StrToLabel() => "Баланс: " + have + " " + currency;
        public void Add(int num)
        {
            have += num;
            BalanceChanged.Invoke("Add", new EventArgs());
        }

        public void Sub(int num)
        {
            have -= num;
            if (IsBalanceZero && !Negative) have = 0;
            BalanceChanged.Invoke("Sub", new EventArgs());
        }
    }
}
