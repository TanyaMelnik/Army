namespace Magic{

    abstract class IUnit
    {
        /// <summary>
        /// �������� �����.
        /// </summary>
        protected int health;

        /// <summary>
        /// ���� �����. ����, ������� ����� ������� ����
        /// </summary>
        protected int attack;

        /// <summary>
        /// ��������� �����.
        /// </summary>
        protected int cost;

        /// <summary>
        /// ��������� �����.
        /// </summary>
        protected double dodge;

        /// <summary>
        /// ��� ������.
        /// </summary>
        protected int defense;

        /// <summary>
        /// �����������, ������� ���� ��������� �� ������������.
        /// </summary>
        public IUnit()
        {

        }
        public int GetCost()
        {
            return cost;
        }
        /// <summary>
        /// ����� ������������� �����.
        /// </summary>
        /// <returns></returns>
        public abstract string ToString();

        /// <summary>
        /// ����� �����.
        /// </summary>
        /// <returns>
        /// ���� ����� �� ����� �����.
        /// </returns>
        public abstract void Attack(IUnit two);
    }
}