using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.src
{
    public class Payment: Objects
    {
        private double _total;
        public double _inserted;
        public double _change;

        private double _bank;

        public double Total
        {
            get
            {
                return _total;
            }
            set
            {
                _total = value;
                OnPropertyChanged("Total");
            }
        }

        public double Inserted
        {
            get
            {
                return _inserted;
            }
            set
            {
                _inserted = value;
                OnPropertyChanged("Inserted");
            }
        }

        public double Change
        {

            get
            {
                return _change;
            }


            set
            {
                _change = value;
                OnPropertyChanged("Change");
            }
        }

        public double BankTotal
        {
            get
            {
                return _bank;
            }
            set
            {
                _bank = value;
                OnPropertyChanged("BankTotal");
            }
        }

        public void PaymentView()
        {
            Total = 0;
            Inserted = 0;
            Change = 0;
            BankTotal = 0;
        }

        public void Insert(double money)
        {
            Inserted += money;
        }

        public void SelectedPrice(double price)
        {
            Total = price;
        }
        
        public bool Confirm()
        {
            if(Inserted >= Total)
            {
                return true;
            }
            return false;
        }

        public void Pay()
        {
            Change = Inserted - Total;
            BankTotal += Total;
            Inserted = 0;
            Total = 0;
        }

        public void Collect()
        {
            Console.WriteLine("Payments: " + BankTotal);
            Change = 0;
        }
    }
}
