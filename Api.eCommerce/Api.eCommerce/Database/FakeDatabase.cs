using Library.eCommerce.DTO;
using Library.eCommerce.Models;

namespace Api.eCommerce.Database
{
    public static class FakeDatabase
    {
        private static List<Item?> inventory = new List<Item?>
        {
            new Item{ Product = new ProductDTO{Id = 1, Name ="Product 1 web"}, Id = 1, Quantity = 10},
            new Item{ Product = new ProductDTO{Id = 2, Name ="Product 2 web"}, Id = 2, Quantity = 20},
            new Item{ Product = new ProductDTO{Id = 3, Name ="Product 3 web"}, Id = 3, Quantity = 30}
        };

        public static List<Item?> Inventory
        {
            get 
            {
                return inventory;
            }
        }

        
    }
}
