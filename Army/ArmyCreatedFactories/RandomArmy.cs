﻿namespace Magic
{
    /// <summary>
    ///  Класс рандомной армии.
    ///  Строка идентификатора "T:Magic.RandomArmy".
    /// </summary>
    class RandomArmy(AbstractArmyFactory army) : ArmyCreatedFactories(army)
    {
        /// <summary>
        /// Поле, содержащее рандомное значение.
        /// Строка идентификатора "F:Magic.RandomArmy.random".
        /// </summary>
        private readonly Random random = new();

        /// <summary>
        ///  Метод создания рандомной армии.
        ///  Строка идентификатора "M:Magic.RandomArmy.CreateArmy".
        /// </summary>
        public override List<IUnit> CreateArmy()
        {
            int cost = Settings.GetInstance(0, 0).Cost;
            List<IUnit> army = [];

            while (cost > 0)
            {
                // Получаем случайный индекс типа юнита из словаря.
                int randomIndex = random.Next(unitCost.Count);

                // Получаем тип юнита по случайному индексу.
                Type unitType = unitCost.Keys.ElementAt(randomIndex);

                // Получаем стоимость юнита
                int unitCostValue = unitCost.Values.ElementAt(randomIndex);

                // Если стоимость юнита не превышает оставшийся бюджет.
                if (unitCostValue <= cost)
                {
                    // Создаем экземпляр юнита и добавляем его в армию.
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