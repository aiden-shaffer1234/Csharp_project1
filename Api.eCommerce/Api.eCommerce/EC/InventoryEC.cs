using Api.eCommerce.Database;
using Library.eCommerce.DTO;
using Library.eCommerce.Models;

namespace Api.eCommerce.EC
{
    public class InventoryEC
    {
        public List<Item?> Get()
        {
            return FakeDatabase.Inventory;
        }

        public Item? Delete(int id)
        {
            var itemToDelete = FakeDatabase.Inventory.FirstOrDefault(i=> i.Id == id);
            if (itemToDelete != null)
            {
                FakeDatabase.Inventory.Remove(itemToDelete);
            }

            return itemToDelete;
        }


        //public Item? Edit(int id, string name, int quant, double price)
        //{
        //    var itemToEdit = FakeDatabase.Inventory.FirstOrDefault(i => i.Id == id);
        //    var index = FakeDatabase.Inventory.IndexOf(itemToEdit);
        //    if (itemToEdit != null && index != -1)
        //    {
        //        FakeDatabase.Inventory.Remove(itemToEdit);
        //        FakeDatabase.Inventory.Insert(id, new Item
        //        {
        //            Id = id,
        //            Quantity = quant,
        //            Product = new ProductDTO
        //            {
        //                Name = name,
        //                Id = id,
        //                Price = price
        //            }
        //        });
        //    }

        //    return itemToEdit;
        //}
    }
}
