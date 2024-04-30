
using System.ComponentModel.DataAnnotations;

namespace Magic
{
    class Doctor : IUnit, ISpecialProperty, IHealtheble
    {
        // ���������� �������������� �������.
        int radiusAttack = 2;
        int arrowDamage = 40;
        public Doctor((int, double) percentAttackAndDodge) : base(percentAttackAndDodge)
        {
            attack += 10;
            cost = 4;
            dodge += 0.1;
            defense = 0;
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
                        patient.Heal(arrowDamage);
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
                            patient.Heal(arrowDamage);
                            return null;
                        }
                    }
                }
            }
            return null;
        }

        public void Heal(int arrowDamage)
        {
            // ������ ������ ������, ��� ������������ ��������
            health = (health + arrowDamage) < Settings.GetInstance(0, 0).Health ? (health + arrowDamage) : Settings.GetInstance(0, 0).Health;
        }

        public override string ToString()
        {
            return string.Format($"������. ��������: {health} ����: {attack} ���������: {cost} ����� {defense}  ��������� {dodge} ");
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
    }
}