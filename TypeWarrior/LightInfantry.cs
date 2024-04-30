namespace Magic {
    class LightWarrior : IUnit, ICloneable
    {
        public LightWarrior((int , double ) percentAttackAndDodge) : base(percentAttackAndDodge)
        {
            attack += 40;
            cost = 1;
            dodge += 0.2;
            defense = 50;
        }

        public IUnit Clone()
        {
            return new LogGetAttack(new LightWarrior((attack - 40, dodge - 0.2)), (attack-40, dodge-0.2));
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

     

        public override string ToString()
        {
            return string.Format($"������ ������. ��������: {health} ����: {attack} ���������: {cost} ����� {defense} ��������� {dodge}");
        }
    } 
}