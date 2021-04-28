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
            BalanceChanged.Invoke("Sub", new EventArgs());
        }
    }
}
