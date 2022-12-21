using System;
using System.IO;
using System.Collections.Generic;
using AdvancedLesson_Exam.Interfaces;

namespace AdvancedLesson_Exam.TxtFileWriter
{
    public class WriteInTxt:IEmailSender
    {
        public char[,] RewriteTableTxt(char[,] temp, string location)
        {
            string tableLocation = $@"C:\Users\37067\OneDrive\Desktop\C sharp basic\AdvancedLesson_Exam\AdvancedLesson_Exam\Table_txt\{location}.txt";
            File.WriteAllText(tableLocation, "");
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if(j < 5)
                    {
                        File.AppendAllText(tableLocation, $"{temp[i, j]} ");
                    }
                    if (j == 5 && i < 5)
                    {
                        File.AppendAllText(tableLocation, $"{temp[i, j]}\n");
                    }
                    if (j == 5 && i == 5)
                    {
                        File.AppendAllText(tableLocation, $"{temp[i, j]}");
                    }
                }
            }
            return temp;
        }
        public void CreatingTableInformation(List<Order> orderList,int temp1, int temp2)
        {
            string fileLocation = $@"C:\Users\37067\OneDrive\Desktop\C sharp basic\AdvancedLesson_Exam\AdvancedLesson_Exam\Table_Information\{temp1}{temp2}.txt";
            DateTime date = DateTime.Now;
            double sum = 0;
            orderList.ForEach(i => File.AppendAllText(fileLocation, $"{i.Amount}x {i.Name} {i.Price} EUR\n"));
            orderList.ForEach(i => sum+= i.Price);
            File.AppendAllText(fileLocation, $"Bendra suma:{sum} EUR\n{date}");
        }
        public void CreateCheck(int line, int column)
        {
            string tableLocation = $@"C:\Users\37067\OneDrive\Desktop\C sharp basic\AdvancedLesson_Exam\AdvancedLesson_Exam\Table_Information\{line}{column}.txt";
            string restaurantLocation = $@"C:\Users\37067\OneDrive\Desktop\C sharp basic\AdvancedLesson_Exam\AdvancedLesson_Exam\Check_txt\RestaurantCheck.txt";
            File.AppendAllText(restaurantLocation, $"Table number:{line}{column}\n");
            foreach (var item in File.ReadAllLines(tableLocation))
            {
                File.AppendAllText(restaurantLocation, $"{item}\n");
            }
            File.AppendAllText(restaurantLocation, $"\n");
        }
        public void SendUserEmail(string email, int line, int column)
        {
            string tableLocation = $@"C:\Users\37067\OneDrive\Desktop\C sharp basic\AdvancedLesson_Exam\AdvancedLesson_Exam\Table_Information\{line}{column}.txt";
            string user = $@"C:\Users\37067\OneDrive\Desktop\C sharp basic\AdvancedLesson_Exam\AdvancedLesson_Exam\Check_txt\EmailSendedToUser.txt";
            File.AppendAllText(user, $"{email}\nTable number:{line}{column}\n");
            foreach (var item in File.ReadAllLines(tableLocation))
            {
                File.AppendAllText(user, $"{item}\n");
            }
            File.AppendAllText(user, $"\n");
        }
        public void SendRestaurantEmail(string email)
        {
            string tableLocation = $@"C:\Users\37067\OneDrive\Desktop\C sharp basic\AdvancedLesson_Exam\AdvancedLesson_Exam\Check_txt\RestaurantCheck.txt";
            string restaurantLocation = $@"C:\Users\37067\OneDrive\Desktop\C sharp basic\AdvancedLesson_Exam\AdvancedLesson_Exam\Check_txt\EmailSendedToRestaurant.txt";
            File.AppendAllText(restaurantLocation, $"{email}\n");
            foreach (var item in File.ReadAllLines(tableLocation))
            {
                File.AppendAllText(restaurantLocation, $"{item}\n");
            }
            File.AppendAllText(restaurantLocation, $"\n");
        }
    }
}