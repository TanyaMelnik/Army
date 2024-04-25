using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Magic
{
    class Bowman : IUnit, ISpecialProperty
    {
        public Bowman(Settings settings, (int, double) percentAttackAndDodge) : base(settings, percentAttackAndDodge)
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
            return string.Format($"������ ������. ��������: {health} ����: {health} ���������: {cost} ����� {defense} ");
        }



        // number - ��� ���������� ����� ������� � ������ (�� 1 �� ������� ����� �����)
        public IUnit DoSpecialProperty(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            if (number < radiusAttack + 1)
            {
                // ������������� ���������� ������, � ������� �� ����� �������.
                int countEnemy = (radiusAttack + 1) - number;
                // ���� ���������� ����������� ������ ���������� �����.
                if (countEnemy > enemyArmy.Count) countEnemy = enemyArmy.Count;

                // �������� �������� ����.
                var rand = new Random();
                // �� 0 ������������ �� countEnemy �� ������������
                int aim = rand.Next(0, countEnemy);

                // ���� ������� - enemyArmy[aim]

                enemyArmy[aim].GetHit(arrowDamage);
            }
            return null;
        }

    }
}