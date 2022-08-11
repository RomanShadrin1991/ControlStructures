namespace Technical
{
    /// <summary>
    /// Технический static класс для разных проектов
    /// </summary>
    public static class TechnicalClass
    {
        /// <summary>
        /// Метод для проверки корректности вводимого пользователем числа
        /// </summary>
        /// <param name="stringNumber"> Вводимое пользователем значение </param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int CheckIntegerNumber(string stringNumber)
        {
            int number;

            if (int.TryParse(stringNumber, out number))
            {
                return number;
            }
            else
            {
                if (string.IsNullOrEmpty(stringNumber))
                {
                    throw new Exception("Необходимо ввести какое-то число, " +
                                      "пустое значение не принимается.");
                }
                else
                {
                    foreach (var c in stringNumber)
                    {
                        if (char.IsLetter(c))
                        {
                            throw new Exception("Введенная Вами информация содержит символы.");
                        }

                        if (char.IsPunctuation(c))
                        {
                            throw new Exception("Не допускается ввод знаков пунктуации или дробных чисел.");
                        }

                    }
                }
            }
            return number;
        }
        /// <summary>
        /// Метод для проверки корректности вводимого пользователем номинала карты
        /// </summary>
        /// <param name="userCardNominal"> Номинал игральной карты </param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string CheckCardNominal(string userCardNominal)
        {
            var nominals = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "T" };

            if (string.IsNullOrEmpty(userCardNominal))
            {
                throw new Exception("Номинал карты не может быть пустым");
            }

            if (
                (userCardNominal.Length == 2 && userCardNominal != "10") || 
                (userCardNominal.Length == 1 && !nominals.Contains(userCardNominal))
               )
            {
                throw new Exception("Номинал карты может быть числом от 1 до 10 или латинскими буквами J, Q, K, T");
            }

            return userCardNominal;
        }
    }
}