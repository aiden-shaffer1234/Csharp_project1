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
            int lastkey = 0;
            Console.WriteLine("Welcome to Amazon!");

            //Console.WriteLine("C. Create new intentory item");
            //Console.WriteLine("R. Read all intentory items");
            //Console.WriteLine("U. Update an intentory item");
            //Console.WriteLine("D. Delete an intentory item");
            //Console.WriteLine("Q. Quit");

            List<Product?> list = ProductServiceProxy.Current.Products; // shallow copy
            //var random = new Random();
            char choice;


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
                        var name = Console.ReadLine();
                        list.Add(new Product
                        {
                            Id = lastkey++,
                            Name = name
                        }); 
                        break;
                    case 'R':
                        list.ForEach(Console.WriteLine);
                        break;
                    case 'U':
                        Console.WriteLine("which product would you like to update?");
                        int select = int.Parse(Console.ReadLine() ?? "-1");
                        var selectedProd = list.FirstOrDefault(p => p.Id == select);
                        if (selectedProd != null)
                        {
                            Console.WriteLine("Enter new product name");
                            selectedProd.Name = Console.ReadLine() ?? "Error";
                        }
                        break;
                    case 'D':
                        Console.WriteLine("which product would you like to remove?");
                        select = int.Parse(Console.ReadLine() ?? "-1");
                        selectedProd = list.FirstOrDefault(p => p.Id == select);
                        list.Remove(selectedProd);
                        break;
                    default:
                        break;
                }
            } while (choice != 'Q');

        }
    }
}
