namespace Magic
{
    class HeavyWarrior : IUnit
    {
        public HeavyWarrior((int, double) percentAttackAndDodge) : base(percentAttackAndDodge)
        {
            attack += 50;
            cost = 2;
            dodge += 0.05;
            defense = 100;
        }
       /* public void GetHit(int strength)
        {
            // ���� �� ����� 
            defense = defense - strength >= 0 ? defense - strength : 0;
            // ���� �� �������� 
            health = defense - strength < 0 ? health + (defense - strength) : health;
            // �������� � ��������, ���� ������ ..... 
        }*/

        public int DoAttack()
        {
            return attack;
        }

        public void Clone()
        {

        }

        // ��� ��������
        public void Print()
        {
            Console.WriteLine($"������ ������. ��������: {health} �����: {attack} ���������: {cost} ����� {defense} ");
        }

        // �� ��������
        public override string ToString()
        {
            return string.Format($"������ ������. ��������: {health} ����: {attack} ���������: {cost} ����� {defense} ��������� {dodge} ");
        }

    }
}