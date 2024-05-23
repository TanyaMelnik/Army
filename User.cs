using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Magic
{
    class User
    {
        public static void UserGame()
        {
            bool games = true;
            while (games)
            {
                Console.WriteLine("Начинаем новую игру!");

                // Инициализация настроек. Это не пункт меню, так как это устанавливается один раз и это нельзя поменять
                UserSettings();

                // Создание первой армии.
                AbstractArmyFactory abstractArmyFactory1 = AddUnitStats();
                ArmyCreatedFactories armyCreatedFactories1 = SelectSetUnits(abstractArmyFactory1);
                List<IUnit> army1 = armyCreatedFactories1.CreateArmy();

                // Создание второй армии.
                AbstractArmyFactory abstractArmyFactory2 = AddUnitStats();
                ArmyCreatedFactories armyCreatedFactories2 = SelectSetUnits(abstractArmyFactory2);
                List<IUnit> army2 = armyCreatedFactories2.CreateArmy();

                // Выбор армии, которая ходит первая
                ChoiseFirstArmy(ref army1, ref army2);

                // Выбор построения армий, вынести в отдельную функцию
                Console.WriteLine("Выберите тип построения армий");
                Console.WriteLine("1. Колонна");
                Console.WriteLine("2. Три в ряд");
                Console.WriteLine("3. Стенка на стенку");
                int TypeConstruction = -1;
                while (!int.TryParse(Console.ReadLine(), out TypeConstruction) || TypeConstruction < 1 || TypeConstruction > 3)
                {
                    Console.Write("Неправильный ввод данных. Попробуйте ещё раз: ");
                }
                Console.Write("Ваш ответ: ");
                ITypeConstruction typeConstruction = new Сolumn(army1, army2);
                switch (TypeConstruction)
                {
                    case 1:
                        typeConstruction = new Сolumn(army1, army2);
                        break;
                    case 2:
                        typeConstruction = new Battalion(army1, army2);
                        break;
                    case 3:
                        typeConstruction = new WallToWall(army1, army2);
                        break;

                }

                // Основной цикл игры
                bool game = true;
                while (game)
                {
                    Console.WriteLine("Выберите пункт меню");
                    Console.WriteLine("1. Сделать ход");
                    Console.WriteLine("2. Отменить");
                    Console.WriteLine("3. Повторить");
                    Console.WriteLine("4. Поменять построение");
                    Console.WriteLine("5. Закончить текущую игру");
                    int menu;
                    while (!int.TryParse(Console.ReadLine(), out menu) || menu < 1 || menu > 5)
                    {
                        Console.Write("Неправильный ввод данных. Попробуйте ещё раз: ");
                    }
                    Console.Write("Ваш ответ: ");

                    // Инициализация изначальных данных
                    Invoker invoker = new Invoker();

                    switch (menu)
                    {
                        case 1:
                            ICommand StartMakeMove = new MakeMove(typeConstruction);
                            invoker.AddCommand(StartMakeMove);
                            game = invoker.ExecuteCommand();
                            break;
                        case 2:
                            bool flagUndo = invoker.UndoCommand();
                            if (flagUndo == false) Console.WriteLine("Отмену выполнить невозможно! Сначала сделайте действие!");
                            break;
                        case 3:
                            bool flagRedo = invoker.RedoCommand();
                            if (flagRedo == false) Console.WriteLine("Повтор выполнить невозможно! Сначала отмените действие!");
                            break;
                        case 4:
                            ICommand ChangeTypeConstruction = new ChangeTypeConstruction(typeConstruction);
                            invoker.AddCommand(ChangeTypeConstruction);
                            invoker.ExecuteCommand();
                            break;
                        case 5:
                            game = false;
                            break;
                    }
                }

                Console.WriteLine("Хотите начать новую игру? ");
                Console.WriteLine("1. Да!");
                Console.WriteLine("2. Хочу выйти из игры ");
                Console.Write("Ваш ответ: ");
                int answer;
                while (!int.TryParse(Console.ReadLine(), out answer) || answer < 1 || answer > 2)
                {
                    Console.Write("Неправильный ввод данных. Попробуйте ещё раз: ");
                }

                if (answer == 2) games = false;
            }
        }

        static void UserSettings()
        {
            // Ввод стоимость армий пользователем.
            int cost = SetCost();

            // Ввод пользователем длительности игры.
            int health = Healht();

            // ПОМЕНЯТЬ
            Settings.sound = false;

/*            Console.Write("Включить звук при убийстве юнита - введите true. Выключить звуки - введите false:  ");
            while (!bool.TryParse(Console.ReadLine(), out Settings.sound))
            {
                Console.Write("Неправильный ввод данных. Попробуйте ещё раз: ");
            }*/

            // Паттерн Singleton. 
            Settings.GetInstance(health, cost);

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

                Console.WriteLine("Какие игры по длительности Вы предпочитаете?");
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

                Console.WriteLine("Какую армию Вы хотите создать?");
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
            if (index == 0) return new AttackArmy();
            else if (index == 1) return new DodgeArmy();
            else if (index == 2) return new BlackBoxArmy();
            return null;
        }
        static ArmyCreatedFactories SelectSetUnits(AbstractArmyFactory abstractArmyFactory)
        {
            ArmyCreatedFactories armyCreatedFactories = null;

            string[] menuItems = { "Сбалансированно", "Рандомно" };
            int selectedItemIndex = 0;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Как набрать воинов в армию?");
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
                        armyCreatedFactories = ExecuteMenuItemSetUnits(selectedItemIndex, abstractArmyFactory);
                        break;
                }
                if (keyInfo.Key == ConsoleKey.Enter) break;
            }
            return armyCreatedFactories;
        }
        static ArmyCreatedFactories ExecuteMenuItemSetUnits(int index, AbstractArmyFactory abstractArmyFactory)
        {
            Console.Clear();
            if (index == 0) return new BalanceArmy(abstractArmyFactory);
            else if (index == 1) return new RandomArmy(abstractArmyFactory);
            return null;
        }

        static void PrintArmy(List<IUnit> army)
        {
            for (int i = 0;i < army.Count; i++)
            {
                Console.WriteLine(army[i].ToString());
            }
        }

        static void ChoiseFirstArmy(ref List<IUnit> army1, ref List<IUnit> army2)
        {
            Console.WriteLine("Выберите армию, которая ходит первая (1 или 2): ");
            int choise;
            while (!int.TryParse(Console.ReadLine(), out choise) || choise < 1 || choise > 2)
            {
                Console.Write("Неправильный ввод данных. Попробуйте ещё раз: ");
            }
            if (choise == 2)
            {
                List<IUnit> armyHelp = army1;
                army1 = army2;
                army2 = armyHelp;
            }
        }

    }

}







/*            MakeMeleeFight a = new(army1, army2);
            Console.WriteLine(a.deffender.ToString());
            a.Execute();
            Console.WriteLine(a.deffender.ToString());*/






//Запуск основного цикла игры.
//int countStep = 1;
// Пока в одной из армий остались воины.
/*            while (army1.Count > 0 && army2.Count > 0)
            {
                Console.WriteLine("Ход номер " + countStep);
                // Проверка на декораторы, ПОМЕНЯТЬ
                Game.CheckDecorator(army1);
                Game.CheckDecorator(army2);
                // Вывод армий на экран.
                Console.WriteLine("Армия 1:");
                PrintArmy(army1);
                Console.WriteLine();
                Console.WriteLine("Армия 2:");
                PrintArmy(army2);
                Console.WriteLine();

                // Для первых 
                Game.Fight(army1, army2);

                // Вывод армий на экран.
                Console.WriteLine("Армия 1 после того, как первые побились:");
                PrintArmy(army1);
                Console.WriteLine();
                Console.WriteLine("Армия 2 после того, как первые побились::");
                PrintArmy(army2);
                Console.WriteLine();

                // Для спец свойств.
                Game.DoSpecial(army1, army2);

                countStep++;
            }*/