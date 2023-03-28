using System;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace SalesAssistant
{
    class Program
    {
        static void Main(string[] args)
        {
            Commands _cmd = new Commands();
            OrderCommand oCmd = new OrderCommand();
            Console.Write("Welcome to the Landscaping assistant! Please enter your name: ");
            string name = Console.ReadLine();
            bool quit = false;
            Customer cust = new Customer(name);
            //write program to console. 
            do
            {
                Console.Write("Which product are you interested in? Pavers or Retaining Walls: ");
                Products result = _cmd.Process(Console.ReadLine());
                Console.WriteLine("1: Add products to order\n2: search again\n3: Exit");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    oCmd.Execute(cust, result);
                }
                if (input == "3" || input == "Exit" || input == "exit")
                {
                    quit = true;
                    Console.Write("Thank you, goodbye");
                }
            } while (quit == false);
        }
    }
}
