/* Ordering System Project - Learning Objective 1
 * Code by Joey O'Neill
 * 06.2023
*/

// Main Driver File
using System;
using ItemSpace;
using InventorySpace;
using OrderSpace;
using OrderListSpace;

namespace ProgramSpace {
    internal class Program {
        static void Main(String[] args) {
            mainDriver();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////

        // Main Functionality and Display Driver
        public static void mainDriver() {

            // Inventory + Order List Initialization
            Inventory inventory = new Inventory();
            OrderList orders = new OrderList();

            // Entry Display Message
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine(" Welcome to the Inventory and Delivery App ");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("-------------------------------------------");

            // Main Driver Loop
            while (true) {

                // Menu Selection Display
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("(1) - Create a Takeout Order");
                Console.WriteLine("(2) - Create a Delivery Order");
                Console.WriteLine("(3) - Display Inventory");
                Console.WriteLine("(4) - Add Item to Inventory");
                Console.WriteLine("(5) - Delete Item from Inventory");
                Console.WriteLine("(6) - Display All Orders");
                Console.WriteLine("(0) - Exit\n");
                Console.Write("Option #> ");

                // Menu Selection Input
                string? selection_input;
                try {
                    selection_input = Console.ReadLine();
                }
                catch (Exception e) {
                    Console.WriteLine("Input Error: Try again.");
                    Console.WriteLine(e);
                    continue;
                }
                Console.WriteLine("-------------------------------------------");

                // selection_input null catcher
                if (selection_input == null) {
                    Console.WriteLine("Input Error: Try again.");
                    Console.WriteLine("-------------------------------------------");
                    continue;
                }

                // Case Statement
                switch (selection_input) {
                    case "0":
                        // Exit Display Message + Exit App
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("             See you next time             ");
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("-------------------------------------------");
                        Environment.Exit(0);
                        break;
                    case "1":
                        // Takeout Order Option
                        TakeoutOrderDriver(orders: ref orders, inventory: ref inventory);
                        Console.WriteLine("-------------------------------------------");
                        break;
                    case "2":
                        // Delivery Order Option
                        DeliveryOrderDriver(orders: ref orders, inventory: ref inventory);
                        Console.WriteLine("-------------------------------------------");
                        break;
                    case "3":
                        // Display Inventory Option
                        if (inventory.ItemList.Count == 0) {
                            Console.WriteLine("There are currently no items in inventory");
                        }
                        else {
                            Console.WriteLine(inventory.ToString());
                        }
                        Console.WriteLine("-------------------------------------------");
                        break;
                    case "4":
                        // Add Item to Inventory Option
                        AddItemDriver(ref inventory);
                        Console.WriteLine("-------------------------------------------");
                        break;
                    case "5":
                        // Delete Item From Inventory Option
                        DeleteItemDriver(ref inventory);
                        Console.WriteLine("-------------------------------------------");
                        break;
                    case "6":
                        // Display Order List orders
                        if (orders.orderList.Count > 0)
                            Console.WriteLine(orders.ToString());
                        else {
                            Console.WriteLine("There are no orders currently saved");
                            Console.WriteLine("-------------------------------------------");
                        }
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option!");
                        Console.WriteLine("-------------------------------------------");
                        break;
                }
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////

        // Functionality Driver For Creating a Takeout Order
        public static int TakeoutOrderDriver(ref OrderList orders, ref Inventory inventory) {
            
            // Get Name For Order
            string? name_input;
            Console.WriteLine("Please Enter a Name for the Order:\n");
            Console.Write("Order Name Entry #> ");
            name_input = Console.ReadLine();
            Console.WriteLine("-------------------------------------------");

            // name_input null catcher
            if (name_input == null) {
                Console.WriteLine("Input Error");
                Console.WriteLine("Cancelling Transaction...");
                Console.WriteLine("-------------------------------------------");
                return -1;
            }
            
            // Order Driver Functionality Function
            OrderDriver(orders: ref orders, inventory: ref inventory, address: "TAKEOUT", name: name_input);

            return 1;
        }

        // Functionality Driver For Creating a Delivery Order
        public static int DeliveryOrderDriver(ref OrderList orders, ref Inventory inventory) {
            // Get Name For Order
            string? name_input;
            Console.WriteLine("Please Enter a Name for the Order:\n");
            Console.Write("Order Name Entry #> ");
            name_input = Console.ReadLine();
            Console.WriteLine("-------------------------------------------");

            // Get Address For Order
            string? address_input;
            Console.WriteLine("Please Enter an Address for Delivery:\n");
            Console.Write("Order Address Entry #> ");
            address_input = Console.ReadLine();
            Console.WriteLine("-------------------------------------------");

            // name_input null catcher
            if ((name_input == null) || (address_input == null)) {
                Console.WriteLine("Input Error");
                Console.WriteLine("Cancelling Transaction...");
                Console.WriteLine("-------------------------------------------");
                return -1;
            }

            // Order Driver Function
            OrderDriver(orders: ref orders, inventory: ref inventory, address: address_input, name: name_input);
            
            return 1;
        }

        // Functionality Driver For Adding an Item to Inventory
        public static int AddItemDriver(ref Inventory inventory) {
            // Prompt Item Name Input
            Console.WriteLine("Please Enter the Name of the Item:\n");
            string? ItemName_input;
            Console.Write("Item Name #> ");
            ItemName_input = Console.ReadLine();
            Console.WriteLine("-------------------------------------------");

            // Prompt Item Price Input
            Console.WriteLine("Please Enter the Price of the Item:\n");
            string? ItemPrice_input;
            Console.Write("Item Price #> $");
            ItemPrice_input = Console.ReadLine();
            
            // Null Check to Quiet Warning
            if ((ItemName_input == null) || (ItemPrice_input == null)) {
                Console.WriteLine("Input Error: Try again.");
                Console.WriteLine("-------------------------------------------");
                
                // Failed execution code
                return -1;
            }
            else {
                
                // Variable Initialization
                Double itemPrice_double;

                // Check to ensure double value entered
                try {
                    // Cast Price to Double
                    itemPrice_double = Double.Parse(ItemPrice_input);
                }
                catch (Exception) {
                    Console.WriteLine("\nInput Error: Please Enter Numeric Dollar Amount\nCancelling Transaction...");
                    Console.WriteLine("-------------------------------------------");

                    // Failed Execution Code
                    return -1;
                }

                // Create Item + Add to Inventory
                Item item = new Item(itemName: ItemName_input, itemPrice: itemPrice_double);
                inventory.ItemList.Add(item);

                // Successful Execution Code
                return 1;
            }
        }

        // Functionality Driver For Deleting an Item From Inventory
        public static int DeleteItemDriver(ref Inventory inventory) {

            // Check if Inventory is empty
            if (inventory.ItemList.Count == 0) {
                Console.WriteLine("There are currently no items in the inventory to delete.");
                
                // Failed Execution code
                return -1;
            }
            
            // Display the Inventory
            Console.WriteLine(inventory.ToString());

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
            for (int i = 0; i < inventory.ItemList.Count; i++) {
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
            inventory.ItemList.Remove(inventory.ItemList[itemNumber]);

            // Confirmation Display message
            Console.WriteLine("Item was removed from inventory");

            // Successful Execution Code
            return 1;
        }
    
        ///////////////////////////////////////////////////////////////////////////////////////////
    
        // Universal Order Driver
        public static int OrderDriver(ref OrderList orders, ref Inventory inventory, string address, string name) {
            
            // Initialize Order
            Order order = new Order(orderName: name, orderAddress: address);

            // Order Menu Driver Loop
            while (true) {
                // Menu Selection Display
                // Display Order if at least 1 item is in it
                if (order.ItemList.Count > 0)
                    Console.WriteLine(order.ToString());
                else {
                    Console.WriteLine("Order for " + name + "\nOrder to: " + address);
                    Console.WriteLine("-------------------------------------------");
                }

                Console.WriteLine("What would you like to do?");
                Console.WriteLine("(1) - Add Item to Order");
                Console.WriteLine("(2) - Delete Item from Order");
                Console.WriteLine("(3) - Save Order");
                Console.WriteLine("(0) - Exit to Menu\n");
                Console.Write("Order Creation Option #> ");
                
                // Menu Selection Input
                string? selection_input = Console.ReadLine();
                Console.WriteLine("-------------------------------------------");

                // selection_input null catcher
                if (selection_input == null) {
                    Console.WriteLine("Input Error: Try again.");
                    Console.WriteLine("-------------------------------------------");
                    continue;
                }

                // Switch statement for order menu selection
                switch (selection_input) {
                    case "0":
                        // exit to menu
                        Console.WriteLine("Exiting to Main Menu...");
                        return 1;
                    case "1":
                        // Add Item to Order
                        // Display Inventory
                        Console.WriteLine(inventory.ToString());
                        Console.WriteLine("-------------------------------------------");

                        // Prompt Item Entry
                        Console.WriteLine("Please Enter the Number for the Item you wish to Add:\n");
                        string? ItemNumber_input;
                        Console.Write("Add Item to Order #> ");
                        ItemNumber_input = Console.ReadLine();
                        Console.WriteLine("-------------------------------------------");

                        // Check Input
                        // Null Check
                        if (ItemNumber_input == null) {
                            Console.WriteLine("Input Error: Cancelling Item Addition...");
                            Console.WriteLine("-------------------------------------------");
                            continue;
                        }

                        // Correct Input Check
                        List<string> inv_nums = new List<string>();
                        for (int i = 0; i < inventory.ItemList.Count; i++) {
                            inv_nums.Add((i+1).ToString());
                        }     
                        if (!inv_nums.Contains(ItemNumber_input)) {
                            Console.WriteLine("Incorrect Input: Please Enter a Valid Item Number");
                            Console.WriteLine("Cancelling Item Addition...");
                            Console.WriteLine("-------------------------------------------");
                            continue;
                        }
                        
                        // Try and Cast Input to Int
                        int itemNumber;
                        try {
                            itemNumber = Int32.Parse(ItemNumber_input);
                        }
                        catch (Exception) {
                            Console.WriteLine("Incorrect Input: Please Enter a Listed Item Number");
                            Console.WriteLine("Cancelling Transaction...");
                            Console.WriteLine("-------------------------------------------");
                            continue;
                        }

                        // Decrement for proper iteration number in list
                        itemNumber--;

                        // Add item to order
                        order.ItemList.Add(inventory.ItemList[itemNumber]);
                        order.CalculateSubtotal();
                        Console.WriteLine(inventory.ItemList[itemNumber].ItemName + " added to order.");
                        Console.WriteLine("-------------------------------------------");
                        
                        break;
                    case "2":
                        // Delete Item from Order
                        order.DeleteItemFromOrder();
                        order.CalculateSubtotal();
                        break;
                    case "3":
                        // Save Order
                        orders.orderList.Add(order);
                        Console.WriteLine("Order Saved Order List.");
                        return 1;
                    default:
                        Console.WriteLine("Please enter a valid option!");
                        Console.WriteLine("-------------------------------------------");
                        break;
                }
            }
        }
    }
}