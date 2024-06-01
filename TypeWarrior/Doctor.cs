namespace Magic
{
    /// <summary>
    ///  Класс доктора.
    ///  Строка идентификатора "T:Magic.Doctor".
    /// </summary> 
    class Doctor : IUnit, ISpecialProperty, IHealtheble
    {
        /// <summary>
        /// Метод названия.
        /// Строка идентификатора "M:Magic.Doctor.Name".
        /// </summary>
        public override string Name() => name??"";

        /// <summary>
        /// Поле силы лечения доктора.
        /// Строка идентификатора "F:Magic.Doctor.powerTreatment".
        /// </summary>
        readonly int powerTreatment = 40;

        /// <summary>
        /// Поле процента доктора.
        /// Строка идентификатора "F:Magic.Doctor.procent".
        /// </summary>
        readonly double procent = 0.9;

        /// <summary>
        /// Метод значений доктора.
        /// Строка идентификатора "F:Magic.Doctor.procent".
        /// </summary>
        public Doctor((int, double) percentAttackAndDodge) : base(percentAttackAndDodge)
        {
            attack += 10;
            cost = 4;
            dodge += 0.1;
            defense = 0;
            name = "Доктор";
        }

        /// <summary>
        /// Метод вывода.
        /// Строка идентификатора "M:Magic.Doctor.ToString".
        /// </summary>
        /// <returns>Значения доктора.</returns>
        public override string ToString()
        {
            return string.Format($"{Name()}. Здоровье: {health} " +
                $"Сила: {attack} Стоимость: {cost} Броня {defense}  Уклонение {dodge} ");
        }

        /// <summary>
        /// Метод лечения. 
        /// Строка идентификатора "M:Magic.Doctor.Heal".
        /// </summary>
        public void Heal(int powerTreatment)
        {
            // Нельзя лечить больше, чем максимальное здоровье.
            health = (health + powerTreatment) < Settings.GetInstance(0, 0).Health 
                ? (health + powerTreatment) : Settings.GetInstance(0, 0).Health;
        }

        /// <summary>
        /// Метод получения удара. 
        /// Строка идентификатора "M:Magic.Doctor.GetHit".
        /// </summary>
        public override void GetHit(int strengthAttack)
        {
            Random random = new();
            double randomNumber = random.NextDouble();

            //Если уклонение не произошло => unit получает урон. 
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
        /// Строка идентификатора "M:Magic.Doctor.Health".
        /// </summary>
        /// <returns>Значение здоровья.</returns> 
        public override int Health()
        {
            return health;
        }

        /// <summary>
        /// Метод атаки. 
        /// Строка идентификатора "M:Magic.Doctor.Attack".
        /// </summary>
        /// <returns>Значение атаки.</returns> 
        public override int Attack()
        {
            return attack;
        }

        /// <summary>
        /// Метод защиты. 
        /// Строка идентификатора "M:Magic.Doctor.Defense".
        /// </summary>
        /// <returns>Значение защиты.</returns> 
        public override int Defense()
        {
            return defense;
        }

        /// <summary>
        /// Метод уклона. 
        /// Строка идентификатора "M:Magic.Doctor.Dodge".
        /// </summary>
        /// <returns>Значение уклона.</returns> 
        public override double Dodge()
        {
            return dodge;
        }

        /// <summary>
        /// Метод стоимости. 
        /// Строка идентификатора "M:Magic.Doctor.Cost".
        /// </summary>
        /// <returns>Значение стоипмости.</returns> 
        public override int Cost()
        {
            return cost;
        }

        /// <summary>
        /// Метод создания клона. 
        /// Строка идентификатора "M:Magic.Doctor.MakeClone".
        /// </summary>
        /// <returns>Логирование атаки.</returns> 
        public override IUnit MakeClone()
        {
            var a = new Doctor((attack - 10, dodge - 0.1))
            {
                health = health,
                defense = defense
            };
            return new LogGetAttack(a, (attack - 10, dodge - 0.1));
        }

        /// <summary>
        /// Метод создания свойств для колонны. 
        /// Строка идентификатора "M:Magic.Doctor.DoSpecialPropertyСolumn(Magic.IUnit, Magic.IUnit, int)".
        /// </summary>
        /// <returns>Ноль.</returns> 
        public IUnit? DoSpecialPropertyСolumn(List<IUnit> ownArmy,
            List<IUnit> enemyArmy, int number)
        {
            if (procent >= new Random().NextDouble())
            {
                // Если впереди стоящий существует. 
                if (number - 1 >= 0)
                {
                    if (ownArmy[number - 1] is LogGetAttack unitTemp1 
                        && unitTemp1.unit is IHealtheble patient)
                    {
                        patient.Heal(powerTreatment);
                    }
                }
                else
                {
                    // Если сзади стоящий существует.
                    if (number + 1 <= ownArmy.Count-1)
                    {
                        if (ownArmy[number + 1] is LogGetAttack unitTemp2 
                            && unitTemp2.unit is IHealtheble patient)
                        {
                            patient.Heal(powerTreatment);
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Метод создания свойтсв для батальона. 
        /// Строка идентификатора "M:Magic.Doctor.DoSpecialPropertyBattalion(Magic.IUnit, Magic.IUnit, int)".
        /// </summary>
        /// <returns>Ноль.</returns> 
        public IUnit? DoSpecialPropertyBattalion(List<IUnit> ownArmy,
            List<IUnit> enemyArmy, int number)
        {
            if (procent >= new Random().NextDouble())
            {
                // Если влева стоящий существует. 
                if (number % 3 != 0 && number - 1 >= 0)
                {
                    if (ownArmy[number - 1] is LogGetAttack unitTemp1 
                        && unitTemp1.unit is IHealtheble patient)
                    {
                        patient.Heal(powerTreatment);
                    }
                }
                // Если слева стоящий существует. 
                else if (number % 3 != 2 &&  number + 1 <= ownArmy.Count-1 )
                {
                        if (ownArmy[number + 1] is LogGetAttack unitTemp2
                        && unitTemp2.unit is IHealtheble patient)
                        {
                            patient.Heal(powerTreatment);
                        }
                }
                // Если впереди стоящий существует.
                else if (number - 3 >=0)
                {
                    if (ownArmy[number - 3] is LogGetAttack unitTemp2 
                        && unitTemp2.unit is IHealtheble patient)
                    {
                        patient.Heal(powerTreatment);
                    }
                }
                // Если сзади стоящий существует. 
                else if (number +3 <= ownArmy.Count-1)
                {
                    if (ownArmy[number + 3] is LogGetAttack unitTemp2 
                        && unitTemp2.unit is IHealtheble patient)
                    {
                        patient.Heal(powerTreatment);
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Метод создания свойств стенки на стенку. 
        /// Строка идентификатора "M:Magic.Doctor.DoSpecialPropertyWallToWall(Magic.IUnit, Magic.IUnit, int)".
        /// </summary>
        /// <returns>Ноль.</returns> 
        public IUnit? DoSpecialPropertyWallToWall(List<IUnit> ownArmy,
            List<IUnit> enemyArmy, int number)
        {
            if (procent >= new Random().NextDouble())
            {
                // Если справа стоящий существует. 
                if (number - 1 >= 0)
                {
                    if (ownArmy[number - 1] is LogGetAttack unitTemp1 
                        && unitTemp1.unit is IHealtheble patient)
                    {
                        patient.Heal(powerTreatment);
                    }
                }
                else
                {
                    // Если слева стоящий существует. 
                    if (number + 1 <= ownArmy.Count-1)
                    {
                        if (ownArmy[number + 1] is LogGetAttack unitTemp2
                            && unitTemp2.unit is IHealtheble patient)
                        {
                            patient.Heal(powerTreatment);
                        }
                    }
                }
            }
            return null;
        }
    }
}