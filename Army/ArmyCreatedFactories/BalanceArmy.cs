using Magic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    class BalanceArmy(AbstractArmyFactory army, Settings setting) : ArmyCreatedFactories(army,setting)
    {
        public override List<IUnit> CreateArmy(int cost)
        {
            List<IUnit> army = [];
            // Сортируем типы юнитов по возрастанию стоимости
            var sortedUnitTypes = unitCost.OrderBy(pair => pair.Value);

            // Создаем армию с учетом сбалансированности
            foreach (var unitTypePair in sortedUnitTypes)
            {
                var unitType = unitTypePair.Key;
                var unitCostValue = unitTypePair.Value;

                // Создаем экземпляр юнита и добавляем его в армию
                var unit = CreateUnit(unitType);
                if (unit != null)
                {
                    army.Add(unit);
                    // Вычитаем стоимость созданного юнита из общей стоимости
                    cost -= unitCostValue;
                }
            }

            return army;
        }
    }
}
