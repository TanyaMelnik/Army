namespace Magic
{
    public abstract class IUnit((int percentAttack, double percentDodge) percentAttackAndDodge)
    {
        protected string name;
        public abstract string Name();
        /// <summary>
        /// �������� �����.
        /// </summary>
        protected int health = Settings.GetInstance(0,0).Health;
        public abstract int Health();
        /// <summary>
        /// ����/���� �����.
        /// </summary>
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
        protected double dodge = percentAttackAndDodge.percentDodge;
        public abstract double Dodge();
        /// <summary>
        /// ��� ������.
        /// </summary>
        protected int defense;
        public abstract int Defense();
        public int GetCost()
        {
            return cost;
        }
        /// <summary>
        /// ����� ������������� �����.
        /// </summary>
        /// <returns>������, �������������� ����.</returns>
        public override abstract string ToString();

        public abstract void GetHit(int strengthAttack);
        public abstract IUnit MakeClone();

    }
}