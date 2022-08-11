namespace Task2
{
    /// <summary>
    /// Игральная карта
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Номинал карты
        /// </summary>
        public string Nominal { get; set; }
        /// <summary>
        /// Название карты
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Вес карты
        /// </summary>
        public int Weight { get; set; }
        /// <summary>
        /// Создание новой карты
        /// </summary>
        /// <param name="nominal"> Номинал </param>
        /// <param name="name"> Название </param>
        /// <param name="weight"> Вес </param>
        public Card(string nominal, string name, int weight)
        {
            Nominal = nominal;
            Name = name;
            Weight = weight;
        }
        public override string ToString()
        {
            return $"Номинал карты: {Nominal}, Название карты: {Name}, Вес карты: {Weight}";
        }
    }
}