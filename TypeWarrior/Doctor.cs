
using System.ComponentModel.DataAnnotations;

namespace Magic
{
    class Doctor : IUnit, ISpecialProperty, IHealtheble
    {
        public override string Name() => name;
        // ���������� �������������� �������.
        int radiusAttack = 2;
        int powerTreatment = 40;
        public Doctor((int, double) percentAttackAndDodge) : base(percentAttackAndDodge)
        {
            attack += 10;
            cost = 4;
            dodge += 0.1;
            defense = 0;
            name = "������";
        }
        // ����������� �������� - ������ 
        public IUnit DoSpecialProperty(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            for (int i = 0;i<= radiusAttack; i++)
            {
                // ���� ������� ������� ���������� 
                if (number + i < ownArmy.Count)
                { 
                    // ���� ��� ����� �������� 
                    if (ownArmy[number + i] is IHealtheble patient)
                    {
                        patient.Heal(powerTreatment);
                        return null;
                    }
                }
                else
                {
                    // ���� ����� ������� ���������� 
                    if (number - i >= 0)
                    {
                        // ���� ��� ����� �������� 
                        if (ownArmy[number - i] is IHealtheble patient)
                        {
                            patient.Heal(powerTreatment);
                            return null;
                        }
                    }
                }
            }
            return null;
        }

       

        public override string ToString()
        {
            return string.Format($"{Name()}. ��������: {health} ����: {attack} ���������: {cost} ����� {defense}  ��������� {dodge} ");
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