namespace Magic
{
    class HeavyWarrior : IUnit,IHealtheble
    {
        public HeavyWarrior((int, double) percentAttackAndDodge) : base(percentAttackAndDodge)
        {
            attack += 50;
            cost = 2;
            dodge += 0.05;
            defense = 100;
        }
        public void Heal(int arrowDamage)
        {
            // Нельзя лечить больше, чем максимальное здоровье
            health = (health + arrowDamage) < Settings.GetInstance(0, 0).Health ? (health + arrowDamage) : Settings.GetInstance(0, 0).Health;
        }

        public override string ToString()
        {
            return string.Format($"Тяжёлый Солдат. Здоровье: {health} Сила: {attack} Стоимость: {cost} Броня {defense} Уклонение {dodge} ");
        }
        public override void GetHit(int strengthAttack)
        {
            Random random = new Random();
            double randomNumber = random.NextDouble();
            //Если уклонение не произошло => unit получает урон 
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

        public override int Health()
        {
            return health;
        }
        public override int Attack()
        {
            return attack;
        }
    }
}