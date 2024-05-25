using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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

                // Инициализация настроек. Это не пункт меню, так как это устанавливается один раз и это нельзя поменять.
                UserSettings();
                // Основной цикл игры.
                bool flag = true;
                bool game = true;
                // Инициализация изначальных данных.
                Invoker invoker = new();
                while (flag)
                {
                    Console.WriteLine("Выберите пункт меню");
                    Console.WriteLine("1. Сделать ход");
                    Console.WriteLine("2. Отменить");
                    Console.WriteLine("3. Повторить");
                    Console.WriteLine("4. Поменять построение");
                    Console.WriteLine("5. Закончить текущую игру");
                    Console.WriteLine("6. Проиграть игру до конца");
                    int menu;
                    Console.Write("Ваш ответ: ");
                    while (!int.TryParse(Console.ReadLine(), out menu) || menu < 1 || menu > 6)
                    {
                        Console.Write("Неправильный ввод данных. Попробуйте ещё раз: ");
                    }
                    switch (menu)
                    {
                        case 1:
                            if (game)
                            {
                                ICommand StartMakeMove = new MakeMove(invoker.GetStategy());
                                Console.WriteLine("Армия до битвы:");
                                Console.WriteLine(StartMakeMove.TypeConstruction.Show());
                                invoker.AddCommand(StartMakeMove);
                                game = invoker.ExecuteCommand();
                                Console.WriteLine("Армия после битвы:");
                                Console.WriteLine(StartMakeMove.TypeConstruction.Show());
                            }
                            else Console.WriteLine("В армии нет людей");
                            break;
                        case 2:
                            bool flagUndo = invoker.UndoCommand();
                            if (!flagUndo) Console.WriteLine("Отмену выполнить невозможно! Сначала сделайте действие!");
                            else Console.WriteLine(invoker.Commands[invoker.Count + 1].TypeConstruction.Show());               
                            game = true;
                            break;
                        case 3:
                            if (game)
                            {
                                bool flagRedo = invoker.RedoCommand();
                                if (!flagRedo) Console.WriteLine("Повтор выполнить невозможно! Сначала отмените действие!");
                                else Console.WriteLine(invoker.Commands[invoker.Count + 1].TypeConstruction.Show());
                            }
                            else Console.WriteLine("В армии нет людей");
                            break;
                        case 4:
                            if (game)
                            {
                                ICommand ChangeTypeConstruction = new ChangeTypeConstruction(invoker.GetStategy());
                                invoker.AddCommand(ChangeTypeConstruction);
                                invoker.ExecuteCommand();
                                Console.WriteLine($"Поменяли построение на " + invoker.GetStategy());
                            }
                            else Console.WriteLine("В армии нет людей");
                            break;
                        case 5:
                            flag = false;
                            break;
                        case 6:
                            while (game)
                            {
                                ICommand StartMakeMoveAll = new MakeMove(invoker.GetStategy());
                                invoker.AddCommand(StartMakeMoveAll);
                                game = invoker.ExecuteCommand();
                                Console.WriteLine(StartMakeMoveAll.TypeConstruction.Show());
                            }
                            if (game == false) Console.WriteLine("В армии нет людей");
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

        public static ITypeConstruction ChooseStrategy()
        {
            // Создание первой армии. 
            AbstractArmyFactory abstractArmyFactory1 = AddUnitStats() ?? new BlackBoxArmy(); ;
            ArmyCreatedFactories armyCreatedFactories1 = SelectSetUnits(abstractArmyFactory1)?? new RandomArmy(abstractArmyFactory1); 
            List<IUnit> army1 = armyCreatedFactories1.CreateArmy();

            // Создание второй армии.
            AbstractArmyFactory abstractArmyFactory2 = AddUnitStats() ?? new BlackBoxArmy(); ;
            ArmyCreatedFactories armyCreatedFactories2 = SelectSetUnits(abstractArmyFactory2) ?? new RandomArmy(abstractArmyFactory2); ;
            List<IUnit> army2 = armyCreatedFactories2.CreateArmy();

            // Выбор армии, которая ходит первая.
            ChoiseFirstArmy(ref army1, ref army2);
            // Выбор построения армий, вынести в отдельную функцию.
            Console.WriteLine("Выберите тип построения армий");
            Console.WriteLine("1. Колонна");
            Console.WriteLine("2. Три в ряд");
            Console.WriteLine("3. Стенка на стенку");
            Console.Write("Ваш ответ: ");
            int TypeConstruction;
            while (!int.TryParse(Console.ReadLine(), out TypeConstruction) || TypeConstruction < 1 || TypeConstruction > 3)
            {
                Console.Write("Неправильный ввод данных. Попробуйте ещё раз: ");
            }
            return TypeConstruction switch
            {
                1 => new Сolumn(army1, army2),
                2 => new Battalion(army1, army2),
                _ => new WallToWall(army1, army2),
            };
        }



        static void UserSettings()
        {
            // Ввод стоимость армий пользователем.
            int cost = SetCost();

            // Ввод пользователем длительности игры.
            int health = Healht();

            Console.Write("Включить звук при убийстве юнита - введите true. Выключить звуки - введите false:  ");
            while (!bool.TryParse(Console.ReadLine(), out Settings.sound))
            {
                Console.Write("Неправильный ввод данных. Попробуйте ещё раз: ");
            }
            // Паттерн Singleton. 
            Settings.GetInstance(health, cost);

        }
        static int Healht()
        {
            int health = -1;

            Console.CursorVisible = false;

            string[] menuItems = ["Короткие", "Средние", "Длинные"];
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

        static AbstractArmyFactory? AddUnitStats()
        {
            AbstractArmyFactory? abstractArmyFactory = null;

            string[] menuItems = ["С сильной атакой", "С большим процентом уклонения", "С рандомными характеристиками"];
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
            return new BlackBoxArmy();
        }
        static ArmyCreatedFactories? SelectSetUnits(AbstractArmyFactory abstractArmyFactory)
        {
            ArmyCreatedFactories? armyCreatedFactories = null;

            string[] menuItems = ["Сбалансированно", "Рандомно"];
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
            return new RandomArmy(abstractArmyFactory);
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
                (army2, army1) = (army1, army2);
            }
        }

    }

}





