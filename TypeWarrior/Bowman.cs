
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
        public IUnit DoSpecialProperty(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            if (number < radiusAttack + 1)
            {
                // ������������� ���������� ������, � ������� �� ����� �������.
                int countEnemy = (radiusAttack + 1) - number;
                // ���� ���������� ����������� ������ ���������� �����.
                if (countEnemy > enemyArmy.Count) countEnemy = enemyArmy.Count;
                // �������� �������� ����. �� 0 ������������ �� countEnemy �� ������������
                int aim = new Random().Next(0, countEnemy);
                // ���� ������� - enemyArmy[aim]
                enemyArmy[aim].GetHit(arrowDamage);
                ProxyDie proxy = new(new DeadUnit());
                if (enemyArmy[aim].Health() < 0) proxy.DeleteUnit(enemyArmy, aim);
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
        public override void GetHit(int strengthAttack)
        {
            Random random = new Random();
            double randomNumber = random.NextDouble();
            //���� ��������� �� ��������� => unit �������� ���� 
            if (dodge < randomNumber)
            {
                if (defense >= strengthAttack) defense -= strengthAttack;
                else if (defense < strengthAttack && defense > 0)
                {
                    int x = strengthAttack - defense;
                    defense = 0;
                    health -= x;
                }
                else health -= attack;
            }

        }
        public override int Health()
        {
            return health;
        }
        public override int Attack()
        {
            return attack;
        }
    }
}