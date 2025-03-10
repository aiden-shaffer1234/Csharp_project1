﻿using System;
using System.Diagnostics;
using System.Xml.Linq;
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
            Console.WriteLine("Welcome to Amazon!");
            do
            {
                Console.WriteLine("Choose user type:");
                Console.WriteLine("1. Seller");
                Console.WriteLine("2. Buyer");
                Console.WriteLine("3. Exit Shop");

                string? input = Console.ReadLine();
                choice = input != null && input.Length > 0 ? input[0] : ' ';

            List<Product?> list = ProductServiceProxy.Current.Products; // shallow copy
                                                                        //var random = new Random();
            List<Product?> cart = CartServiceProxy.Current.Cart;


            if (choice == '1') { 
                do {
                    Console.WriteLine("C. Create new intentory item");
                    Console.WriteLine("R. Read all intentory items");
                    Console.WriteLine("U. Update an intentory item");
                    Console.WriteLine("D. Delete an intentory item");
                    Console.WriteLine("Q. Quit");
                    input = Console.ReadLine();
                    choice = input != null && input.Length > 0 ? char.ToUpper(input[0]) : ' ';

                    switch (choice) 
                    {
                        case 'C':
                            string? name;
                            double? price;
                            int quantity;
                            do
                            {
                                Console.WriteLine("Type name");
                                name = Console.ReadLine();

                                Console.WriteLine("Type Price (USD)");
                                string? priceInput = Console.ReadLine();
                                Console.WriteLine("Set availible quantity");
                                string quantityInput = Console.ReadLine();
                                bool isValidQuantity = int.TryParse(quantityInput, out quantity);
                                quantity = isValidQuantity ? quantity : 0;

                                // TryParse to handle invalid inputs
                                bool isValidPrice = double.TryParse(priceInput, out double parsedPrice);
                                price = isValidPrice && parsedPrice > 0 ? parsedPrice : null;

                                //write error messages another time
                            } while (string.IsNullOrEmpty(name) || price == null || quantity <= 0);

                            ProductServiceProxy.Current.AddOrUpdateProduct(new Product
                            {
                                Id = 0,
                                Name = name,
                                Price = Math.Round((double)price, 2),
                                Quantity = quantity
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
                                    Console.WriteLine("Set availible quantity");
                                    string quantityInput = Console.ReadLine();
                                    bool isValidQuantity = int.TryParse(quantityInput, out quantity);
                                    quantity = isValidQuantity ? quantity : 0;

                                        // TryParse to handle invalid inputs
                                    bool isValidPrice = double.TryParse(priceInput, out double parsedPrice);
                                    price = isValidPrice ? parsedPrice : null;

                                    //write error messages another time
                                } while (string.IsNullOrEmpty(name) || price == null || quantity <= 0);

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
                        case 'Q':
                            Console.WriteLine("GoodBye!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please choose again.");
                            break;
                    }
                } while (choice != 'Q');
            }
            else if (choice == '2' ) 
                {
                    do
                    {
                        Console.WriteLine("R. Read all intentory items");
                        Console.WriteLine("A. Add item to cart");
                        Console.WriteLine("U. Update cart");
                        Console.WriteLine("D. Delete an item from cart");
                        Console.WriteLine("Q. Checkout");

                        input = Console.ReadLine();
                        choice = input != null && input.Length > 0 ? char.ToUpper(input[0]) : ' ';

                        switch (choice)
                        {
                            case 'R':
                                Console.WriteLine("\n");
                                list.ForEach(Console.WriteLine);
                                break;
                            case 'A':
                                Console.WriteLine("Choose what item you want to add to cart");
                                list.ForEach(Console.WriteLine);
                                int select;
                                string selectInput = Console.ReadLine();
                                bool isValidSelect = int.TryParse(selectInput, out select);
                                select = isValidSelect ? select : -1;
                                var selectedProd = list.FirstOrDefault(p => p.Id == select);
                                var selectedCartProd = cart.FirstOrDefault(p => p.Id == select);
                                if (selectedProd != null)
                                {
                                    Console.WriteLine("Quantity?");
                                    int quant = int.Parse(Console.ReadLine() ?? "0");
                                    if (selectedCartProd != null && selectedCartProd.Quantity + quant <= selectedProd.Quantity)
                                    {
                                        selectedProd.Quantity = quant + selectedCartProd.Quantity;
                                    }else if(quant > 0 && quant <= selectedProd.Quantity) {
                                        CartServiceProxy.Current.AddToCart(selectedProd, quant);
                                    } else {
                                        Console.WriteLine("Invalid Quantity. Could not complete addition");
                                    }
                                } else
                                {
                                    Console.WriteLine("invalid choice");
                                }

                                break;
                            case 'U':
                                if(cart.Count == 0)
                                {
                                    Console.WriteLine("\nCart is empty\n");
                                    break;
                                }
                                Console.WriteLine("which cart item would you like to update?");
                                cart.ForEach(Console.WriteLine);

                                select = int.Parse(Console.ReadLine() ?? "-1");
                                selectedProd = cart.FirstOrDefault(p => p.Id == select);
                                if (selectedProd != null)
                                {
                                    do
                                    {
                                        Console.WriteLine("would you like to:\nC.change quantity\nR.remove item from cart\nE. exit cart");
                                        string? input_cart = Console.ReadLine();
                                        choice = input_cart != null && input_cart.Length > 0 ? char.ToUpper(input_cart[0]) : ' ';

                                        switch (choice) 
                                        {
                                            case 'R':
                                                CartServiceProxy.Current.RemoveFromCart(selectedProd);
                                                break;
                                            case 'C':
                                                int quantity;
                                                do
                                                {
                                                    Console.WriteLine("Enter the quantity");
                                                    quantity = int.Parse(Console.ReadLine() ?? "-1");

                                                    if (quantity > 1)
                                                    {
                                                        selectedProd.Quantity = quantity;
                                                    } else if (quantity == 0)
                                                    {
                                                        CartServiceProxy.Current.RemoveFromCart(selectedProd);
                                                    }
                                                } while (quantity == -1);      
                                                break;
                                            case 'E':
                                                break;
                                            default:
                                                Console.WriteLine("Invalid choice");
                                                break;
                                        }
                                    } while (choice != 'E');
                                }
                                break;
                            case 'D':
                                if (cart.Count == 0)
                                {
                                    Console.WriteLine("\"\\nCart is empty\\n\"");
                                    break;
                                }
                                Console.WriteLine("which product would you like to remove from your cart?");
                                cart.ForEach(Console.WriteLine);
                                select = int.Parse(Console.ReadLine() ?? "-1");
                                selectedProd =  cart.FirstOrDefault(p => p.Id == select);
                                CartServiceProxy.Current.RemoveFromCart(selectedProd);
                                break;
                            case 'Q':
                                Console.WriteLine("\nRECIEPT\nItems\t\tPrice\t\tQuantity\n");
                                cart.ForEach(Console.WriteLine);
                                double checkOut = CartServiceProxy.Current.checkOut();
                                checkOut = Math.Round((double)checkOut, 2);
                                Console.WriteLine($"\nTotal Price = {checkOut}\n");
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Please choose again.");
                                break;
                        }
                    } while (choice != 'Q');
            }
        } while ((choice != '1' || choice != '2') && choice != '3');

        }
    }
}
