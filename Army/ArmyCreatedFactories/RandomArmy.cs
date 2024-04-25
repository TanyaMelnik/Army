using Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    class RandomArmy(AbstractArmyFactory army, Settings setting) : ArmyCreatedFactories(army, setting)
    {
        private readonly Random random = new();

        public override List<IUnit> CreateArmy(int cost)
        {
            List<IUnit> army = [];
            while (cost >0)
            {
                // Получаем случайный индекс типа юнита из словаря
                int randomIndex = random.Next(unitCost.Count);

                // Получаем тип юнита по случайному индексу
                Type unitType = unitCost.Keys.ElementAt(randomIndex);

                // Получаем стоимость юнита
                int unitCostValue = unitCost.Values.ElementAt(randomIndex);

                // Если стоимость юнита не превышает оставшийся бюджет
                if (unitCostValue <= cost)
                {
                    // Создаем экземпляр юнита и добавляем его в армию
                    //var unitInstance = Activator.CreateInstance(unitType) as IUnit;
                    var unit = CreateUnit(unitType);
                    if (unit != null)
                    {
                        army.Add(unit);
                    }
                    // Вычитаем стоимость юнита из оставшегося бюджета
                    cost -= unitCostValue;
                }
            }
            return army;
        }
    }
}
