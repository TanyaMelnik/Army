namespace Magic {
    class LightWarrior : IUnit, ICloneable,IHealtheble
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

        public void Heal(int arrowDamage)
        {
            // ������ ������ ������, ��� ������������ ��������
            health = (health + arrowDamage) < Settings.GetInstance(0, 0).Health ? (health + arrowDamage) : Settings.GetInstance(0, 0).Health;
        } 

        public override string ToString()
        {
            return string.Format($"������ ������. ��������: {health} ����: {attack} ���������: {cost} ����� {defense} ��������� {dodge}");
        }
    } 
}