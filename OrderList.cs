// Inventory Name Space File
using System;
using System.Text;
using ItemSpace;
using OrderSpace;

namespace OrderListSpace {

    // List of Items
    public class OrderList {

        // Attributes
        public List<Order> orderList = new List<Order>();

        // Methods

        // Returns String value of list for display
        public override string ToString() {
            StringBuilder s = new StringBuilder(
                "-------------------------------------------\nOrders List:\n-------------------------------------------\n"
            );
            s.Append("-------------------------------------------\n");
            for (int i = 0; i < orderList.Count; i++) {
                s.Append("\nORDER #" + (i+1) + "\n" + orderList[i].ToString() + "\n");
            }
            s.Append("-------------------------------------------");
            return s.ToString();
        }

    }
}