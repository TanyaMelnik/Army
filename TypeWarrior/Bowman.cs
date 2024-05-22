
namespace Magic
{
    class Bowman : IUnit, ISpecialProperty, ICloneable, IHealtheble
    {
        public override string Name() => name;
        public Bowman((int, double) percentAttackAndDodge) : base(percentAttackAndDodge)
        {
            attack += 20;
            cost = 3;
            dodge += 0.3;
            defense = 30;
            name = "Лучник";
        }

        // Уникальные характеристики лучника.
        int radiusAttack = 10;
        int arrowDamage = 40;
        double procent = 0.9;

        public override string ToString()
        {
            return string.Format($"{Name()}. Здоровье: {health} Сила: {attack} Стоимость: {cost} Броня {defense}  Уклонение {dodge} ");
        }

        public IUnit Clone()
        {
            return new LogGetAttack(new Bowman((attack - 20, dodge - 0.3)), (attack - 20, dodge - 0.3));
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

        public override IUnit MakeClone()
        {
            var a = new Bowman((attack - 20, dodge - 0.3));
            a.health = health;
            a.defense = defense;
            return new LogGetAttack(a, (attack - 20, dodge - 0.3));
        }

        public IUnit DoSpecialPropertyСolumn(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            if (procent >= new Random().NextDouble())
            {
                if (enemyArmy.Count + 1 > 0)
                {
                    if (number < radiusAttack)
                    {
                        // Теоретическое количество врагов, в которых он может попасть.
                        int countEnemy = radiusAttack - number;
                        // Если количество противников меньше найденного числа.
                        if (countEnemy > enemyArmy.Count) countEnemy = enemyArmy.Count;
                        // Рандомно выбираем цель. От 0 включительно до countEnemy не включительно
                        int aim = new Random().Next(0, countEnemy);
                        // Цель выбрана - enemyArmy[aim]
                        enemyArmy[aim].GetHit(arrowDamage);
                    }
                }
            }
            return null;
        }

        public IUnit DoSpecialPropertyBattalion(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            if (procent >= new Random().NextDouble())
            {
                if (enemyArmy.Count > 0)
                {
                    if (number < radiusAttack*3)
                    {
                        // Теоретическое количество врагов, в которых он может попасть. нужно разделить на 3, округлить вверх и умнножить на 3
                        double a = (radiusAttack * 3 - number) / 3.0;
                        double b = Math.Ceiling(a);
                        int countEnemy = (int)b*3;
                        // Если количество противников меньше найденного числа.
                        if (countEnemy > enemyArmy.Count) countEnemy = enemyArmy.Count;
                        // Рандомно выбираем цель. От 0 включительно до countEnemy не включительно
                        int aim = new Random().Next(0, countEnemy);
                        // Цель выбрана - enemyArmy[aim]
                        enemyArmy[aim].GetHit(arrowDamage);
                    }
                }
            }
            return null;
        }

        public IUnit DoSpecialPropertyWallToWall(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            if (procent >= new Random().NextDouble())
            {
                if (enemyArmy.Count > 0)
                {
                    // Первый враг, в который может попасть лучник
                    int endEnemy = enemyArmy.Count - 1 >= number - radiusAttack + 1 ? enemyArmy.Count - 1 : -1;
                    // Если радиус меньше чем дальность до первого врага
                    if (endEnemy<0)
                    {
                        return null;
                    }
                    // Последний враг, в который может попасть лучник
                    int startEnemy = number - radiusAttack + 1>= 0? number - radiusAttack + 1:0;
                    // Рандомно выбираем цель. От startEnemy включительно до endEnemy не включительно
                    int aim = new Random().Next(startEnemy, endEnemy+1);
                    // Цель выбрана - enemyArmy[aim]
                    enemyArmy[aim].GetHit(arrowDamage);
                }
            }
            return null;
        }
    }
}