using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Magic;
using static System.Net.Mime.MediaTypeNames;

namespace Game
{
    class User
    {
        public static void Start()
        {
            // Изменить на клавиши / ПОМЕНЯТЬ НА ЧТО-ТО 
            while (true)
            {
                Console.WriteLine("Введите 0, если хотите выйти из игры. Введите 1, если хотите начать игру");
                // _ говорит компилятору, что эту переменную не будем использовать
                _ = int.TryParse(Console.ReadLine(), out int answer);
                switch (answer)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        UserGame();
                        break;
                    default:
                        Console.WriteLine("Неверный вывод");
                        break;
                }
            }
        }
        public static void UserGame()
        {
            // ЗАДАЧА 1
            // Запрашиваем данные у пользователя о длительности игры и вместимости (cost) армии, передаем их в конструктор Settings
            // Создаём экземпляр Settings и заполняем данные в конструкторе 
            int cost = 10;
            List<IUnit> army1 = CreateArmy(cost);
            List<IUnit> army2 = CreateArmy(cost);

        }

        static List<IUnit> CreateArmy(int cost)
        {
            // ЗАДАЧА 2
            //Логика создания армий
            // Добавить выбор создания разных арммий 
            List<IUnit> army = new();
            //army=Ga,
            return army;
        }
    }

}
