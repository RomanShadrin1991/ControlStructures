using System;
using Technical;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            do
            {

            // Ввод числа пользователем:
            numberInput:
                Console.Write("Введите, пожалуйста, целое число: ");
                string userInput = Console.ReadLine();
                int userNumber;
                
                // Проверка корректности введенного пользователем числа:
                try
                {
                    userNumber = TechnicalClass.CheckIntegerNumber(userInput);

                    // Определение четности числа:
                    if (userNumber % 2 == 0)
                    {
                        Console.WriteLine($"\nЧисло {userNumber} является четным");
                    }
                    else
                    {
                        Console.WriteLine($"\nЧисло {userNumber} является нечетным");
                    }

                    flag = false;
                }

                // Отображение информации об ошибке в случае некорректного ввода числа:
                catch(Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    goto numberInput;
                }
            } while (flag);
        }
    }
}