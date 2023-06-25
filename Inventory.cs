// Inventory Name Space File
using System;
using System.Text;
using ItemSpace;

namespace InventorySpace {

    // List of Items
    public class Inventory {

        // Attributes
        public List<Item> ItemList = new List<Item>();

        // Methods

        // Returns String value of list for display
        public override string ToString() {
            StringBuilder s = new StringBuilder(
                "-------------------------------------------\nInventory List:\n-------------------------------------------"
            );
            for (int i = 0; i < ItemList.Count; i++) {
                s.Append("\n" + (i+1) + " - " + ItemList[i].ToString() + "\n");
            }
            s.Append("-------------------------------------------");
            return s.ToString();
        }

    }
}