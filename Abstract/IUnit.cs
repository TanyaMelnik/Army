namespace Magic{

    public abstract class IUnit
    {
        /// <summary>
        /// �������� �����.
        /// </summary>
        // �������� 100.
        protected int health;

        /// <summary>
        /// ���� �����. ����, ������� ����� ������� ����
        /// </summary>
        // �������� 50.
        protected int attack;

        /// <summary>
        /// ��������� �����.
        /// </summary>
        protected int cost;

        /// <summary>
        /// ��������� �����.
        /// </summary>
        // �������� 1
        protected double dodge;

        /// <summary>
        /// ��� ������.
        /// </summary>
        // �������� 100
        protected int defense;

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