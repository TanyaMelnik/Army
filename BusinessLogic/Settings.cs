namespace Magic
{
    /// <summary>
    ///  Класс настроек.
    ///  Строка идентификатора "T:Magic.Settings".
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Поле, содержащее локкер.
        /// Строка идентификатора "F:Magic.Settings.locker".
        /// </summary>
        static readonly object locker = new ();

        /// <summary>
        /// Приватное статическое поле instance, которое хранит единственный экземпляр класса.
        /// Строка идентификатора "F:Magic.Settings.instance".
        /// </summary>
        private static Settings? instance;

        /// <summary>
        /// Метод, содержащее здоровье.
        /// Строка идентификатора "M:Magic.Settings.Health".
        /// </summary>
        public int Health { get; }

        /// <summary>
        /// Метод, содержащее стоимость.
        /// Строка идентификатора "M:Magic.Settings.Cost".
        /// </summary>
        public int Cost { get; }

        /// <summary>
        /// Поле, содержащее звук убийства.
        /// Строка идентификатора "F:Magic.Settings.sound".
        /// </summary>
        public static bool sound=true;

        /// <summary>
        ///  Приватный конструктор предотвращает создание экземпляров класса извне.
        /// Строка идентификатора "F:Magic.Settings.Settings(Magic.int, Magic.int)".
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
        /// Строка идентификатора "F:Magic.Settings.Settings(Magic.int, Magic.int)".
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
