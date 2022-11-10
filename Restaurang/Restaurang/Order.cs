using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class Order
    {
        public List<Food> FoodOrder = new List<Food>(); 
        public Table Table { get; set; }
        public Waiter Waiter { get; set; }
        public Chef Chef { get; set; }
        public int OrderId { get; set; }

        public int OrderedAt { get; set; }
        public int CookedAt { get; set; }

        public Order()
        {
            
        }

        public Order(List<Food> foodOrder, Table table, Waiter waiter, int timeCounter, int orderId)
        {
            FoodOrder = foodOrder;
            Table = table;
            Waiter = waiter;
            OrderedAt = timeCounter;
            OrderId = orderId;
        }
    }
}
