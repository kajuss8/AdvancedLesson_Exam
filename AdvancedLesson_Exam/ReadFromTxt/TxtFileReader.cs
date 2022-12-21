using AdvancedLesson_Exam.menu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdvancedLesson_Exam.ReadFromTxt
{
    public class TxtFileReader
    {
        public List<DrinkMenu> ReadingDrinkTxtFile()
        {
            string file = @"C:\Users\37067\OneDrive\Desktop\C sharp basic\AdvancedLesson_Exam\AdvancedLesson_Exam\txt_menu\drinks.txt";
            List<DrinkMenu> drinkMenu = new List<DrinkMenu>();
            List<string> lines = File.ReadAllLines(file).ToList();
            foreach (var line in lines)
            {
                string[] entries = line.Split(' ');
                List<string> list = entries.ToList();
                DrinkMenu tempMenu = new DrinkMenu();
                tempMenu.DrinkId = Convert.ToInt32(list[0]);
                tempMenu.Name = entries[1];
                tempMenu.Price = Convert.ToDouble(entries[2]);
                drinkMenu.Add(tempMenu);
            }
            return drinkMenu;
        }
        public List<FoodMenu> ReadingFoodTxtFile()
        {
            string file = @"C:\Users\37067\OneDrive\Desktop\C sharp basic\AdvancedLesson_Exam\AdvancedLesson_Exam\txt_menu\food.txt";
            List<FoodMenu> foodMenu = new List<FoodMenu>();
            List<string> lines = File.ReadAllLines(file).ToList();
            foreach (var line in lines)
            {
                string[] entries = line.Split(' ');
                List<string> list = entries.ToList();
                FoodMenu tempMenu = new FoodMenu();
                tempMenu.FoodId = Convert.ToInt32(list[0]);
                tempMenu.Name = entries[1];
                tempMenu.Price = Convert.ToDouble(entries[2]);
                foodMenu.Add(tempMenu);
            }
            return foodMenu;
        }
        public char[,] ReadingTable()
        {
            string input = File.ReadAllText($@"C:\Users\37067\OneDrive\Desktop\C sharp basic\AdvancedLesson_Exam\AdvancedLesson_Exam\Table_txt\Table.txt");

            int i = 0, j = 0;
            char[,] result = new char[6, 6];
            foreach (var row in input.Split('\n'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    result[i, j] = char.Parse(col.Trim());
                    j++;
                }
                i++;
            }
            return result;
        }
        public char[,] ReadingTableToCopyFrom()
        {
            string input = File.ReadAllText(@"C:\Users\37067\OneDrive\Desktop\C sharp basic\AdvancedLesson_Exam\AdvancedLesson_Exam\Table_txt\TableToCopyFrom.txt");
            int i = 0, j = 0;
            char[,] result = new char[6, 6];
            foreach (var row in input.Split('\n'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    result[i, j] = char.Parse(col.Trim());
                    j++;
                }
                i++;
            }
            return result;
        }
        public void ReadTableInformation(int line, int column)
        {
            string fileLocation = $@"C:\Users\37067\OneDrive\Desktop\C sharp basic\AdvancedLesson_Exam\AdvancedLesson_Exam\Table_Information\{line}{column}.txt";
            foreach (var item in File.ReadAllLines(fileLocation))
            {
                Console.WriteLine(item);
            }
        }
        public void ReadRestaurantCheck()
        {
            string fileLocation = $@"C:\Users\37067\OneDrive\Desktop\C sharp basic\AdvancedLesson_Exam\AdvancedLesson_Exam\Check_txt\RestaurantCheck.txt";
            foreach (var item in File.ReadAllLines(fileLocation))
            {
                Console.WriteLine(item);
            }
        }
    }
}
