
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

        public IUnit DoSpecialProperty�olumn(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            if (procent >= new Random().NextDouble())
            {
                if (enemyArmy.Count + 1 > 0)
                {
                    if (number < radiusAttack)
                    {
                        // ������������� ���������� ������, � ������� �� ����� �������.
                        int countEnemy = radiusAttack - number;
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

        public IUnit DoSpecialPropertyBattalion(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            if (procent >= new Random().NextDouble())
            {
                if (enemyArmy.Count > 0)
                {
                    if (number < radiusAttack*3)
                    {
                        // ������������� ���������� ������, � ������� �� ����� �������. ����� ��������� �� 3, ��������� ����� � ��������� �� 3
                        double a = (radiusAttack * 3 - number) / 3.0;
                        double b = Math.Ceiling(a);
                        int countEnemy = (int)b*3;
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

        public IUnit DoSpecialPropertyWallToWall(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            if (procent >= new Random().NextDouble())
            {
                if (enemyArmy.Count > 0)
                {
                    // ������ ����, � ������� ����� ������� ������
                    int endEnemy = enemyArmy.Count - 1 >= number - radiusAttack + 1 ? enemyArmy.Count - 1 : -1;
                    // ���� ������ ������ ��� ��������� �� ������� �����
                    if (endEnemy<0)
                    {
                        return null;
                    }
                    // ��������� ����, � ������� ����� ������� ������
                    int startEnemy = number - radiusAttack + 1>= 0? number - radiusAttack + 1:0;
                    // �������� �������� ����. �� startEnemy ������������ �� endEnemy �� ������������
                    int aim = new Random().Next(startEnemy, endEnemy+1);
                    // ���� ������� - enemyArmy[aim]
                    enemyArmy[aim].GetHit(arrowDamage);
                }
            }
            return null;
        }
    }
}