namespace Magic
{

    // Паттерн Singleton - паттерн, порождающий объекты.
    // Назначение: Гарантирует, что у класса есть только один экземпляр и предоставляет к нему глобальную точку доступа.
    // Одиночка используется в случае, если в системе необходим объект только в единственном экземпляре.
    // Пользователь может установить настройки один раз и менять их не имеет права.
    public class Settings
    {
        // Приватное статическое поле instance, которое хранит единственный экземпляр класса.
        private static Settings? instance;

        private int health;
        private int cost;

        // Приватный конструктор предотвращает создание экземпляров класса извне.
        private Settings(int helpHealth, int helpCost)
        {
            health = helpHealth;
            cost = helpCost;
        }

        // Через публичное статическое свойство GetInstance можно получить доступ к единственному экземпляру класса.
        public static Settings GetInstance(int helpHealth, int helpCost)
        {
            if (instance != null)
            {
                return instance;
            }
            instance = new Settings(helpHealth, helpCost);
            return instance;
        }


        // УДАЛИТЬ ЭТО (ПОКА ДЛЯ ПРОВЕРКИ)
        public void Print()
        {
            Console.WriteLine(health);
            Console.WriteLine(cost);
        }
    }
}
