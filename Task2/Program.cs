using System;
using Technical;
using System.Linq;


namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            do
            {
                // Приветствие игрока:
                Console.WriteLine("Приветствую Вас, игрок!");

                // Ввод игроком количества имеющихся на руках карт:
            numberInput:
                Console.Write("Введите, пожалуйста, количество карт у вас на руках: ");
                string userInput = Console.ReadLine();
                int userNumber;

                // Проверка корректности введенного количества карт:
                try
                {
                    var cardDeck = new CardDeck();
                    var userCards = new List<Card>();
                    Random rand = new Random();
                    userNumber = TechnicalClass.CheckIntegerNumber(userInput);

                    Console.WriteLine();

                    // Ввод номинала карт:
                    Console.WriteLine("Сейчас мы попросим Вас ввести номинал ваших карт.\n" +
                            "Обратите внимание, что:\n" +
                            "\t- для карт с числовым номиналом необходимо вводить цифру от 1 до 10;\n" +
                            "\t- для \"картинок\" необходимо ввести латинскую букву в соответствии со списком ниже:\n" +
                            "\t\t{0,-8} = {1,-10}\n" +
                            "\t\t{2,-8} = {3,-10}\n" +
                            "\t\t{4,-8} = {5,-10}\n" +
                            "\t\t{6,-8} = {7,-10}\n", "\"Валет\"", "J", "\"Дама\"", "Q", "\"Король\"", "K", "\"Туз\"", "T");
                    for (int i = 1; i <= userNumber; i++)
                    {
                        bool cardNominalFlag = true;
                        do
                        {
                        cardNominalInput:
                            Console.Write($"Введите, пожалуйста, номинал вашей {i}-й карты: ");
                            userInput = Console.ReadLine();

                            // Проверка корректности ввода номинала карты:
                            try
                            {
                                string userCardNominal = TechnicalClass.CheckCardNominal(userInput);

                                try
                                {
                                    // Поиск карты по номиналу в колоде:
                                    var cardFromDeck = cardDeck.Cards.First(card => card.Nominal == userCardNominal);

                                    // Фиксация карты с данным номиналом в руке пользователя:
                                    userCards.Add(cardFromDeck);

                                    // Удаление карты с данным номиналом из колоды:
                                    cardDeck.Cards.Remove(cardFromDeck);
                                }
                                catch
                                {
                                    Console.WriteLine("В колоде не может быть больше 4-х карт одного номинала.");
                                    Console.WriteLine();
                                    goto cardNominalInput;
                                }
                                cardNominalFlag = false;
                            }

                            // Отображение информации об ошибке в случае некорректного ввода номинала карты:
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine();
                                goto cardNominalInput;
                            }
                        } while (cardNominalFlag);      
                    }
                    flag = false;

                    Console.WriteLine();

                    // Отображение информации о картах в руках пользователя:
                    Console.WriteLine($"У Вас в руке {userNumber} карт(-ы) следующего номинала:");
                    foreach(var card in userCards)
                    {
                        Console.WriteLine($"\t{card.Name,-7} (вес этой карты: {card.Weight})");
                    }

                    // Подсчет суммарного веса карт в руках пользователя:
                    var totalUserCardWeight = userCards.Sum(card => card.Weight);

                    Console.WriteLine();

                    Console.WriteLine($"Суммарный вес Ваших карт: {totalUserCardWeight}");

                    // Подключение второго игрока:
                    int randomTotalWeight = rand.Next(1, 22);
                    Console.WriteLine($"Суммарный вес карт Вашего соперника: {randomTotalWeight}");

                    Console.WriteLine();

                    // Определение победителя в игре "21":
                    if (totalUserCardWeight <= 21 && totalUserCardWeight > randomTotalWeight)
                    {
                        Console.WriteLine("Поздравляю! Вы победили в этой игре!!!");
                    }
                    else
                    {
                        Console.WriteLine("К сожалению, Ваш противник победил... " +
                                          "Не расстраивайтесь! " +
                                          "В следующий раз Вам обязательно повезет!");
                    }
                }

                // Отображение информации об ошибке в случае некорректного ввода числа карт на руках:
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