
namespace Magic
{
    class Genetic : IUnit, ISpecialProperty, IHealtheble
    {
        /// <summary>
        /// Процент клонирования - 10%
        /// </summary>
        double procentClone=0.1;
        public Genetic((int, double) percentAttackAndDodge) : base(percentAttackAndDodge)
        {
            attack += 20;
            cost = 5;
            dodge += 0.4;
            defense = 10;
        }

        public override string ToString()
        {
            return string.Format($"Генетик. Здоровье: {health} Сила: {attack} Стоимость: {cost} Броня {defense}  Уклонение {dodge} ");
        }

        public IUnit DoSpecialProperty(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            // Вероятность клонирования 10%
            if (procentClone >= new Random().NextDouble()) {
                for (int i = 0; i < ownArmy.Count; i++)
                {
                    // Если его можно клонировать 
                    if (ownArmy[i] is ICloneable clone)
                    {
                        return clone.Clone();
                    }
                }
            }
            return null;
        }

        public void Heal(int arrowDamage)
        {
            // Нельзя лечить больше, чем максимальное здоровье
            health = (health + arrowDamage) < Settings.GetInstance(0, 0).Health ? (health + arrowDamage) : Settings.GetInstance(0, 0).Health;
        }
    }
}