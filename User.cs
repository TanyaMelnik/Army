using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    class User
{
	void Start()
    {
        Console.WriteLine("Введите 0, если хотите выйти из игры. Введите 1, если хотите начать игру");
            //ParseToInt(Console.ReadLine());
            var answer = 2;
		switch (answer)

        {

            case 0:
                //exit(1);
                break;
            case 1:
                UserGame();
                break;
            }
        }
	void UserGame()

    {
            // ЗАДАЧА 1
            // Запрашиваем данные у пользователя о длительности игры и вместимости (cost) армии, передаем их в конструктор Settings
            // Создаём экземпляр Settings и заполняем данные в конструкторе 
            int cost = 10;
            List<IUnit> army1 = CreateArmy(cost);
            List<IUnit> army2 = CreateArmy(cost);

        }

        List<IUnit> CreateArmy(int cost)

    {
            // ЗАДАЧА 2
            //Логика создания армий
            List<IUnit> army = new List<IUnit>();
            return army;
        }
    }


}
