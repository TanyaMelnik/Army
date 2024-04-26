
namespace Magic
{
    class Genetic : IUnit, ISpecialProperty
    {
        public Genetic(Settings settings, (int , double) percentAttackAndDodge) : base(settings, percentAttackAndDodge)
        {
            attack += 20;
            cost = 5;
            dodge += 0.4;
            defense = 10;
        }

        /*public void GetHit(int strength)
        {
            // ���� �� ����� 
            defense = defense - strength >= 0 ? defense - strength : 0;
            // ���� �� �������� 
            health = defense - strength < 0 ? health + (defense - strength) : health;
            // �������� � ��������, ���� ������ ..... 
        }*/

        public int DoAttack()
        {
            return attack;
        }

        public void Clone()
        {

        }

        public override string ToString()
        {
            return string.Format($"�������. ��������: {health} ����: {attack} ���������: {cost} ����� {defense} ");
        }

        public IUnit DoSpecialProperty(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            throw new NotImplementedException();
        }
    }
}