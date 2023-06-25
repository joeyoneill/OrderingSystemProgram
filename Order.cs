// Inventory Name Space File
using System;
using System.Text;
using ItemSpace;

namespace OrderSpace {

    // List of Items
    public class Order {

        // Attributes
        public List<Item> ItemList = new List<Item>();
        private double subtotal;
        private string deliveryAddress;
        private string name;

        // Getters + Setters
        public string OrderAddress {
            get {return deliveryAddress;}
            set {deliveryAddress = value;}
        }
        public double OrderSubtotal {
            get {return subtotal;}
            set {subtotal = value;}
        }
        public string OrderName {
            get {return name;}
            set {name = value;}
        }

        // Constructor
        public Order(string orderName, string orderAddress) {
            name = orderName;
            deliveryAddress = orderAddress;
            subtotal = 0.0;
        }

        // Methods

        // Deletes Item From Order
        public int DeleteItemFromOrder() {

            // Check if Inventory is empty
            if (ItemList.Count == 0) {
                Console.WriteLine("There are currently no items in the order to delete.");
                
                // Failed Execution code
                return -1;
            }
            
            // Display the Inventory
            Console.WriteLine(ToString());

            // Prompt Item Price Input
            Console.WriteLine("Please Enter the Number for the Item you wish to Delete:\n");
            string? ItemNumber_input;
            Console.Write("Delete Item #> ");
            ItemNumber_input = Console.ReadLine();
            Console.WriteLine("-------------------------------------------");

            // Null Check
            if (ItemNumber_input == null) {
                Console.WriteLine("Input Error: Try again.");
                
                // Failed execution code
                return -1;
            }

            // Correct Input Check
            List<string> inv_nums = new List<string>();
            for (int i = 0; i < ItemList.Count; i++) {
                inv_nums.Add((i+1).ToString());
            }     
            if (!inv_nums.Contains(ItemNumber_input)) {
                Console.WriteLine("Incorrect Input: Please Enter a Listed Item Number");
                Console.WriteLine("Cancelling Transaction...");
                return -1;
            }
            
            // Try and Cast Input to Int
            int itemNumber;
            try {
                itemNumber = Int32.Parse(ItemNumber_input);
            }
            catch (Exception) {
                Console.WriteLine("Incorrect Input: Please Enter a Listed Item Number");
                Console.WriteLine("Cancelling Transaction...");
                return -1;
            }

            // Decrement for proper iteration number in list
            itemNumber--;

            // Remove the Item from list
            ItemList.Remove(ItemList[itemNumber]);

            // Confirmation Display message
            Console.WriteLine("Item was removed from order");

            // Successful Execution Code
            return 1;
        }

        // Calculates Subtotal
        public void CalculateSubtotal() {
            double total = 0.0;
            for (int i = 0; i < ItemList.Count; i++) {
                total += ItemList[i].ItemPrice;
            }
            
            subtotal = total;
        }

        // Returns String value of list for display
        public override string ToString() {
            StringBuilder s = new StringBuilder(
                "-------------------------------------------\nOrder Item List:\n-------------------------------------------"
            );
            s.Append("\nOrder Name: " + name + "\nOrder Address: " + deliveryAddress);
            s.Append("\nOrder Total: $" + subtotal);
            s.Append("\n-------------------------------------------");
            for (int i = 0; i < ItemList.Count; i++) {
                s.Append("\n" + (i+1) + " - " + ItemList[i].ToString() + "\n");
            }
            s.Append("-------------------------------------------");
            return s.ToString();
        }

    }
}