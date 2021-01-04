using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.src
{
    public class MachineView : Objects
    {
        public ObservableCollection<ItemView> itemViews { get; private set; }
        public Payment payment { get; private set; }

        public MachineView()
        {
            payment = new Payment();
            itemViews = new ObservableCollection<ItemView>()
            {
                new ItemView(0, "Cola", 0.50),
                new ItemView(2, "Fanta", 0.30),
                new ItemView(3, "Domino", 1.50),
                new ItemView(4, "Raffaello", 2.50),
                new ItemView(5, "Riffle", 3.50),

            };
        }
        public void Purchase(object item)
        {
            var requestedItem = item as ItemView;
            payment.SelectedPrice(requestedItem.info.Price);

            if (payment.Confirm())
            {
                if (requestedItem.Reduce())
                {
                    payment.Pay();
                    Console.WriteLine("Payment");
                }
            }
        }

        public void InsertChange(double money)
        {
            payment.Insert(money);
        }

        public void CollectMoney()
        {
            payment.Collect();
        }

        public void Refill()
        {
            foreach (var i in itemViews)
            {
                i.ReFill();
            }
            Console.WriteLine("Machine refilled.");
        }

        public void Empty()
        {
            foreach (var i in itemViews)
            {
                i.Empty();
            }
            Console.WriteLine("Machine emptied.");
        }
    }
}
