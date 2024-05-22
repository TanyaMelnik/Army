
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Magic
{
    class Doctor : IUnit, ISpecialProperty, IHealtheble
    {
        public override string Name() => name;
        // ���������� �������������� �������.
        int powerTreatment = 40;
        double procent = 0.9;

        public Doctor((int, double) percentAttackAndDodge) : base(percentAttackAndDodge)
        {
            attack += 10;
            cost = 4;
            dodge += 0.1;
            defense = 0;
            name = "������";
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
            var a = new Doctor((attack - 10, dodge - 0.1));
            a.health = health;
            a.defense = defense;
            return new LogGetAttack(a, (attack - 10, dodge - 0.1));
        }

        // ����������� �������� - ������ 
        public IUnit DoSpecialProperty(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            if (procent >= new Random().NextDouble())
            {
                // ���� ������� ������� ���������� 
                if (number - 1 > 0)
                {
                    // ���� ��� ����� �������� 
                    if (ownArmy[number - 1] is LogGetAttack unitTemp1 && unitTemp1.unit is IHealtheble patient)
                    {
                        patient.Heal(powerTreatment);
                    }
                }
                else
                {
                    // ���� ����� ������� ���������� 
                    if (number + 1 < ownArmy.Count)
                    {
                        // ���� ��� ����� �������� 
                        if (ownArmy[number + 1] is LogGetAttack unitTemp2 && unitTemp2.unit is IHealtheble patient)
                        {
                            patient.Heal(powerTreatment);
                        }
                    }
                }
            }
            return null;
        }

        public IUnit DoSpecialProperty�olumn(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            throw new NotImplementedException();
        }

        public IUnit DoSpecialPropertyBattalion(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            throw new NotImplementedException();
        }

        public IUnit DoSpecialPropertyWallToWall(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            throw new NotImplementedException();
        }
    }
}