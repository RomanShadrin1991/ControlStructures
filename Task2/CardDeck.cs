namespace Task2
{
    /// <summary>
    /// Колода карт
    /// </summary>
    public class CardDeck
    {
        /// <summary>
        /// Список карт в колоде
        /// </summary>
        public List<Card> Cards { get; set; }
        /// <summary>
        /// Создание новой (стандартной) колоды карт
        /// </summary>
        public CardDeck()
        {
            Cards = new List<Card>();

            for (int i = 1; i <= 14; i++)
            {
                if (i <= 10)
                {
                    for (int j = 0; j < 4; j++) Cards.Add(new Card(i.ToString(), i.ToString(), i));
                }
                else
                {
                    switch(i)
                    {
                        case 11:
                            for (int j = 0; j < 4; j++) Cards.Add(new Card("J", "Валет", 10));
                            break;
                        case 12:
                            for (int j = 0; j < 4; j++) Cards.Add(new Card("Q", "Дама", 10));
                            break;
                        case 13:
                            for (int j = 0; j < 4; j++) Cards.Add(new Card("K", "Король", 10));
                            break;
                        case 14:
                            for (int j = 0; j < 4; j++) Cards.Add(new Card("T", "Туз", 10));
                            break;
                    }
                }
            }
        }
    }
}