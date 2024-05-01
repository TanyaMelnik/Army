
namespace Magic
{
    class Genetic : IUnit, ISpecialProperty, IHealtheble
    {
        public override string Name() => name;
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
            name = "Генетик";
        }

        public override string ToString()
        {
            return string.Format($"{Name()}. Здоровье: {health} Сила: {attack} Стоимость: {cost} Броня {defense}  Уклонение {dodge} ");
        }

        public IUnit DoSpecialProperty(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            // Вероятность клонирования 10% ПОМЕНЯТЬ
            if (procentClone >= new Random().NextDouble()) {
                for (int i = 0; i < ownArmy.Count; i++)
                {
                    // Если его можно клонировать 
                   // LogGetAttack unitTemp = (LogGetAttack)ownArmy[i];
                    if (ownArmy[i] is LogGetAttack lightUnit && lightUnit.unit is ICloneable clone)
                    {
                        Console.WriteLine("ГЕНЕТИКККККККККККККККККККККККККККККККККККККК");
                        return clone.Clone();
                    }
                }
            }
            return null;
        }

        public void Heal(int powerTreatment)
        {
            // Нельзя лечить больше, чем максимальное здоровье
            health = (health + powerTreatment) < Settings.GetInstance(0, 0).Health ? (health + powerTreatment) : Settings.GetInstance(0, 0).Health;
        }
        public override void GetHit(int strengthAttack)
        {
            Random random = new Random();
            double randomNumber = random.NextDouble();
            //Если уклонение не произошло => unit получает урон 
            if (dodge < randomNumber)
            {
                if (defense >= strengthAttack) defense -= strengthAttack;
                else if (defense < strengthAttack && defense > 0)
                {
                    int x = strengthAttack - defense;
                    defense = 0;
                    health -= x;
                }
                else health -= strengthAttack;
            }
            else Console.WriteLine("Произошло уклонение от атаки");
        }
        public override int Health()
        {
            return health;
        }
        public override int Attack()
        {
            return attack;
        }
        public override int Defense()
        {
            return defense;
        }
        public override double Dodge()
        {
            return dodge;
        }
        public override int Cost()
        {
            return cost;
        }
    }
}