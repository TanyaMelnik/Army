namespace Magic{

    /// <summary>
    /// �����������, ������� ���� ��������� �� ������������.
    /// </summary>
    public abstract class IUnit((int percentAttack, double percentDodge) percentAttackAndDodge)
    {
        protected string name;
        public abstract string Name();
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
        public abstract int Cost();
        /// <summary>
        /// ��������� �����.
        /// </summary>
        // �������� 1
        protected double dodge = percentAttackAndDodge.percentDodge;
        public abstract double Dodge();
        /// <summary>
        /// ��� ������.
        /// </summary>
        // �������� 100
        protected int defense;
        public abstract int Defense();

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