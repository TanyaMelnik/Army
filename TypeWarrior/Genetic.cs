namespace Magic
{
    /// <summary>
    /// ����� ��������.
    /// ������ �������������� "T:Magic.Doctor".
    /// </summary> 
    class Genetic : IUnit, ISpecialProperty, IHealtheble
    {
        /// <summary>
        /// ����� ��������.
        /// ������ �������������� "M:Magic.Genetic.Name".
        /// </summary>
        public override string Name() => name ?? "";

        /// <summary>
        /// ���� �������� ������������.
        /// ������ �������������� "F:Magic.Genetic.powerTreatment".
        /// </summary>
        readonly double procentClone = 0.1;

        /// <summary>
        /// ����� �������� ��������.
        /// ������ �������������� "�:Magic.Genetic.procent".
        /// </summary>
        public Genetic((int, double) percentAttackAndDodge) : 
            base(percentAttackAndDodge)
        {
            attack += 20;
            cost = 5;
            dodge += 0.4;
            defense = 10;
            name = "�������";
        }

        /// <summary>
        /// ����� ������.
        /// ������ �������������� "M:Magic.Genetic.ToString".
        /// </summary>
        /// <returns>�������� ��������.</returns>
        public override string ToString()
        {
            return string.Format($"{Name()}. ��������: {health} ����: {attack} " +
                $"���������: {cost} ����� {defense}  ��������� {dodge} ");
        }

        /// <summary>
        /// ����� �������. 
        /// ������ �������������� "M:Magic.Genetic.Heal".
        /// </summary>
        public void Heal(int powerTreatment)
        {
            // ������ ������ ������, ��� ������������ ��������.
            health = (health + powerTreatment) < Settings.GetInstance(0, 0).Health 
                ? (health + powerTreatment) : Settings.GetInstance(0, 0).Health;
        }

        /// <summary>
        /// ����� ��������� �����. 
        /// ������ �������������� "M:Magic.Genetic.GetHit".
        /// </summary>
        public override void GetHit(int strengthAttack)
        {
            Random random = new();
            double randomNumber = random.NextDouble();

            // ���� ��������� �� ��������� => unit �������� ����.
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
        /// ������ �������������� "M:Magic.Genetic.Health".
        /// </summary>
        /// <returns>�������� ��������.</returns> 
        public override int Health()
        {
            return health;
        }

        /// <summary>
        /// ����� �����. 
        /// ������ �������������� "M:Magic.Genetic.Attack".
        /// </summary>
        /// <returns>�������� �����.</returns> 
        public override int Attack()
        {
            return attack;
        }

        /// <summary>
        /// ����� ������. 
        /// ������ �������������� "M:Magic.Genetic.Defense".
        /// </summary>
        /// <returns>�������� ������.</returns> 
        public override int Defense()
        {
            return defense;
        }

        /// <summary>
        /// ����� ������. 
        /// ������ �������������� "M:Magic.Genetic.Dodge".
        /// </summary>
        /// <returns>�������� ������.</returns> 
        public override double Dodge()
        {
            return dodge;
        }

        /// <summary>
        /// ����� ���������. 
        /// ������ �������������� "M:Magic.Genetic.Cost".
        /// </summary>
        /// <returns>�������� ����������.</returns> 
        public override int Cost()
        {
            return cost;
        }

        /// <summary>
        /// ����� �������� �����. 
        /// ������ �������������� "M:Magic.Genetic.MakeClone".
        /// </summary>
        /// <returns>����������� �����.</returns> 
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
        /// ����� �������� ������� ��� �������. 
        /// ������ �������������� "M:Magic.Genetic.DoSpecialProperty�olumn(Magic.IUnit, Magic.IUnit, int)".
        /// </summary>
        /// <returns>����.</returns> 
        public IUnit? DoSpecialProperty�olumn(List<IUnit> ownArmy, 
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
        /// ����� �������� ������� ��� ���������. 
        /// ������ �������������� "M:Magic.Genetic.DoSpecialPropertyBattalion(Magic.IUnit, Magic.IUnit, int)".
        /// </summary>
        /// <returns>����.</returns> 
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
        /// ����� �������� ������� ������ �� ������. 
        /// ������ �������������� "M:Magic.Genetic.DoSpecialPropertyWallToWall(Magic.IUnit, Magic.IUnit, int)".
        /// </summary>
        /// <returns>����.</returns> 
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