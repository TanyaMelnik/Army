namespace Magic{

    /// <summary>
    /// �����������, ������� ���� ��������� �� ������������.
    /// </summary>
    public abstract class IUnit((int percentAttack, double percentDodge) percentAttackAndDodge)
    {
        /// <summary>
        /// �������� �����.
        /// </summary>
        // �������� 100.
        protected int health = Settings.GetInstance(0,0).Health;
        public int Health { 
            get { return health; }
        }

        /// <summary>
        /// ���� �����. ����, ������� ����� ������� ����
        /// </summary>
        // �������� 50.
        protected int attack = percentAttackAndDodge.percentAttack;
        public int Attack {
            get { return attack; }
        }

        /// <summary>
        /// ��������� �����.
        /// </summary>
        protected int cost;
        public int Cost
        {
            get { return cost; }
        }
        /// <summary>
        /// ��������� �����.
        /// </summary>
        // �������� 1
        protected double dodge = percentAttackAndDodge.percentDodge;
        public double Dodge
        {
            get { return dodge; }
        }
        /// <summary>
        /// ��� ������.
        /// </summary>
        // �������� 100
        protected int defense;
        public int Defense
        {
            get { return defense; }
        }

        public int GetCost()
        {
            return cost;
        }
        /// <summary>
        /// ����� ������������� �����.
        /// </summary>
        /// <returns></returns>
        public override abstract string ToString();

        public void GetHit(int strengthAttack)
        {
            Random random = new Random();
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
                else health -= attack;
            }
        }

    }
}