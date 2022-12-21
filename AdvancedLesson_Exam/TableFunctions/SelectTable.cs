using AdvancedLesson_Exam.ReadFromTxt;
using System;
using System.IO;
using AdvancedLesson_Exam.TxtFileWriter;
using AdvancedLesson_Exam.menu;

namespace AdvancedLesson_Exam.TableFunctions
{
    public class SelectTable
    {
        TxtFileReader txtFileReader = new TxtFileReader();
        SelectMenu selectMenu = new SelectMenu();
        WriteInTxt writeInTxt = new WriteInTxt();
        public char[,] ChangeTable(char[,] temp)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (temp[i, j] == '6')
                    {
                        temp[i, j] = 'O';
                    }
                    else if (temp[i, j] == '7')
                    {
                        temp[i, j] = 'O';
                    }
                    else if (temp[i, j] == '8')
                    {
                        temp[i, j] = 'O';
                    }
                    else if (temp[i, j] == '9')
                    {
                        temp[i, j] = 'X';
                    }
                    Console.Write(temp[i, j] + "  ");
                    if (j == 5)
                    {
                        Console.WriteLine();
                    }
                }
            }
            return temp;
        }
        public char[,] SelectFreeTable()
        {
            char[,] table = txtFileReader.ReadingTable();
            while (true)
            {
                Console.WriteLine($"Zmoniu Skaicius: ");
                int peopleCame = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("pasirinkite staliuka: ");
                Console.WriteLine("pradziai veskite eiles numeri, o poto stulpelio numeri");
                ChangeTable(txtFileReader.ReadingTable());
                int line = Convert.ToInt32(Console.ReadLine());
                int column = Convert.ToInt32(Console.ReadLine());
                if (table[line, column] == '9')
                {
                    Console.WriteLine("Si vieta uzimta");
                }
                else if (table[line, column] == '6' && peopleCame > 0 && peopleCame <= 2)
                {
                    table[line, column] = '9';
                    writeInTxt.CreatingTableInformation(selectMenu.SelectFromMenu(), line, column);
                    return table;
                }
                else if (table[line, column] == '7' && peopleCame > 0 && peopleCame <= 4)
                {
                    table[line, column] = '9';
                    writeInTxt.CreatingTableInformation(selectMenu.SelectFromMenu(), line, column);
                    return table;
                }
                else if (table[line, column] == '8' && peopleCame > 0 && peopleCame <= 6)
                {
                    table[line, column] = '9';
                    writeInTxt.CreatingTableInformation(selectMenu.SelectFromMenu(), line, column);
                    return table;
                }
                else
                {
                    Console.WriteLine("per didelis zmoniu skaicius siam stalui");
                    
                }
            }
        }
        public char[,] MakeTableFree()
        {
            char[,] originalTable = txtFileReader.ReadingTable();
            char[,] copyFromTable = txtFileReader.ReadingTableToCopyFrom();
            while (true)
            {
                Console.WriteLine("pasirinkite vieta");
                int line = Convert.ToInt32(Console.ReadLine());
                int column = Convert.ToInt32(Console.ReadLine());
                string fileLocation = $@"C:\Users\37067\OneDrive\Desktop\C sharp basic\AdvancedLesson_Exam\AdvancedLesson_Exam\Table_Information\{line}{column}.txt";
                if (originalTable[line, column] == '9')
                {
                    writeInTxt.CreateCheck(line, column);
                    Console.WriteLine("ar issiusti vartotojui ceki pastu? [y,n]");
                    char choice1 = Convert.ToChar(Console.ReadLine());
                    if (choice1 == 'y')
                    {
                        Console.WriteLine("Iveskite pasta");
                        string mail = Console.ReadLine();
                        writeInTxt.SendUserEmail(mail, line, column);
                        Console.WriteLine("issiusta");
                    }
                    Console.WriteLine("ar spausdinti ceki? [y,n]");
                    char choice2 = Convert.ToChar(Console.ReadLine());
                    if (choice2 == 'y')
                    {
                        txtFileReader.ReadTableInformation(line,column);
                        Console.WriteLine("\nPaspauskite enter kad testi");
                        Console.ReadLine();
                    }
                    File.WriteAllText(fileLocation, "");
                    originalTable[line, column] = copyFromTable[line, column];
                    break;
                }
                else if (originalTable[line, column] == '6' || originalTable[line, column] == '7' || originalTable[line, column] == '8')
                {
                    Console.WriteLine("Si vieta laisva");
                    break;
                }
            }
            return originalTable;
        }
    }
}