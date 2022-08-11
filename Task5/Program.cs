using System;
using Technical;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            do
            {
                // Приветствие игрока:
                Console.WriteLine("Добро пожаловать в \"Угадай-ку\"");
                Random rand = new Random();
            // Ввод числа пользователем:
            numberInput:
                Console.Write("Введите, пожалуйста, максимальное целое число диапазона: ");
                string userInput = Console.ReadLine();
                int userNumber;

                // Проверка корректности введенного пользователем максимального числа диапазона:
                try
                {
                    userNumber = TechnicalClass.CheckIntegerNumber(userInput);

                    // Генерация случайного числа:
                    var iiNumber = rand.Next(0, userNumber + 1);
                    
                    // Игра в "Угадай-ку":
                    var guessFlag = true;
                    while (guessFlag)
                    {
                    guessNumber:
                        Console.WriteLine();
                        Console.Write("Попробуйте угадать загаданное программой число: ");
                        userInput = Console.ReadLine();
                        try
                        {
                            // Выход из игры в случае усталости пользователя:
                            if (string.IsNullOrEmpty(userInput))
                            {
                                Console.WriteLine();
                                Console.WriteLine($"Загаданное компьютером число: {iiNumber}");
                                Console.WriteLine("Отдохните и возвращайтесь к нам снова!");
                                guessFlag = false;
                            }

                            // Игра до победного:
                            else
                            {
                                var userGuessNumber = TechnicalClass.CheckIntegerNumber(userInput);

                                if (userGuessNumber < iiNumber)
                                {
                                    Console.WriteLine("Введенное число меньше загаданного.");
                                }
                                else if (userGuessNumber > iiNumber)
                                {
                                    Console.WriteLine("Введенное число больше загаданного.");
                                }
                                else
                                {
                                    Console.WriteLine("Поздравляем! Вы угадали число!");
                                    guessFlag = false;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine();
                            Console.WriteLine(e.Message);
                            goto guessNumber;
                        }
                    }
                    

                    flag = false;
                }

                // Отображение информации об ошибке в случае некорректного ввода максимального числа диапазона:
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