namespace Magic
{
    /// <summary>
    ///  ����� �����.
    ///  ������ �������������� "T:Magic.IUnit".
    /// </summary> 
    public abstract class IUnit((int percentAttack, double 
        percentDodge) percentAttackAndDodge)
    {
        /// <summary>
        /// ����, ���������� ��� �����.
        /// ������ �������������� "F:Magic.IUnit.name".
        /// </summary>
        protected string ?name;

        /// <summary>
        /// ����� ����� �����.
        /// ������ �������������� "M:Magic.IUnit.Name)".
        /// </summary>
        public abstract string Name();

        /// <summary>
        /// ����, ���������� �������� �����.
        /// ������ �������������� "F:Magic.IUnit.health".
        /// </summary>
        protected int health = Settings.GetInstance(0,0).Health;

        /// <summary>
        /// ����� �������� �����.
        /// ������ �������������� "M:Magic.IUnit.Health)".
        /// </summary>
        public abstract int Health();

         /// <summary>
        /// ����, ���������� ���� �����.
        /// ������ �������������� "F:Magic.IUnit.percentAttack".
        /// </summary>
        protected int attack = percentAttackAndDodge.percentAttack;

        /// <summary>
        /// ����� ������ �����.
        /// ������ �������������� "M:Magic.IUnit.Attack)".
        /// </summary>
        public abstract int Attack();

        /// <summary>
        /// ����, ���������� ��������� �����.
        /// ������ �������������� "F:Magic.IUnit.cost".
        /// </summary>
        protected int cost;

        /// <summary>
        /// ����� ��������� �����.
        /// ������ �������������� "M:Magic.IUnit.Cost".
        /// </summary>
        public abstract int Cost();

        /// <summary>
        /// ����, ���������� ��������� �����.
        /// ������ �������������� "F:Magic.IUnit.percentDodge".
        /// </summary>
        protected double dodge = percentAttackAndDodge.percentDodge;

        /// <summary>
        /// ����� ��������� �����.
        /// ������ �������������� "M:Magic.IUnit.Dodge".
        /// </summary>
        public abstract double Dodge();

        /// <summary>
        /// ����, ���������� ������.
        /// ������ �������������� "F:Magic.IUnit.defense".
        /// </summary>
        protected int defense;

        /// <summary>
        /// ����� ������.
        /// ������ �������������� "M:Magic.IUnit.Defense".
        /// </summary>
        public abstract int Defense();

        /// <summary>
        /// ����� ������������� �����.
        /// </summary>
        /// <returns>������, �������������� ����.</returns>
        public override abstract string ToString();

        /// <summary>
        /// ����� ��������� �����.
        /// </summary>
        /// <param name="strengthAttack">���������� ����.</param>
        public abstract void GetHit(int strengthAttack);

        /// <summary>
        /// ����� ������������ �����.
        /// ������ �������������� "M:Magic.IUnit.MakeClone".
        /// </summary>
        public abstract IUnit MakeClone();

    }
}