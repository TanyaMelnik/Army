
namespace Magic
{
    class Bowman : IUnit, ISpecialProperty, ICloneable, IHealtheble
    {
        public override string Name() => name;
        public Bowman((int, double) percentAttackAndDodge) : base(percentAttackAndDodge)
        {
            attack += 20;
            cost = 3;
            dodge += 0.3;
            defense = 30;
            name = "������";
        }

        // ���������� �������������� �������.
        int radiusAttack = 10;
        int arrowDamage = 40;
        double procent = 0.9;

        public override string ToString()
        {
            return string.Format($"{Name()}. ��������: {health} ����: {attack} ���������: {cost} ����� {defense}  ��������� {dodge} ");
        }

        // number - ��� ���������� ����� ������� � ������ (�� 1 �� ������� ����� �����)
        public IUnit DoSpecialProperty(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            if (procent >= new Random().NextDouble())
            {
                if (enemyArmy.Count > 0)
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
                    }
                }
            }
            return null;
        }
        public IUnit Clone()
        {
            return new LogGetAttack(new Bowman((attack - 20, dodge - 0.3)), (attack - 20, dodge - 0.3));
        }

        public void Heal(int powerTreatment)
        {
            // ������ ������ ������, ��� ������������ ��������
            health = (health + powerTreatment) < Settings.GetInstance(0, 0).Health ? (health + powerTreatment) : Settings.GetInstance(0, 0).Health;
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
                else health -= strengthAttack;
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
        public override int Defense()
        {
            return defense;
        }
        public override double Dodge()
        {
            return dodge;
        }
        public override int Cost()
        {
            return cost;
        }

        public override IUnit MakeClone()
        {
            var a = new Bowman((attack - 20, dodge - 0.3));
            a.health = health;
            a.defense = defense;
            return new LogGetAttack(a, (attack - 20, dodge - 0.3));
        }
    }
}