
namespace Magic
{
    class Genetic : IUnit, ISpecialProperty, IHealtheble
    {
        public override string Name() => name;
        /// <summary>
        /// ������� ������������ - 10%
        /// </summary>
        double procentClone=0.1;
        public Genetic((int, double) percentAttackAndDodge) : base(percentAttackAndDodge)
        {
            attack += 20;
            cost = 5;
            dodge += 0.4;
            defense = 10;
            name = "�������";
        }

        public override string ToString()
        {
            return string.Format($"{Name()}. ��������: {health} ����: {attack} ���������: {cost} ����� {defense}  ��������� {dodge} ");
        }

        public IUnit DoSpecialProperty(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            // ����������� ������������ 10% ��������
            if (procentClone >= new Random().NextDouble()) {
                for (int i = 0; i < ownArmy.Count; i++)
                {
                    // ���� ��� ����� ����������� 
                   // LogGetAttack unitTemp = (LogGetAttack)ownArmy[i];
                    if (ownArmy[i] is LogGetAttack lightUnit && lightUnit.unit is ICloneable clone)
                    {
                        Console.WriteLine("��������������������������������������������");
                        return clone.Clone();
                    }
                }
            }
            return null;
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
            else Console.WriteLine("��������� ��������� �� �����");
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
    }
}