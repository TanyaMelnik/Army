namespace Magic
{
    /// <summary>
    ///  ����� �������.
    ///  ������ �������������� "T:Magic.Doctor".
    /// </summary> 
    class Doctor : IUnit, ISpecialProperty, IHealtheble
    {
        /// <summary>
        /// ����� ��������.
        /// ������ �������������� "M:Magic.Doctor.Name".
        /// </summary>
        public override string Name() => name??"";

        /// <summary>
        /// ���� ���� ������� �������.
        /// ������ �������������� "F:Magic.Doctor.powerTreatment".
        /// </summary>
        readonly int powerTreatment = 40;

        /// <summary>
        /// ���� �������� �������.
        /// ������ �������������� "F:Magic.Doctor.procent".
        /// </summary>
        readonly double procent = 0.9;

        /// <summary>
        /// ����� �������� �������.
        /// ������ �������������� "F:Magic.Doctor.procent".
        /// </summary>
        public Doctor((int, double) percentAttackAndDodge) : base(percentAttackAndDodge)
        {
            attack += 10;
            cost = 4;
            dodge += 0.1;
            defense = 0;
            name = "������";
        }

        /// <summary>
        /// ����� ������.
        /// ������ �������������� "M:Magic.Doctor.ToString".
        /// </summary>
        /// <returns>�������� �������.</returns>
        public override string ToString()
        {
            return string.Format($"{Name()}. ��������: {health} " +
                $"����: {attack} ���������: {cost} ����� {defense}  ��������� {dodge} ");
        }

        /// <summary>
        /// ����� �������. 
        /// ������ �������������� "M:Magic.Doctor.Heal".
        /// </summary>
        public void Heal(int powerTreatment)
        {
            // ������ ������ ������, ��� ������������ ��������.
            health = (health + powerTreatment) < Settings.GetInstance(0, 0).Health 
                ? (health + powerTreatment) : Settings.GetInstance(0, 0).Health;
        }

        /// <summary>
        /// ����� ��������� �����. 
        /// ������ �������������� "M:Magic.Doctor.GetHit".
        /// </summary>
        public override void GetHit(int strengthAttack)
        {
            Random random = new();
            double randomNumber = random.NextDouble();

            //���� ��������� �� ��������� => unit �������� ����. 
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
        /// ����� ��������. 
        /// ������ �������������� "M:Magic.Doctor.Health".
        /// </summary>
        /// <returns>�������� ��������.</returns> 
        public override int Health()
        {
            return health;
        }

        /// <summary>
        /// ����� �����. 
        /// ������ �������������� "M:Magic.Doctor.Attack".
        /// </summary>
        /// <returns>�������� �����.</returns> 
        public override int Attack()
        {
            return attack;
        }

        /// <summary>
        /// ����� ������. 
        /// ������ �������������� "M:Magic.Doctor.Defense".
        /// </summary>
        /// <returns>�������� ������.</returns> 
        public override int Defense()
        {
            return defense;
        }

        /// <summary>
        /// ����� ������. 
        /// ������ �������������� "M:Magic.Doctor.Dodge".
        /// </summary>
        /// <returns>�������� ������.</returns> 
        public override double Dodge()
        {
            return dodge;
        }

        /// <summary>
        /// ����� ���������. 
        /// ������ �������������� "M:Magic.Doctor.Cost".
        /// </summary>
        /// <returns>�������� ����������.</returns> 
        public override int Cost()
        {
            return cost;
        }

        /// <summary>
        /// ����� �������� �����. 
        /// ������ �������������� "M:Magic.Doctor.MakeClone".
        /// </summary>
        /// <returns>����������� �����.</returns> 
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
        /// ����� �������� ������� ��� �������. 
        /// ������ �������������� "M:Magic.Doctor.DoSpecialProperty�olumn(Magic.IUnit, Magic.IUnit, int)".
        /// </summary>
        /// <returns>����.</returns> 
        public IUnit? DoSpecialProperty�olumn(List<IUnit> ownArmy,
            List<IUnit> enemyArmy, int number)
        {
            if (procent >= new Random().NextDouble())
            {
                // ���� ������� ������� ����������. 
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
                    // ���� ����� ������� ����������.
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
        /// ����� �������� ������� ��� ���������. 
        /// ������ �������������� "M:Magic.Doctor.DoSpecialPropertyBattalion(Magic.IUnit, Magic.IUnit, int)".
        /// </summary>
        /// <returns>����.</returns> 
        public IUnit? DoSpecialPropertyBattalion(List<IUnit> ownArmy,
            List<IUnit> enemyArmy, int number)
        {
            if (procent >= new Random().NextDouble())
            {
                // ���� ����� ������� ����������. 
                if (number % 3 != 0 && number - 1 >= 0)
                {
                    if (ownArmy[number - 1] is LogGetAttack unitTemp1 
                        && unitTemp1.unit is IHealtheble patient)
                    {
                        patient.Heal(powerTreatment);
                    }
                }
                // ���� ����� ������� ����������. 
                else if (number % 3 != 2 &&  number + 1 <= ownArmy.Count-1 )
                {
                        if (ownArmy[number + 1] is LogGetAttack unitTemp2
                        && unitTemp2.unit is IHealtheble patient)
                        {
                            patient.Heal(powerTreatment);
                        }
                }
                // ���� ������� ������� ����������.
                else if (number - 3 >=0)
                {
                    if (ownArmy[number - 3] is LogGetAttack unitTemp2 
                        && unitTemp2.unit is IHealtheble patient)
                    {
                        patient.Heal(powerTreatment);
                    }
                }
                // ���� ����� ������� ����������. 
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
        /// ����� �������� ������� ������ �� ������. 
        /// ������ �������������� "M:Magic.Doctor.DoSpecialPropertyWallToWall(Magic.IUnit, Magic.IUnit, int)".
        /// </summary>
        /// <returns>����.</returns> 
        public IUnit? DoSpecialPropertyWallToWall(List<IUnit> ownArmy,
            List<IUnit> enemyArmy, int number)
        {
            if (procent >= new Random().NextDouble())
            {
                // ���� ������ ������� ����������. 
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
                    // ���� ����� ������� ����������. 
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