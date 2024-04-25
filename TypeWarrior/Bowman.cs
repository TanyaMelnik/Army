using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Magic
{
    class Bowman : IUnit, ISpecialProperty
    {
        public Bowman(Settings settings, (int, double) percentAttackAndDodge) : base(settings, percentAttackAndDodge)
        {
            attack += 20;
            cost = 3;
            dodge += 0.3;
            defense = 30;
        }

        // Уникальные характеристики лучника.
        int radiusAttack = 10;
        int arrowDamage = 40;

        public override string ToString()
        {
            return string.Format($"Тяжёлый Солдат. Здоровье: {health} Сила: {health} Стоимость: {cost} Броня {defense} ");
        }



        // number - это порядковый номер лучника в списке (от 1 до размера своей армии)
        public IUnit DoSpecialProperty(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            if (number < radiusAttack + 1)
            {
                // Теоретическое количество врагов, в которых он может попасть.
                int countEnemy = (radiusAttack + 1) - number;
                // Если количество противников меньше найденного числа.
                if (countEnemy > enemyArmy.Count) countEnemy = enemyArmy.Count;

                // Рандомно выбираем цель.
                var rand = new Random();
                // От 0 включительно до countEnemy не включительно
                int aim = rand.Next(0, countEnemy);

                // Цель выбрана - enemyArmy[aim]

                enemyArmy[aim].GetHit(arrowDamage);
            }
            return null;
        }

    }
}