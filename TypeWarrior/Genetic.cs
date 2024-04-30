
namespace Magic
{
    class Genetic : IUnit, ISpecialProperty, IHealtheble
    {
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
        }

        public override string ToString()
        {
            return string.Format($"�������. ��������: {health} ����: {attack} ���������: {cost} ����� {defense}  ��������� {dodge} ");
        }

        public IUnit DoSpecialProperty(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            // ����������� ������������ 10%
            if (procentClone >= new Random().NextDouble()) {
                for (int i = 0; i < ownArmy.Count; i++)
                {
                    // ���� ��� ����� ����������� 
                    if (ownArmy[i] is ICloneable clone)
                    {
                        return clone.Clone();
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
    }
}