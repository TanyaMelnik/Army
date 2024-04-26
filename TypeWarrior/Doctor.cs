namespace Magic
{
    class Doctor : IUnit
    {
        public Doctor(Settings settings, (int , double) percentAttackAndDodge) : base(settings, percentAttackAndDodge)
        {
            attack += 10;
            cost = 4;
            dodge += 0.1;
            defense = 0;
        }
        /*public void GetHit(int strength)
        {
            // ���� �� ����� 
            defense = defense - strength >= 0 ? defense - strength : 0;
            // ���� �� �������� 
            health = defense - strength < 0 ? health + (defense - strength) : health;
            // �������� � ��������, ���� ������ ..... 
        }*/

        public override string ToString()
        {
            return string.Format($"������. ��������: {health} ����: {health} ���������: {cost} ����� {defense} ");
        }

    }
}