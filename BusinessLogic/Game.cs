using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Magic;

namespace Game.BusinessLogic
{
    public interface IUnitFactory
    {
        List<IUnit> CreateArmy(int cost);
    }

    /* enum UnitType
     {
         LightWarrior,
         HeavyWarrior,
         Genetic,
         Doctor,
         Bowman,
     }*/

    // Переделать под фабрику!!!!!!!
    internal class Game
    {
        Dictionary<Type, double> unitCost = [];
        private Random random = new Random();
        public Game()
        {
            // Получаем текущую сборку (assembly)
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Получаем массив всех типов в текущей сборке
            Type[] unitTypes = assembly.GetTypes()
                // Фильтруем только те типы, которые являются наследниками IUnit
                .Where(t => t.IsSubclassOf(typeof(IUnit)))
                // Преобразуем результат в массив
                .ToArray();

            // Перебираем каждый найденный тип
            foreach (Type unitType in unitTypes)
            {
                // Создаем экземпляр типа, чтобы получить его стоимость
                var unitInstance = Activator.CreateInstance(unitType) as IUnit;

                // Добавляем тип IUnit и его стоимость в словарь
                if (unitInstance != null)
                {
                    unitCost.Add(unitType, unitInstance.GetCost());
                }
            }

        }
        // ДОЛЖЕН БЫТЬ ФАБРИЧНЫЙ МЕТОД !!!
        public List<IUnit> CreateArmy(int cost)
        {
            List<IUnit> army = new List<IUnit>();
            while (cost != 0)
            {
                UnitType randomUnitType = (UnitType)random.Next(Enum.GetNames(typeof(UnitType)).Length);

                switch (randomUnitType)
                {
                    case UnitType.LightWarrior:
                        army.Add(new LightWarrior());
                        break;
                    case UnitType.HeavyWarrior:
                        army.Add(new HeavyWarrior());
                        break;
                    case UnitType.Genetic:
                        army.Add(new Genetic());
                        break;
                    case UnitType.Doctor:
                        army.Add(new Doctor());
                        break;
                    case UnitType.Bowman:
                        army.Add(new Bowman());
                        break;

                }
            }

            return army;
        }

    }
}
