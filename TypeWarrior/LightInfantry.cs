namespace Magic 
{
    /// <summary>
    /// Класс легкого воина.
    /// Строка идентификатора "T:Magic.HeavyWarrior".
    /// </summary> 
    class LightWarrior : IUnit, ICloneable,IHealtheble
    {
        /// <summary>
        /// Метод названия.
        /// Строка идентификатора "M:Magic.LightWarrior.Name".
        /// </summary>
        public override string Name() => name ?? "";

        /// <summary>
        /// Метод значений легкого воина.
        /// Строка идентификатора "М:Magic.LightWarrior.LightWarrior".
        /// </summary>
        public LightWarrior((int , double ) percentAttackAndDodge) : base(percentAttackAndDodge)
        {
            attack += 40;
            cost = 1;
            dodge += 0.2;
            defense = 50;
            name = "Легкий солдат";
        }

        /// <summary>
        /// Метод клонирования.
        /// Строка идентификатора "М:Magic.LightWarrior.Clone".
        /// </summary>
        public IUnit Clone()
        {
            return new LogGetAttack(new LightWarrior((attack - 40, 
                dodge - 0.2)), (attack-40, dodge-0.2));
        }

        /// <summary>
        /// Метод вывода.
        /// Строка идентификатора "M:Magic.LightWarrior.ToString".
        /// </summary>
        /// <returns>Значения генерика.</returns>
        public override string ToString()
        {
            return string.Format($"{Name()}. Здоровье: {health} " +
                $"Сила: {attack} Стоимость: {cost} Броня {defense} Уклонение {dodge}");
        }

        /// <summary>
        /// Метод лечения. 
        /// Строка идентификатора "M:Magic.LightWarrior.Heal".
        /// </summary>
        public void Heal(int powerTreatment)
        {
            // Нельзя лечить больше, чем максимальное здоровье.
            health = (health + powerTreatment) < Settings.GetInstance(0, 0).Health 
                ? (health + powerTreatment) : Settings.GetInstance(0, 0).Health;
        }

        /// <summary>
        /// Метод получения удара. 
        /// Строка идентификатора "M:Magic.LightWarrior.GetHit".
        /// </summary>
        public override void GetHit(int strengthAttack)
        {
            Random random = new();
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

        /// <summary>
        /// Метод здоровья. 
        /// Строка идентификатора "M:Magic.LightWarrior.Health".
        /// </summary>
        /// <returns>Значение здоровья.</returns> 
        public override int Health()
        {
            return health;
        }


        /// <summary>
        /// Метод атаки. 
        /// Строка идентификатора "M:Magic.LightWarrior.Attack".
        /// </summary>
        /// <returns>Значение атаки.</returns> 
        public override int Attack()
        {
            return attack;
        }

        /// <summary>
        /// Метод защиты. 
        /// Строка идентификатора "M:Magic.LightWarrior.Defense".
        /// </summary>
        /// <returns>Значение защиты.</returns> 
        public override int Defense()
        {
            return defense;
        }

        /// <summary>
        /// Метод уклона. 
        /// Строка идентификатора "M:Magic.LightWarrior.Dodge".
        /// </summary>
        /// <returns>Значение уклона.</returns> 
        public override double Dodge()
        {
            return dodge;
        }

        /// <summary>
        /// Метод стоимости. 
        /// Строка идентификатора "M:Magic.LightWarrior.Cost".
        /// </summary>
        /// <returns>Значение стоипмости.</returns> 
        public override int Cost()
        {
            return cost;
        }

        /// <summary>
        /// Метод создания клона. 
        /// Строка идентификатора "M:Magic.LightWarrior.MakeClone".
        /// </summary>
        /// <returns>Логирование атаки.</returns> 
        public override IUnit MakeClone()
        {
            var a = new LightWarrior((attack - 40, dodge - 0.2))
            {
                health = health,
                defense = defense
            };
            return new LogGetAttack(a, (attack - 40, dodge - 0.2));
        }
    } 
}