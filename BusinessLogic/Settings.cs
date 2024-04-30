namespace Magic
{

    // Паттерн Singleton - паттерн, порождающий объекты.
    // Назначение: Гарантирует, что у класса есть только один экземпляр и предоставляет к нему глобальную точку доступа.
    // Одиночка используется в случае, если в системе необходим объект только в единственном экземпляре.
    // Пользователь может установить настройки один раз и менять их не имеет права.
    public class Settings
    {
        static object locker = new object();

        // Приватное статическое поле instance, которое хранит единственный экземпляр класса.
        private static Settings? instance;

        public int Health { get; }
        public int Cost { get; }
        // Звук при убийстве unit 
        public bool Sound { get; set; } = true;

        // Приватный конструктор предотвращает создание экземпляров класса извне.
        private Settings(int helpHealth, int helpCost)
        {
            Health = helpHealth;
            Cost = helpCost;
        }

        // Через публичное статическое свойство GetInstance можно получить доступ к единственному экземпляру класса.
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


        // УДАЛИТЬ ЭТО (ПОКА ДЛЯ ПРОВЕРКИ)
        public void Print()
        {
            Console.WriteLine(Health);
            Console.WriteLine(Cost);
        }
    }
}
