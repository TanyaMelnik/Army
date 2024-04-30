
namespace Magic
{
    class Bowman : IUnit, ISpecialProperty, ICloneable, IHealtheble
    {
        public Bowman((int, double) percentAttackAndDodge) : base(percentAttackAndDodge)
        {
            attack += 20;
            cost = 3;
            dodge += 0.3;
            defense = 30;
        }

        // ���������� �������������� �������.
        int radiusAttack = 10;
        int arrowDamage = 40;

        public override string ToString()
        {
            return string.Format($"������. ��������: {health} ����: {attack} ���������: {cost} ����� {defense}  ��������� {dodge} ");
        }

        // number - ��� ���������� ����� ������� � ������ (�� 1 �� ������� ����� �����)
        public IUnit DoSpecialProperty(List<IUnit> enemyArmy, int number)
        {
            if (number < radiusAttack + 1)
            {
                // ������������� ���������� ������, � ������� �� ����� �������.
                int countEnemy = (radiusAttack + 1) - number;
                // ���� ���������� ����������� ������ ���������� �����.
                if (countEnemy > enemyArmy.Count) countEnemy = enemyArmy.Count;
                // �������� �������� ����. �� 0 ������������ �� countEnemy �� ������������
                int aim = new Random().Next(0, countEnemy);
                // ���� ������� - enemyArmy[aim
                enemyArmy[aim].GetHit(arrowDamage);
            }
            return null;
        }
        public IUnit Clone()
        {
            return new LogGetAttack(new Bowman((attack - 20, dodge - 0.3)), (attack - 20, dodge - 0.3));
        }

        public void Heal(int arrowDamage)
        {
            // ������ ������ ������, ��� ������������ ��������
            health = (health + arrowDamage) < Settings.GetInstance(0, 0).Health ? (health + arrowDamage) : Settings.GetInstance(0, 0).Health;
        }
    }
}