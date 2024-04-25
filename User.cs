namespace Magic
{
    class User
    {
        public static void UserGame()
        {
            Console.WriteLine("Начинаем новую игру!");

            Settings settings = UserSettings();

            // ЗАДАЧА 1
            // Запрашиваем данные у пользователя о длительности игры и вместимости (cost) армии, передаем их в конструктор Settings
            // Создаём экземпляр Settings и заполняем данные в конструкторе 
            List<IUnit> army1 = CreateArmy(settings.Health, settings.Cost);
            List<IUnit> army2 = CreateArmy(settings.Health, settings.Cost);

        }

        public static Settings UserSettings()
        {
            // Ввод стоимость армий пользователем.
            int cost = SetCost();

            // Ввод пользователем длительности игры.
            int health = Healht();

            // Паттерн Singleton. 
            Settings settings = Settings.GetInstance(health, cost);

            return settings;
        }

        static int Healht()
        {
            int health = -1;

            Console.CursorVisible = false;

            string[] menuItems = { "Короткие", "Средние", "Длинные" };
            int selectedItemIndex = 0;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Какие игры по длительности Вы предпочитаете? :");
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == selectedItemIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(">");
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                    Console.WriteLine(" " + menuItems[i]);

                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedItemIndex = (selectedItemIndex - 1 + menuItems.Length) % menuItems.Length;
                        break;

                    case ConsoleKey.DownArrow:
                        selectedItemIndex = (selectedItemIndex + 1) % menuItems.Length;
                        break;

                    case ConsoleKey.Enter:
                        health = ExecuteMenuItem(selectedItemIndex);
                        break;
                }
                if (keyInfo.Key == ConsoleKey.Enter) break;
            }
            return health;
        }
        static int ExecuteMenuItem(int index)
        {
            Console.Clear();
            Console.WriteLine($"Вы выбрали: {index + 1}");
            if (index == 0) return 50;
            else if (index == 1) return 75;
            else if (index == 2) return 100;
            return 0;
        }
        static int SetCost()
        {
            int cost;
            Console.Write("Введите вместимость (стоимость) одной армии от 1 до 30 для дальнейших игр: ");
            while (!int.TryParse(Console.ReadLine(), out cost) || cost < 1 || cost > 30)
            {
                Console.Write("Неправильный ввод данных. Попробуйте ещё раз: ");
            }
            return cost;
        }

        static List<IUnit> CreateArmy(int health, int cost)
        {
            // ЗАДАЧА 2
            //Логика создания армий
            // Добавить выбор создания разных арммий 
            List<IUnit> army = new();
            //army=Ga,
            return army;
        }

        // TODO: КАК ИСПОЛЬЗОВАТЬ СОЗДАНИЕ АРМИИ :
        // Сначала идёт выбор вида армии ( с атакой, с уклонением, черный ящик) . Пока тоже можно реализовать через клавиши
        // AbstractArmyFactory a = new AttackArmy(); //с атакой
        // AbstractArmyFactory a = new BlackBoxArmy() // с уклонением
        // AbstractArmyFactory a =new DodgeArmy() // черный ящик
        // Затем идёт выбор создания армии ( рандом и баланс)
        // ArmyCreatedFactories b =new BalanceArmy(a,settings) // балансированно (в параментрах передаём абстрактну фабрику and Settings!)
        // ArmyCreatedFactories b =new RandomArmy(a,settings) // рандомно
        // После этого создание армии 
        // List <IUnit> army=b.CreateArmy(cost)// //  (в параментрах передаём баланс!)
    }

}
