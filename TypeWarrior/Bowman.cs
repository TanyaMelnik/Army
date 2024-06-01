namespace Magic
{
    /// <summary>
    ///  ����� �������.
    ///  ������ �������������� "T:Magic.�olumn".
    /// </summary> 
    class Bowman : IUnit, ISpecialProperty, ICloneable, IHealtheble
    {
        /// <summary>
        /// ����� ��������.
        /// ������ �������������� "M:Magic.Bowman.Name".
        /// </summary>
        public override string Name() => name ?? "";

        /// <summary>
        /// ����� ���������� �������.
        /// ������ �������������� "M:Magic.Bowman.Bowman(int, double)".
        /// </summary>
        public Bowman((int, double) percentAttackAndDodge) : base(percentAttackAndDodge)
        {
            attack += 20;
            cost = 3;
            dodge += 0.3;
            defense = 30;
            name = "������";
        }

        /// <summary>
        /// ���� ������� ����� �������.
        /// ������ �������������� "F:Magic.Bowman.radiusAttack".
        /// </summary>
        readonly int radiusAttack = 10;

        /// <summary>
        /// ���� ����� �������.
        /// ������ �������������� "F:Magic.Bowman.arrowDamage".
        /// </summary>
        readonly int arrowDamage = 40;

        /// <summary>
        /// ���� �������� �������.
        /// ������ �������������� "F:Magic.Bowman.procent".
        /// </summary>
        readonly double procent = 0.9;

        /// <summary>
        /// ����� ������.
        /// ������ �������������� "M:Magic.Bowman.ToString".
        /// </summary>
        /// <returns>�������� �������.</returns> 
        public override string ToString()
        {
            return string.Format($"{Name()}. ��������: {health} " +
                $"����: {attack} ���������: {cost} ����� {defense}  " +
                $"��������� {dodge} ");
        }

        /// <summary>
        /// ����� ������������. 
        /// ������ �������������� "M:Magic.Bowman.Clone".
        /// </summary>
        /// <returns>����������� �����.</returns> 
        public IUnit Clone()
        {
            return new LogGetAttack(new Bowman((attack - 20, 
                dodge - 0.3)), (attack - 20, dodge - 0.3));
        }

        /// <summary>
        /// ����� �������. 
        /// ������ �������������� "M:Magic.Bowman.Heal".
        /// </summary>
        public void Heal(int powerTreatment)
        {
            // ������ ������ ������, ��� ������������ ��������.
            health = (health + powerTreatment) < Settings.GetInstance(0, 
                0).Health ? (health + powerTreatment) : Settings.GetInstance(0, 0).Health;
        }

        /// <summary>
        /// ����� ��������� �����. 
        /// ������ �������������� "M:Magic.Bowman.GetHit".
        /// </summary>
        public override void GetHit(int strengthAttack)
        {
            Random random = new ();
            double randomNumber = random.NextDouble();

            // ���� ��������� �� ���������, �� unit �������� ����.
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
        /// ������ �������������� "M:Magic.Bowman.Health".
        /// </summary>
        /// <returns>�������� ��������.</returns> 
        public override int Health()
        {
            return health;
        }

        /// <summary>
        /// ����� �����. 
        /// ������ �������������� "M:Magic.Bowman.Attack".
        /// </summary>
        /// <returns>�������� �����.</returns> 
        public override int Attack()
        {
            return attack;
        }

        /// <summary>
        /// ����� ������. 
        /// ������ �������������� "M:Magic.Bowman.Defense".
        /// </summary>
        /// <returns>�������� ������.</returns> 
        public override int Defense()
        {
            return defense;
        }

        /// <summary>
        /// ����� ������. 
        /// ������ �������������� "M:Magic.Bowman.Dodge".
        /// </summary>
        /// <returns>�������� ������.</returns> 
        public override double Dodge()
        {
            return dodge;
        }

        /// <summary>
        /// ����� ���������. 
        /// ������ �������������� "M:Magic.Bowman.Cost".
        /// </summary>
        /// <returns>�������� ����������.</returns> 
        public override int Cost()
        {
            return cost;
        }

        /// <summary>
        /// ����� �������� �����. 
        /// ������ �������������� "M:Magic.Bowman.MakeClone".
        /// </summary>
        /// <returns>����������� �����.</returns> 
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
        /// ����� �������� ������� ��� �������. 
        /// ������ �������������� "M:Magic.Bowman.DoSpecialProperty�olumn(Magic.IUnit, Magic.IUnit, int)".
        /// </summary>
        /// <returns>����.</returns> 
        public IUnit? DoSpecialProperty�olumn(List<IUnit> ownArmy, 
            List<IUnit> enemyArmy, int number)
        {
            if (procent >= new Random().NextDouble())
            {
                if (enemyArmy.Count + 1 > 0)
                {
                    if (number < radiusAttack)
                    {
                        // ������������� ���������� ������, � ������� �� ����� �������.
                        int countEnemy = radiusAttack - number;

                        // ���� ���������� ����������� ������ ���������� �����.
                        if (countEnemy > enemyArmy.Count) countEnemy = enemyArmy.Count;

                        // �������� �������� ����. �� 0 ������������ �� countEnemy �� ������������.
                        int aim = new Random().Next(0, countEnemy);

                        // ���� ������� - enemyArmy[aim].
                        enemyArmy[aim].GetHit(arrowDamage);
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// ����� �������� ������� ��� ���������. 
        /// ������ �������������� "M:Magic.Bowman.DoSpecialPropertyBattalion(Magic.IUnit, Magic.IUnit, int)".
        /// </summary>
        /// <returns>����.</returns> 
        public IUnit? DoSpecialPropertyBattalion(List<IUnit> ownArmy, 
            List<IUnit> enemyArmy, int number)
        {
            if (procent >= new Random().NextDouble())
            {
                if (enemyArmy.Count > 0)
                {
                    if (number < radiusAttack*3)
                    {
                        // ������������� ���������� ������, � ������� �� ����� �������.
                        // ����� ��������� �� 3, ��������� ����� � ��������� �� 3.
                        double a = (radiusAttack * 3 - number) / 3.0;
                        double b = Math.Ceiling(a);
                        int countEnemy = (int)b*3;

                        // ���� ���������� ����������� ������ ���������� �����.
                        if (countEnemy > enemyArmy.Count) countEnemy = enemyArmy.Count;

                        // �������� �������� ����. �� 0 ������������ �� countEnemy
                        // �� ������������.
                        int aim = new Random().Next(0, countEnemy);

                        // ���� ������� - enemyArmy[aim].
                        enemyArmy[aim].GetHit(arrowDamage);
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// ����� �������� ������� ������ �� ������. 
        /// ������ �������������� "M:Magic.Bowman.DoSpecialPropertyWallToWall(Magic.IUnit, Magic.IUnit, int)".
        /// </summary>
        /// <returns>����.</returns> 
        public IUnit? DoSpecialPropertyWallToWall(List<IUnit> ownArmy, 
            List<IUnit> enemyArmy, int number)
        {
            if (procent >= new Random().NextDouble())
            {
                if (enemyArmy.Count > 0)
                {
                    // ������ ����, � ������� ����� ������� ������.
                    int endEnemy = enemyArmy.Count - 1 >= number - radiusAttack + 1 ? 
                        enemyArmy.Count - 1 : -1;

                    // ���� ������ ������ ��� ��������� �� ������� �����.
                    if (endEnemy<0)
                    {
                        return null;
                    }

                    // ��������� ����, � ������� ����� ������� ������.
                    int startEnemy = number - radiusAttack + 1>= 0? number - radiusAttack + 1:0;

                    // �������� �������� ����. �� startEnemy ������������ �� endEnemy �� ������������.
                    int aim = new Random().Next(startEnemy, endEnemy+1);

                    // ���� ������� - enemyArmy[aim].
                    enemyArmy[aim].GetHit(arrowDamage);
                }
            }
            return null;
        }
    }
}