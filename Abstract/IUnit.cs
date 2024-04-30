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
        public abstract int Health();

        /// <summary>
        /// ���� �����. ����, ������� ����� ������� ����
        /// </summary>
        // �������� 50.
        protected int attack = percentAttackAndDodge.percentAttack;
        public abstract int Attack();

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

        public abstract void GetHit(int strengthAttack);
        

    }
}