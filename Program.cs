using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    
    internal class Program
    {
        static double summ;
        interface IDiscountStrategy
        {
            double Calculate(double price);
        }
        class ConsoleInterface
        {
            public void ConsoleInterfase(IDiscountStrategy strategy, double price)
            {
                Console.WriteLine(strategy.Calculate(price));

            }
        }
        class Electronic : IDiscountStrategy
        {
            public double Calculate(double price)
            {

                return price * 0.95;
            }
        }
        class Clothes : IDiscountStrategy
        {
            public double Calculate(double price)
            {
                return price * 0.9;
            }
        }
        static void Main(string[] args)
        {

            string[] lines = File.ReadAllLines("list.json");

           
            Dictionary<string, IDiscountStrategy> strategies = new Dictionary<string, IDiscountStrategy>()
                {
                    { "электроника", new Electronic() },
                    { "одежда", new Clothes() }
                };
            try
            {
                foreach (string line in lines)
                {

                    string[] element = line.Split(',');
                    double price = double.Parse(element[0]);
                    if (price < 0)
                    {
                        Console.WriteLine("Отрицательная цена");
                        break;
                    }
                    string category = element[1].Trim();
                    IDiscountStrategy strategy = strategies[category];
                    double result = strategy.Calculate(price);
                    Console.WriteLine(result);
                    summ += result;
                }

                File.WriteAllText("result.txt", $"Сумма: {summ}") ;
                Console.WriteLine($"Сумма: {summ}");
            }
            catch { Console.WriteLine("Неверно введена строка");  }

        }

    }
}
