namespace Magic{

    public abstract class IUnit
    {
        /// <summary>
        /// �������� �����.
        /// </summary>
        // �������� 100.
        public int health;

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
        public int defense;

        /// <summary>
        /// �����������, ������� ���� ��������� �� ������������.
        /// </summary>
        public IUnit(Settings settings)
        {
            health = settings.Health;
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
        /// ����� ����� �������� ���. ������� ���� �������.
        /// </summary>
        public void Attack(IUnit two)
        {
            if (two.defense >= attack) two.defense -= attack;
            else if (two.defense < attack && two.defense > 0)
            {
                int x = attack - two.defense;
                two.defense = 0;
                two.health -= x;
            }
            else two.health-=attack; 
        }
    }
}