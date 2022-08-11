using System;
using Technical;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            do
            {

            // Ввод пользователем длины последовательности:
            numberInput:
                Console.Write("Введите, пожалуйста, длину последовательности чисел: ");
                string userInput = Console.ReadLine();
                int userNumber;

                // Проверка корректности введенного пользователем числа:
                try
                {
                    userNumber = TechnicalClass.CheckIntegerNumber(userInput);

                    if (userNumber <= 0)
                    {
                        Console.WriteLine("Длина последовательности не может быть меньше или равной нулю");
                        Console.WriteLine();
                        goto numberInput;
                    }

                    // Ввод чисел в последовательности:
                    var minValue = int.MaxValue;
                    Console.WriteLine();
                    for (int i = 1; i <= userNumber; i++)
                    {
                    sequenceMembersInput:
                        Console.Write($"Введите, пожалуйста, {i}-й член последовательности: ");
                        userInput = Console.ReadLine();
                        try
                        {
                            var sequenceMember = TechnicalClass.CheckIntegerNumber(userInput);

                            // Определение минимального элемента последовательности:
                            if (sequenceMember < minValue)
                            {
                                minValue = sequenceMember;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine();
                            Console.WriteLine(e.Message);
                            goto sequenceMembersInput;
                        }
                    }

                    // Вывод результата: 
                    Console.WriteLine();
                    Console.WriteLine($"Минимальное число в последовательности: {minValue}");

                    flag = false;
                }

                // Отображение информации об ошибке в случае некорректного ввода числа:
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    goto numberInput;
                }
            } while (flag);
        }
    }
}