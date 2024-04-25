namespace Magic {
    class LightWarrior : IUnit, ICloneable
    {
        public LightWarrior(Settings settings, (int , double ) percentAttackAndDodge) : base(settings, percentAttackAndDodge)
        {
            attack += 40;
            cost = 1;
            dodge += 0.2;
            defense = 50;
        }
        public void GetHit(int strength)
        {
            // Удар по броне 
            defense = defense - strength >= 0 ? defense - strength : 0;
            // Удар по здоровью 
            health = defense - strength < 0 ? health + (defense - strength) : health;
            // Проверка и действия, если смерть ..... 
        }

        public int DoAttack()
        {
            return attack;
        }

        public void Clone()
        {
            
        }

        public override string ToString()
        {
            return string.Format($"Легкий Солдат. Здоровье: {health} Сила: {health} Стоимость: {cost} Броня {defense} ");
        }
    } 
}