namespace Magic
{
    /// <summary>
    /// ����� �������� �����.
    /// ������ �������������� "T:Magic.HeavyWarrior".
    /// </summary> 
    class HeavyWarrior : IUnit,IHealtheble
    {
        /// <summary>
        /// ����� ��������.
        /// ������ �������������� "M:Magic.HeavyWarrior.Name".
        /// </summary>
        public override string Name() => name ?? "";

        /// <summary>
        /// ����� �������� �������� �����.
        /// ������ �������������� "�:Magic.HeavyWarrior.procent".
        /// </summary>
        public HeavyWarrior((int, double) percentAttackAndDodge) : base(percentAttackAndDodge)
        {
            attack += 50;
            cost = 2;
            dodge += 0.05;
            defense = 100;
            name = "������ ������";
        }

        /// <summary>
        /// ����� ������.
        /// ������ �������������� "M:Magic.HeavyWarrior.ToString".
        /// </summary>
        /// <returns>�������� ��������.</returns>
        public override string ToString()
        {
            return string.Format($"{Name()}. ��������: {health} ����: {attack} " +
                $"���������: {cost} ����� {defense} ��������� {dodge} ");
        }

        /// <summary>
        /// ����� �������. 
        /// ������ �������������� "M:Magic.HeavyWarrior.Heal".
        /// </summary>
        public void Heal(int powerTreatment)
        {
            // ������ ������ ������, ��� ������������ ��������.
            health = (health + powerTreatment) < Settings.GetInstance(0, 0).Health 
                ? (health + powerTreatment) : Settings.GetInstance(0, 0).Health;
        }

        /// <summary>
        /// ����� ��������� �����. 
        /// ������ �������������� "M:Magic.HeavyWarrior.GetHit".
        /// </summary>
        public override void GetHit(int strengthAttack)
        {
            Random random = new ();
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
        /// ������ �������������� "M:Magic.HeavyWarrior.Health".
        /// </summary>
        /// <returns>�������� ��������.</returns> 
        public override int Health()
        {
            return health;
        }

        /// <summary>
        /// ����� �����. 
        /// ������ �������������� "M:Magic.HeavyWarrior.Attack".
        /// </summary>
        /// <returns>�������� �����.</returns> 
        public override int Attack()
        {
            return attack;
        }

        /// <summary>
        /// ����� ������. 
        /// ������ �������������� "M:Magic.HeavyWarrior.Defense".
        /// </summary>
        /// <returns>�������� ������.</returns> 
        public override int Defense()
        {
            return defense;
        }

        /// <summary>
        /// ����� ������. 
        /// ������ �������������� "M:Magic.HeavyWarrior.Dodge".
        /// </summary>
        /// <returns>�������� ������.</returns> 
        public override double Dodge()
        {
            return dodge;
        }

        /// <summary>
        /// ����� ���������. 
        /// ������ �������������� "M:Magic.HeavyWarrior.Cost".
        /// </summary>
        /// <returns>�������� ����������.</returns> 
        public override int Cost()
        {
            return cost;
        }

        /// <summary>
        /// ����� �������� �����. 
        /// ������ �������������� "M:Magic.HeavyWarrior.MakeClone".
        /// </summary>
        /// <returns>����������� �����.</returns> 
        public override IUnit MakeClone()
        {
            var a = new HeavyWarrior((attack - 50, dodge - 0.05))
            {
                health = health,
                defense = defense
            };
            return new LogGetAttack(a, (attack - 50, dodge - 0.05));
        }
    }
}