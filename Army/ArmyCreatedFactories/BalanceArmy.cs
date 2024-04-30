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
    class BalanceArmy(AbstractArmyFactory army) : ArmyCreatedFactories(army)
    {
        public override List<IUnit> CreateArmy()
        {
            int cost = Settings.GetInstance(0, 0).Cost;
            List<IUnit> army = [];
            // Сортируем типы юнитов по возрастанию стоимости
            var sortedUnitTypes = unitCost.OrderBy(pair => pair.Value);
            while (cost > 0)
            {
                // Создаем армию с учетом сбалансированности
                foreach (var unitTypePair in sortedUnitTypes)
                {
                    if (cost <= 0){
                        return army;
                    }
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
            }
            return army;
        }
    }
}
