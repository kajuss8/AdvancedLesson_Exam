using AdvancedLesson_Exam.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLesson_Exam.menu
{
    public class SelectMenu
    {
        public List<Order> SelectFromMenu()
        {
            FoodMenuRepository foodMenuRepository = new FoodMenuRepository();
            DrinkMenuRepository drinkMenuRepository = new DrinkMenuRepository();
            List<Order> list = new List<Order>();
            double sumPrice = 0;
            while (true)
            {
                Console.WriteLine($"[1] - Maisto meniu [2] - Gerimu meniu [3] - Baigti uzsakyma");
                char temp = Convert.ToChar(Console.ReadLine());
                if (temp == '1')
                {
                    while (true)
                    {
                        Order order = new Order();
                        foodMenuRepository.AllMenu().ForEach(i => Console.WriteLine($"[{i.FoodId}] - {i.Name} {i.Price} EUR"));
                        Console.WriteLine("[9] - iseiti is pasirinkimo");
                        Console.WriteLine($"Pasirinkite:");
                        int foodId = Convert.ToInt32(Console.ReadLine());
                        if (foodId == 9)
                        {
                            break;
                        }
                        Console.WriteLine("kiekis:");
                        int foodQuantity = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"{foodQuantity}x {foodMenuRepository.PrintSelectedByIdMenu(foodId).Name}" +
                            $" {foodMenuRepository.PrintSelectedByIdMenu(foodId).Price} EUR x {foodQuantity} = " +
                            $"{foodMenuRepository.PrintSelectedByIdMenu(foodId).Price * foodQuantity} EUR");
                        sumPrice += foodMenuRepository.PrintSelectedByIdMenu(foodId).Price * foodQuantity;
                        order.Amount = foodQuantity;
                        order.Name = foodMenuRepository.PrintSelectedByIdMenu(foodId).Name;
                        order.Price = foodMenuRepository.PrintSelectedByIdMenu(foodId).Price * foodQuantity;
                        list.Add(order);
                    }
                }
                if (temp == '2')
                {
                    while (true)
                    {
                        Order order = new Order();
                        drinkMenuRepository.AllMenu().ForEach(i => Console.WriteLine($"[{i.DrinkId}] - {i.Name} {i.Price} EUR"));
                        Console.WriteLine("[9] - iseiti is pasirinkimo");
                        Console.WriteLine($"Pasirinkite:");
                        int drinkId = Convert.ToInt32(Console.ReadLine());
                        if (drinkId == 9)
                        {
                            break;
                        }
                        Console.WriteLine("kiekis:");
                        int drinkQuantity = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"{drinkQuantity}x {drinkMenuRepository.PrintSelectedByIdMenu(drinkId).Name}" +
                            $" {drinkMenuRepository.PrintSelectedByIdMenu(drinkId).Price} EUR x {drinkQuantity} = " +
                            $"{drinkMenuRepository.PrintSelectedByIdMenu(drinkId).Price * drinkQuantity} EUR");
                        sumPrice += drinkMenuRepository.PrintSelectedByIdMenu(drinkId).Price * drinkQuantity;
                        order.Amount = drinkQuantity;
                        order.Name = drinkMenuRepository.PrintSelectedByIdMenu(drinkId).Name;
                        order.Price = drinkMenuRepository.PrintSelectedByIdMenu(drinkId).Price * drinkQuantity;
                        list.Add(order);
                    }
                }
                if (temp == '3')
                {
                    break;
                }
            }
            Console.WriteLine("Uzsakyta");
            return list;
        }
    }
}
