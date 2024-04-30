
namespace Magic
{
    class Bowman : IUnit, ISpecialProperty, ICloneable, IHealtheble
    {
        public Bowman((int, double) percentAttackAndDodge) : base(percentAttackAndDodge)
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
            return string.Format($"Лучник. Здоровье: {health} Сила: {attack} Стоимость: {cost} Броня {defense}  Уклонение {dodge} ");
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
                // Рандомно выбираем цель. От 0 включительно до countEnemy не включительно
                int aim = new Random().Next(0, countEnemy);
                // Цель выбрана - enemyArmy[aim]
                enemyArmy[aim].GetHit(arrowDamage);
                ProxyDie proxy = new(new DeadUnit());
                if (enemyArmy[aim].Health() < 0) proxy.DeleteUnit(enemyArmy, aim);
            }
            return null;
        }
        public IUnit Clone()
        {
            return new LogGetAttack(new Bowman((attack - 20, dodge - 0.3)), (attack - 20, dodge - 0.3));
        }

        public void Heal(int arrowDamage)
        {
            // Нельзя лечить больше, чем максимальное здоровье
            health = (health + arrowDamage) < Settings.GetInstance(0, 0).Health ? (health + arrowDamage) : Settings.GetInstance(0, 0).Health;
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
                else health -= attack;
            }

        }
        public override int Health()
        {
            return health;
        }
        public override int Attack()
        {
            return attack;
        }
    }
}