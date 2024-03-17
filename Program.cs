using System;

/* Т.к в задании нет уточнения пр получение данныех реализовал считывание со стандартного потока ввода до пустой строки 
 * По той же причине в случае, если один из результатов матчей некорректен подсчет очков продолжаем, а ошибки списком выводим в конце 
 */

namespace Test_PSB_0324
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // string []str = { "1:5", "4:4", "3:2", "7:1" };
            string data = "";
            string new_str;
            do
            {
                new_str = Console.ReadLine();
                data += new_str;
                data += "\n";
            } while (new_str != "");
            string[] str = data.Split('\n');
            string error_txt = "";
            int rez1 = 0, rez2 = 0;
            for (int i = 0; i < (str.Length - 2); i++)
            {
                string[] buff = str[i].Split(':');
                if (buff.Length == 2)
                {
                    if (Int32.TryParse(buff[0], out int team1) && Int32.TryParse(buff[1], out int team2) && ((team1 >= 0) && (team2 >= 0)))
                    {
                        if (team1 > team2)
                        {
                            rez1 += 3;
                        }
                        else if (team1 == team2)
                        {
                            rez1++;
                            rez2++;
                        }
                        else
                        {
                            rez2 += 3;
                        }
                    }
                    else
                    {
                        error_txt += "Неверно зафиксирован счёт в результате " + (i + 1) + " матча\n";
                    }
                }
                else
                {
                    error_txt += "Ошибка в результате " + (i + 1) + " матча\n";
                }
            }
            Console.Write(error_txt);
            if ((rez1 + rez2) != 0)
            {
                Console.Write($"Команда #1 - {rez1} очков\nКоманда #2 - {rez2} очков");
            }
            else
            {
                Console.WriteLine("Не проведено ни одного матча");
            }
            Console.ReadKey();
        }
    }
}
