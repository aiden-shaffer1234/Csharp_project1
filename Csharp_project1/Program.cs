using System;
using System.Xml.Serialization;
using Csharp_project1.Models;
using Library.eCommerce.Services;


namespace Csharp_project1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char choice;
            do
            {
                Console.WriteLine("Welcome to Amazon!");
                Console.WriteLine("Choose user type:");
                Console.WriteLine("1. Seller");
                Console.WriteLine("2. Buyer");

                string? input = Console.ReadLine();
                choice = input != null && input.Length > 0 ? input[0] : ' ';
            } while (choice != '1' && choice != '2');

            List<Product?> list = ProductServiceProxy.Current.Products; // shallow copy
                                                                        //var random = new Random();



            if (choice == '1') { 
                do {
                    Console.WriteLine("C. Create new intentory item");
                    Console.WriteLine("R. Read all intentory items");
                    Console.WriteLine("U. Update an intentory item");
                    Console.WriteLine("D. Delete an intentory item");
                    Console.WriteLine("Q. Quit");
                    string? input = Console.ReadLine();
                    choice = input != null && input.Length > 0 ? char.ToUpper(input[0]) : ' ';

                    switch (choice) 
                    {
                        case 'C':
                            string? name;
                            double? price;
                            do
                            {
                                Console.WriteLine("Type name");
                                name = Console.ReadLine();
                                Console.WriteLine("Type Price (USD)");
                                string? priceInput = Console.ReadLine();

                                // TryParse to handle invalid inputs
                                bool isValidPrice = double.TryParse(priceInput, out double parsedPrice);
                                price = isValidPrice ? parsedPrice : null;

                                //write error messages another time
                            } while (string.IsNullOrEmpty(name) || price  == null);

                            ProductServiceProxy.Current.AddOrUpdateProduct(new Product
                            {
                                Id = 0,
                                Name = name,
                                Price = Math.Round((double)price, 2),

                            }); 
                            break;
                        case 'R':
                            Console.WriteLine("\n");
                            list.ForEach(Console.WriteLine);
                            break;
                        case 'U':
                            Console.WriteLine("which product would you like to update?");
                            int select = int.Parse(Console.ReadLine() ?? "-1");
                            var selectedProd = list.FirstOrDefault(p => p.Id == select);
                            if (selectedProd != null)
                            {
                                do
                                {
                                    Console.WriteLine("Type updated name");
                                    name = Console.ReadLine();
                                    Console.WriteLine("Type updated price (USD)");
                                    string? priceInput = Console.ReadLine();

                                    // TryParse to handle invalid inputs
                                    bool isValidPrice = double.TryParse(priceInput, out double parsedPrice);
                                    price = isValidPrice ? parsedPrice : null;

                                    //write error messages another time
                                } while (string.IsNullOrEmpty(name) || price == null);

                                selectedProd.Name = name;
                                selectedProd.Price = Math.Round((double)price, 2);
                            }
                            break;
                        case 'D':
                            Console.WriteLine("which product would you like to remove?");
                            list.ForEach(Console.WriteLine);
                            select = int.Parse(Console.ReadLine() ?? "-1");
                            selectedProd = list.FirstOrDefault(p => p.Id == select);
                            ProductServiceProxy.Current.Remove(selectedProd);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please choose again.");
                            break;
                    }
                } while (choice != 'Q');
            }
            else { 
            
            
            
            
            }

        }
    }
}
