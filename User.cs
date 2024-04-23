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
        public static void UserGame()
        {
            Console.WriteLine("Начинаем новую игру!");
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
