using System.ComponentModel.DataAnnotations;

namespace Magic
{
    class User
    {
        public static void UserGame()
        {
            Console.WriteLine("Начинаем новую игру!");

            Settings settings = UserSettings();

            // Добавить создание второй армии

            AbstractArmyFactory abstractArmyFactory = AddUnitStats();

            ArmyCreatedFactories armyCreatedFactories = SelectSetUnits(abstractArmyFactory, settings);

            List<IUnit> army1 = armyCreatedFactories.CreateArmy();

            foreach (IUnit unit in army1)
            {
                Console.WriteLine(unit.ToString());
            }
            Console.WriteLine();

            List<IUnit> army2 = armyCreatedFactories.CreateArmy();

            foreach (IUnit unit in army2)
            {
                Console.WriteLine(unit.ToString());
            }
            Console.WriteLine();
            // Прописываем логику игры. Нуждается в переносе в другом классе
            // Игра работает пока одна армия не умрёт
            while (army1.Count>2 || army2.Count > 2)
            {
                // Логика на проверку получения ударов. Нужны проверки на смерть.!!
                // Для первых в стеке битва 1:1
                army1[0].GetHit(army2[0].Attack);
                Console.Write($"Удар по {army1[0].ToString()}");
                if (army1[0].Health <= 0)
                {
                    Console.Write($"->Умер");
                    army1.RemoveAt(0);
                }
                Console.WriteLine();
                army2[0].GetHit(army1[0].Attack);
                Console.Write($"Удар по {army2[0].ToString()}");
                if (army2[0].Health <= 0)
                {
                    Console.Write($"->Умер");
                    army2.RemoveAt(0);
                }
                Console.WriteLine();
                // Особые 
                for (int i = 1; i < Math.Min(army1.Count, army2.Count); i++)
                {
                    // Если есть спец свойство
                    if (army2[i] is ISpecialProperty one)
                    {
                        // Создание экземпляра ProxyLogSpecial
                        var proxy = new ProxyLogSpecial(one);
                        // Вызов метода DoSpecialProperty через экземпляр ProxyLogSpecial
                        proxy.DoSpecialProperty(army1, army2, i);
                    }
                    if (army1[i] is ISpecialProperty two)
                    {
                        /*Console.WriteLine($"Special Удар от {army1[i]} ");
                        two.DoSpecialProperty(army1, army2, i);*/
                        var proxy = new ProxyLogSpecial(two);
                        // Вызов метода DoSpecialProperty через экземпляр ProxyLogSpecial
                        proxy.DoSpecialProperty(army1, army2, i);
                    }
                }
            }
        }

        static Settings UserSettings()
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
                        health = ExecuteMenuItemDuration(selectedItemIndex);
                        break;
                }
                if (keyInfo.Key == ConsoleKey.Enter) break;
            }
            return health;
        }
        static int ExecuteMenuItemDuration(int index)
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

        static AbstractArmyFactory AddUnitStats() 
        {
            AbstractArmyFactory abstractArmyFactory = null;

            string[] menuItems = { "С сильной атакой", "С большим процентом уклонения", "С рандомными характеристиками" };
            int selectedItemIndex = 0;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Какую армию Вы хотите создать? :");
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
                        abstractArmyFactory = ExecuteMenuItemStats(selectedItemIndex);
                        break;
                }
                if (keyInfo.Key == ConsoleKey.Enter) break;
            }
            return abstractArmyFactory;
        }
        static AbstractArmyFactory ExecuteMenuItemStats(int index)
        {
            Console.Clear();
            Console.WriteLine($"Вы выбрали: {index + 1}");
            if (index == 0) return new AttackArmy();
            else if (index == 1) return new DodgeArmy();
            else if (index == 2) return new BlackBoxArmy();
            return null;
        }

        static ArmyCreatedFactories SelectSetUnits(AbstractArmyFactory abstractArmyFactory, Settings settings)
        {
            ArmyCreatedFactories armyCreatedFactories = null;

            string[] menuItems = { "Сбалансированно", "Рандомно"};
            int selectedItemIndex = 0;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Как набрать воинов в армию? :");
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
                        armyCreatedFactories = ExecuteMenuItemSetUnits(selectedItemIndex, abstractArmyFactory, settings);
                        break;
                }
                if (keyInfo.Key == ConsoleKey.Enter) break;
            }
            return armyCreatedFactories;
        }

        static ArmyCreatedFactories ExecuteMenuItemSetUnits(int index, AbstractArmyFactory abstractArmyFactory, Settings settings)
        {
            Console.Clear();
            Console.WriteLine($"Вы выбрали: {index + 1}");
            if (index == 0) return new BalanceArmy(abstractArmyFactory, settings);
            else if (index == 1) return new RandomArmy(abstractArmyFactory, settings);
            return null;
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
