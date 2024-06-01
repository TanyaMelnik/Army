namespace Magic 
{
    /// <summary>
    /// ����� ������� �����.
    /// ������ �������������� "T:Magic.HeavyWarrior".
    /// </summary> 
    class LightWarrior : IUnit, ICloneable,IHealtheble
    {
        /// <summary>
        /// ����� ��������.
        /// ������ �������������� "M:Magic.LightWarrior.Name".
        /// </summary>
        public override string Name() => name ?? "";

        /// <summary>
        /// ����� �������� ������� �����.
        /// ������ �������������� "�:Magic.LightWarrior.LightWarrior".
        /// </summary>
        public LightWarrior((int , double ) percentAttackAndDodge) : base(percentAttackAndDodge)
        {
            attack += 40;
            cost = 1;
            dodge += 0.2;
            defense = 50;
            name = "������ ������";
        }

        /// <summary>
        /// ����� ������������.
        /// ������ �������������� "�:Magic.LightWarrior.Clone".
        /// </summary>
        public IUnit Clone()
        {
            return new LogGetAttack(new LightWarrior((attack - 40, 
                dodge - 0.2)), (attack-40, dodge-0.2));
        }

        /// <summary>
        /// ����� ������.
        /// ������ �������������� "M:Magic.LightWarrior.ToString".
        /// </summary>
        /// <returns>�������� ��������.</returns>
        public override string ToString()
        {
            return string.Format($"{Name()}. ��������: {health} " +
                $"����: {attack} ���������: {cost} ����� {defense} ��������� {dodge}");
        }

        /// <summary>
        /// ����� �������. 
        /// ������ �������������� "M:Magic.LightWarrior.Heal".
        /// </summary>
        public void Heal(int powerTreatment)
        {
            // ������ ������ ������, ��� ������������ ��������.
            health = (health + powerTreatment) < Settings.GetInstance(0, 0).Health 
                ? (health + powerTreatment) : Settings.GetInstance(0, 0).Health;
        }

        /// <summary>
        /// ����� ��������� �����. 
        /// ������ �������������� "M:Magic.LightWarrior.GetHit".
        /// </summary>
        public override void GetHit(int strengthAttack)
        {
            Random random = new();
            double randomNumber = random.NextDouble();

            //���� ��������� �� ��������� => unit �������� ���� 
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
        /// ������ �������������� "M:Magic.LightWarrior.Health".
        /// </summary>
        /// <returns>�������� ��������.</returns> 
        public override int Health()
        {
            return health;
        }


        /// <summary>
        /// ����� �����. 
        /// ������ �������������� "M:Magic.LightWarrior.Attack".
        /// </summary>
        /// <returns>�������� �����.</returns> 
        public override int Attack()
        {
            return attack;
        }

        /// <summary>
        /// ����� ������. 
        /// ������ �������������� "M:Magic.LightWarrior.Defense".
        /// </summary>
        /// <returns>�������� ������.</returns> 
        public override int Defense()
        {
            return defense;
        }

        /// <summary>
        /// ����� ������. 
        /// ������ �������������� "M:Magic.LightWarrior.Dodge".
        /// </summary>
        /// <returns>�������� ������.</returns> 
        public override double Dodge()
        {
            return dodge;
        }

        /// <summary>
        /// ����� ���������. 
        /// ������ �������������� "M:Magic.LightWarrior.Cost".
        /// </summary>
        /// <returns>�������� ����������.</returns> 
        public override int Cost()
        {
            return cost;
        }

        /// <summary>
        /// ����� �������� �����. 
        /// ������ �������������� "M:Magic.LightWarrior.MakeClone".
        /// </summary>
        /// <returns>����������� �����.</returns> 
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