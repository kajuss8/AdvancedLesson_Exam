using AdvancedLesson_Exam.ReadFromTxt;
using AdvancedLesson_Exam.TableFunctions;
using AdvancedLesson_Exam.TxtFileWriter;
using System;

namespace AdvancedLesson_Exam
{
    public class Program
    {
        static void Main(string[] args)
        {
            SelectTable selectTable = new SelectTable();
            WriteInTxt writeInTxt = new WriteInTxt();
            TxtFileReader reader = new TxtFileReader();

            while(true)
            {
                Console.WriteLine("pirma eile staliuku dviem zmoniem, antra eile keturiem zmoniem, trecia sesiam, ketvirta keturiem, penkta dviem");
                Console.WriteLine("[1] - uzsakyti staliuka, [2] - staliuko uzsisakyti patiekalai, [3] - atlaisvinti staliuka, [4] - restorano pardavimai, [9] - baigti");
                Console.Write($"O - laisva vieta, X - Uzimta vieta\n");
                selectTable.ChangeTable(reader.ReadingTable());
                int choice = Convert.ToInt32(Console.ReadLine());
                if(choice == 1)
                {
                    writeInTxt.RewriteTableTxt(selectTable.SelectFreeTable(), "Table");
                    writeInTxt.RewriteTableTxt(selectTable.ChangeTable(reader.ReadingTable()), "ResultTable");
                    Console.WriteLine("\nPaspauskite enter kad testi");
                    Console.ReadLine();
                }
                if(choice == 2)
                {
                    Console.WriteLine("pasirinkite staliuka: ");
                    int line = Convert.ToInt32(Console.ReadLine());
                    int column = Convert.ToInt32(Console.ReadLine());
                    reader.ReadTableInformation(line, column);
                    Console.WriteLine("\nPaspauskite enter kad testi");
                    Console.ReadLine();
                }
                if(choice == 3)
                {
                    writeInTxt.RewriteTableTxt(selectTable.MakeTableFree(), "Table");
                    writeInTxt.RewriteTableTxt(selectTable.ChangeTable(reader.ReadingTable()), "ResultTable");
                    Console.WriteLine("\nPaspauskite enter kad testi");
                    Console.ReadLine();
                }
                if(choice == 4)
                {
                    reader.ReadRestaurantCheck();
                    Console.WriteLine("ar issiusti restoranui pastu? [y,n]");
                    char choice2 = Convert.ToChar(Console.ReadLine());
                    if (choice2 == 'y')
                    {
                        Console.WriteLine("Iveskite pasta");
                        string mail = Console.ReadLine();
                        writeInTxt.SendRestaurantEmail(mail);
                        Console.WriteLine("issiusta");
                        Console.WriteLine("\nPaspauskite enter kad testi");
                        Console.ReadLine();
                    }
                }
                else if(choice == 9)
                {
                    break;
                }
            }
        }
    }
}