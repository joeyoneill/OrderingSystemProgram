// Item Class Name Space File
using System;

namespace ItemSpace {

    // Individual Orderable Items
    public class Item {

        // Attributes
        private string name;
        private double price;

        // Constructor
        public Item(string itemName, double itemPrice) {
            name = itemName;
            price = itemPrice;
        }

        // Getters + Setters
        public string ItemName {
            get {return name;}
            set {name = value;}
        }
        public double ItemPrice {
            get {return price;}
            set {price = value;}
        }

        // methods

        // Returns String value describing item for display
        public override string ToString() {
            return "Item Name: " + name + "\tItem Price: $" + price;
        }

        // Checks if two objects equal eachother
        public bool equals(Item otherItem) {
            if ((otherItem.ItemName == name) && (otherItem.ItemPrice == price))
                return true;
            else
                return false;
        }

    }
}