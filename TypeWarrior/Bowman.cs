namespace Magic
{
    /// <summary>
    ///  Класс лучника.
    ///  Строка идентификатора "T:Magic.Сolumn".
    /// </summary> 
    class Bowman : IUnit, ISpecialProperty, ICloneable, IHealtheble
    {
        /// <summary>
        /// Метод названия.
        /// Строка идентификатора "M:Magic.Bowman.Name".
        /// </summary>
        public override string Name() => name ?? "";

        /// <summary>
        /// Метод параметров лучника.
        /// Строка идентификатора "M:Magic.Bowman.Bowman(int, double)".
        /// </summary>
        public Bowman((int, double) percentAttackAndDodge) : base(percentAttackAndDodge)
        {
            attack += 20;
            cost = 3;
            dodge += 0.3;
            defense = 30;
            name = "Лучник";
        }

        /// <summary>
        /// Поле радиуса атаки лучника.
        /// Строка идентификатора "F:Magic.Bowman.radiusAttack".
        /// </summary>
        readonly int radiusAttack = 10;

        /// <summary>
        /// Поле урона лучника.
        /// Строка идентификатора "F:Magic.Bowman.arrowDamage".
        /// </summary>
        readonly int arrowDamage = 40;

        /// <summary>
        /// Поле процента лучника.
        /// Строка идентификатора "F:Magic.Bowman.procent".
        /// </summary>
        readonly double procent = 0.9;

        /// <summary>
        /// Метод вывода.
        /// Строка идентификатора "M:Magic.Bowman.ToString".
        /// </summary>
        /// <returns>Значения лучника.</returns> 
        public override string ToString()
        {
            return string.Format($"{Name()}. Здоровье: {health} " +
                $"Сила: {attack} Стоимость: {cost} Броня {defense}  " +
                $"Уклонение {dodge} ");
        }

        /// <summary>
        /// Метод клонирования. 
        /// Строка идентификатора "M:Magic.Bowman.Clone".
        /// </summary>
        /// <returns>Логирование атаки.</returns> 
        public IUnit Clone()
        {
            return new LogGetAttack(new Bowman((attack - 20, 
                dodge - 0.3)), (attack - 20, dodge - 0.3));
        }

        /// <summary>
        /// Метод лечения. 
        /// Строка идентификатора "M:Magic.Bowman.Heal".
        /// </summary>
        public void Heal(int powerTreatment)
        {
            // Нельзя лечить больше, чем максимальное здоровье.
            health = (health + powerTreatment) < Settings.GetInstance(0, 
                0).Health ? (health + powerTreatment) : Settings.GetInstance(0, 0).Health;
        }

        /// <summary>
        /// Метод получения удара. 
        /// Строка идентификатора "M:Magic.Bowman.GetHit".
        /// </summary>
        public override void GetHit(int strengthAttack)
        {
            Random random = new ();
            double randomNumber = random.NextDouble();

            // Если уклонение не произошло, то unit получает урон.
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

        /// <summary>
        /// Метод здоровья. 
        /// Строка идентификатора "M:Magic.Bowman.Health".
        /// </summary>
        /// <returns>Значение здоровья.</returns> 
        public override int Health()
        {
            return health;
        }

        /// <summary>
        /// Метод атаки. 
        /// Строка идентификатора "M:Magic.Bowman.Attack".
        /// </summary>
        /// <returns>Значение атаки.</returns> 
        public override int Attack()
        {
            return attack;
        }

        /// <summary>
        /// Метод защиты. 
        /// Строка идентификатора "M:Magic.Bowman.Defense".
        /// </summary>
        /// <returns>Значение защиты.</returns> 
        public override int Defense()
        {
            return defense;
        }

        /// <summary>
        /// Метод уклона. 
        /// Строка идентификатора "M:Magic.Bowman.Dodge".
        /// </summary>
        /// <returns>Значение уклона.</returns> 
        public override double Dodge()
        {
            return dodge;
        }

        /// <summary>
        /// Метод стоимости. 
        /// Строка идентификатора "M:Magic.Bowman.Cost".
        /// </summary>
        /// <returns>Значение стоипмости.</returns> 
        public override int Cost()
        {
            return cost;
        }

        /// <summary>
        /// Метод создания клона. 
        /// Строка идентификатора "M:Magic.Bowman.MakeClone".
        /// </summary>
        /// <returns>Логирование атаки.</returns> 
        public override IUnit MakeClone()
        {
            var a = new Bowman((attack - 20, dodge - 0.3))
            {
                health = health,
                defense = defense
            };

            return new LogGetAttack(a, (attack - 20, dodge - 0.3));
        }

        /// <summary>
        /// Метод создания свойств для колонны. 
        /// Строка идентификатора "M:Magic.Bowman.DoSpecialPropertyСolumn(Magic.IUnit, Magic.IUnit, int)".
        /// </summary>
        /// <returns>Ноль.</returns> 
        public IUnit? DoSpecialPropertyСolumn(List<IUnit> ownArmy, 
            List<IUnit> enemyArmy, int number)
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

                        // Рандомно выбираем цель. От 0 включительно до countEnemy не включительно.
                        int aim = new Random().Next(0, countEnemy);

                        // Цель выбрана - enemyArmy[aim].
                        enemyArmy[aim].GetHit(arrowDamage);
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Метод создания свойтсв для батальона. 
        /// Строка идентификатора "M:Magic.Bowman.DoSpecialPropertyBattalion(Magic.IUnit, Magic.IUnit, int)".
        /// </summary>
        /// <returns>Ноль.</returns> 
        public IUnit? DoSpecialPropertyBattalion(List<IUnit> ownArmy, 
            List<IUnit> enemyArmy, int number)
        {
            if (procent >= new Random().NextDouble())
            {
                if (enemyArmy.Count > 0)
                {
                    if (number < radiusAttack*3)
                    {
                        // Теоретическое количество врагов, в которых он может попасть.
                        // нужно разделить на 3, округлить вверх и умнножить на 3.
                        double a = (radiusAttack * 3 - number) / 3.0;
                        double b = Math.Ceiling(a);
                        int countEnemy = (int)b*3;

                        // Если количество противников меньше найденного числа.
                        if (countEnemy > enemyArmy.Count) countEnemy = enemyArmy.Count;

                        // Рандомно выбираем цель. От 0 включительно до countEnemy
                        // не включительно.
                        int aim = new Random().Next(0, countEnemy);

                        // Цель выбрана - enemyArmy[aim].
                        enemyArmy[aim].GetHit(arrowDamage);
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Метод создания свойств стенки на стенку. 
        /// Строка идентификатора "M:Magic.Bowman.DoSpecialPropertyWallToWall(Magic.IUnit, Magic.IUnit, int)".
        /// </summary>
        /// <returns>Ноль.</returns> 
        public IUnit? DoSpecialPropertyWallToWall(List<IUnit> ownArmy, 
            List<IUnit> enemyArmy, int number)
        {
            if (procent >= new Random().NextDouble())
            {
                if (enemyArmy.Count > 0)
                {
                    // Первый враг, в который может попасть лучник.
                    int endEnemy = enemyArmy.Count - 1 >= number - radiusAttack + 1 ? 
                        enemyArmy.Count - 1 : -1;

                    // Если радиус меньше чем дальность до первого врага.
                    if (endEnemy<0)
                    {
                        return null;
                    }

                    // Последний враг, в который может попасть лучник.
                    int startEnemy = number - radiusAttack + 1>= 0? number - radiusAttack + 1:0;

                    // Рандомно выбираем цель. От startEnemy включительно до endEnemy не включительно.
                    int aim = new Random().Next(startEnemy, endEnemy+1);

                    // Цель выбрана - enemyArmy[aim].
                    enemyArmy[aim].GetHit(arrowDamage);
                }
            }
            return null;
        }
    }
}