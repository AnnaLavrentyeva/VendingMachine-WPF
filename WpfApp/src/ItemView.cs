using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp.src
{
    public class ItemView: Objects
    {
        private Items _items;
        private const int _maxNum = 10;
        private int _curNum;

        public int Id
        {
            get
            {
                return _items.Id;
            }

        }

        public int Number
        {
            get
            {
                return _curNum;
            }
            private set
            {
                _curNum = value;
                OnPropertyChanged("OutOfItem");
                OnPropertyChanged("StorageDisplay");
                OnPropertyChanged("Number");
            }
        }

        public string StorageDisplay
        {
            get
            {
                return _items.Name + ": " + _curNum;
            }
        }

        public Items info
        {
            get
            {
                return _items;
            }
        }

        public Visibility OutOfItem
        {
            get
            {
                if(Number > 0)
                {
                    return Visibility.Hidden;
                }
                return Visibility.Visible;
            }
        }

        public ItemView(int id, string name, double price)
        {
            _items = new Items(id, name, price);
            Number = 0;
        }

        public int ReFill()
        {
            var amount = _maxNum - Number;
            Number += amount;
            return amount;
        }

        public int Empty()
        {
            var amount = Number;
            Number = 0;
            return amount;
        }

        public bool Reduce()
        {
            if(Number > 0)
            {
                Number--;
                return true;
            }
            return false;
        }
    }
}
