namespace Magic
{
    class Bowman : IUnit
    {
        public Bowman(Settings settings):base(settings)
        {
            attack = 30;
            cost = 3;
            dodge = 0.3;
            defense = 30;
    }
        public void GetHit(int strength)
        {
            // ���� �� ����� 
            defense = defense - strength >= 0 ? defense - strength : 0;
            // ���� �� �������� 
            health = defense - strength < 0 ? health + (defense - strength) : health;
            // �������� � ��������, ���� ������ ..... 
        }

        public override string ToString()
        {
            return string.Format($"������ ������. ��������: {health} ����: {health} ���������: {cost} ����� {defense} ");
        }

    }
}