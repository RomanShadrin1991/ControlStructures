using System;
using Technical;

namespace Task3
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

                    // Определение свойства (простое или составное) числа:
                    int i = 2;
                    bool simpleNumberFlag = false;
                    while (i < userNumber)
                    {
                        if (userNumber % i == 0)
                        {
                            simpleNumberFlag = true;
                            break;
                        }
                        i++;
                    }

                    var result = userNumber == 1 ? 
                                    $"Число {userNumber} не является ни простым, ни составным" : 
                                    simpleNumberFlag ? 
                                        $"Число {userNumber} является составным" : 
                                        $"Число {userNumber} является простым";
                    Console.WriteLine(result);

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