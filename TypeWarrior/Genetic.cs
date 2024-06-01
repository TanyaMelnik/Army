namespace Magic
{
    /// <summary>
    /// Класс генерика.
    /// Строка идентификатора "T:Magic.Doctor".
    /// </summary> 
    class Genetic : IUnit, ISpecialProperty, IHealtheble
    {
        /// <summary>
        /// Метод названия.
        /// Строка идентификатора "M:Magic.Genetic.Name".
        /// </summary>
        public override string Name() => name ?? "";

        /// <summary>
        /// Поле процента клонирования.
        /// Строка идентификатора "F:Magic.Genetic.powerTreatment".
        /// </summary>
        readonly double procentClone = 0.1;

        /// <summary>
        /// Метод значений генетика.
        /// Строка идентификатора "М:Magic.Genetic.procent".
        /// </summary>
        public Genetic((int, double) percentAttackAndDodge) : 
            base(percentAttackAndDodge)
        {
            attack += 20;
            cost = 5;
            dodge += 0.4;
            defense = 10;
            name = "Генетик";
        }

        /// <summary>
        /// Метод вывода.
        /// Строка идентификатора "M:Magic.Genetic.ToString".
        /// </summary>
        /// <returns>Значения генерика.</returns>
        public override string ToString()
        {
            return string.Format($"{Name()}. Здоровье: {health} Сила: {attack} " +
                $"Стоимость: {cost} Броня {defense}  Уклонение {dodge} ");
        }

        /// <summary>
        /// Метод лечения. 
        /// Строка идентификатора "M:Magic.Genetic.Heal".
        /// </summary>
        public void Heal(int powerTreatment)
        {
            // Нельзя лечить больше, чем максимальное здоровье.
            health = (health + powerTreatment) < Settings.GetInstance(0, 0).Health 
                ? (health + powerTreatment) : Settings.GetInstance(0, 0).Health;
        }

        /// <summary>
        /// Метод получения удара. 
        /// Строка идентификатора "M:Magic.Genetic.GetHit".
        /// </summary>
        public override void GetHit(int strengthAttack)
        {
            Random random = new();
            double randomNumber = random.NextDouble();

            // Если уклонение не произошло => unit получает урон.
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
        /// Строка идентификатора "M:Magic.Genetic.Health".
        /// </summary>
        /// <returns>Значение здоровья.</returns> 
        public override int Health()
        {
            return health;
        }

        /// <summary>
        /// Метод атаки. 
        /// Строка идентификатора "M:Magic.Genetic.Attack".
        /// </summary>
        /// <returns>Значение атаки.</returns> 
        public override int Attack()
        {
            return attack;
        }

        /// <summary>
        /// Метод защиты. 
        /// Строка идентификатора "M:Magic.Genetic.Defense".
        /// </summary>
        /// <returns>Значение защиты.</returns> 
        public override int Defense()
        {
            return defense;
        }

        /// <summary>
        /// Метод уклона. 
        /// Строка идентификатора "M:Magic.Genetic.Dodge".
        /// </summary>
        /// <returns>Значение уклона.</returns> 
        public override double Dodge()
        {
            return dodge;
        }

        /// <summary>
        /// Метод стоимости. 
        /// Строка идентификатора "M:Magic.Genetic.Cost".
        /// </summary>
        /// <returns>Значение стоипмости.</returns> 
        public override int Cost()
        {
            return cost;
        }

        /// <summary>
        /// Метод создания клона. 
        /// Строка идентификатора "M:Magic.Genetic.MakeClone".
        /// </summary>
        /// <returns>Логирование атаки.</returns> 
        public override IUnit MakeClone()
        {
            var a = new Genetic((attack - 20, dodge - 0.4))
            {
                health = health,
                defense = defense
            };

            return new LogGetAttack(a, (attack - 20, dodge - 0.4));
        }

        /// <summary>
        /// Метод создания свойств для колонны. 
        /// Строка идентификатора "M:Magic.Genetic.DoSpecialPropertyСolumn(Magic.IUnit, Magic.IUnit, int)".
        /// </summary>
        /// <returns>Ноль.</returns> 
        public IUnit? DoSpecialPropertyСolumn(List<IUnit> ownArmy, 
            List<IUnit> enemyArmy, int number)
        {
            if (procentClone >= new Random().NextDouble())
            {
                for (int i = 0; i < ownArmy.Count; i++)
                {
                    if (ownArmy[i] is LogGetAttack lightUnit && 
                        lightUnit.unit is ICloneable clone)
                    {
                        return clone.Clone();
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Метод создания свойтсв для батальона. 
        /// Строка идентификатора "M:Magic.Genetic.DoSpecialPropertyBattalion(Magic.IUnit, Magic.IUnit, int)".
        /// </summary>
        /// <returns>Ноль.</returns> 
        public IUnit? DoSpecialPropertyBattalion(List<IUnit> ownArmy, 
            List<IUnit> enemyArmy, int number)
        {
            if (procentClone >= new Random().NextDouble())
            {
                for (int i = 0; i < ownArmy.Count; i++)
                {
                    if (ownArmy[i] is LogGetAttack lightUnit && 
                        lightUnit.unit is ICloneable clone)
                    {
                        return clone.Clone();
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Метод создания свойств стенки на стенку. 
        /// Строка идентификатора "M:Magic.Genetic.DoSpecialPropertyWallToWall(Magic.IUnit, Magic.IUnit, int)".
        /// </summary>
        /// <returns>Ноль.</returns> 
        public IUnit? DoSpecialPropertyWallToWall(List<IUnit> ownArmy, 
            List<IUnit> enemyArmy, int number)
        {
            if (procentClone >= new Random().NextDouble())
            {
                for (int i = 0; i < ownArmy.Count; i++)
                {
                    if (ownArmy[i] is LogGetAttack lightUnit && lightUnit.unit
                        is ICloneable clone)
                    {
                        return clone.Clone();
                    }
                }
            }
            return null;
        }
    }
}