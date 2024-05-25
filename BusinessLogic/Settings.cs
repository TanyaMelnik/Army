namespace Magic
{
    public class Settings
    {
        static readonly object locker = new ();

        /// <summary>
        /// Приватное статическое поле instance, которое хранит единственный экземпляр класса.
        /// </summary>
        private static Settings? instance;
        public int Health { get; }
        public int Cost { get; }

        /// <summary>
        /// Звук при убийстве unit 
        /// </summary>
        public static bool sound=true;

        /// <summary>
        ///  Приватный конструктор предотвращает создание экземпляров класса извне.
        /// </summary>
        /// <param name="helpHealth">Здоровье юнитов.</param>
        /// <param name="helpCost">Сумма для покупки юнитов.</param>
        private Settings(int helpHealth, int helpCost)
        {
            Health = helpHealth;
            Cost = helpCost;
        }

        /// <summary>
        /// Метод получения единственного экземпляра.
        /// </summary>
        /// <param name="helpHealth">Здоровье юнитов.</param>
        /// <param name="helpCost">Сумма для покупки юнитов.</param>
        /// <returns></returns>
        public static Settings GetInstance(int helpHealth, int helpCost)
        {
            lock (locker)
            {
                if (instance != null)
                {
                    return instance;
                }
                instance = new Settings(helpHealth, helpCost);
                return instance;
            }
        }
    }
}
